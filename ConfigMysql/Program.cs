using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.ServiceProcess;

namespace ConfigMysql
{
    class Program
    {

        static bool flagConfig = false;
        static string defaultConfigPath = "MySQL\\MySQL Server 5.1\\bin\\MySQLInstanceConfig.exe";
        static string defaultBinPath = "MySQL\\MySQL Server 5.1\\bin\\";
        static string defaultMyiniPath = "MySQL\\MySQL Server 5.1\\my.ini";
        static string systemPath = null;//default mysql installation path
        static string fullConfigPath = null;
      
        static bool noPostInstall = false;
        static bool noInitialInstall = false;
        static string instantType="clientType"; //for serverType="--serverType"
        static string mysqlPassword = null;


        /// <summary>
        /// command line argument
        /// --noinitialinstall to skip initialinstall
        /// --nopostinstall to skip postinstall
        /// </summary>
        /// <param name="args"></param>
        /// 


        static void Main(string[] args)
        {

            
            systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\";
            fullConfigPath = systemPath + defaultConfigPath;

            //get parametes
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLower().Contains("--password"))
                    mysqlPassword = args[i].Split('=')[1];

                if (mysqlPassword == "1")
                    mysqlPassword = "@@%!mysqlnahani";

                if (args[i].ToLower().Contains("--serverType"))
                    instantType = "serverType";

                if (args[i].ToLower().Contains("--clientType"))
                    instantType = "clientType";

                if (args[i].ToLower().Contains("--nopostinstall"))
                    noPostInstall = true;

                if (args[i].ToLower().Contains("--noinitialinstall"))
                    noInitialInstall = true;

            }

            //excute commands
            for (int i = 0; i < args.Length;i++)
            {

                                           
                //set user privileges
                if (args[i].ToLower().Contains("--setprivilege"))//--setprivilege#root#computername or ipaddress
                { setMysqlUserPrivileges(args[i]); break; }
               
                //start or stop mysql service
                if (args[i].ToLower().Contains("--startserivec"))
                { startOrStopMysqlService(1); break; }

                if (args[i].ToLower().Contains("--stopserivec"))
                {  startOrStopMysqlService(0); break; }

                if (args[i].ToLower().Contains("--mysqlconfig"))
                {
                    if (noInitialInstall == false)
                        configMySQL("mysql", mysqlPassword, "DEVELOPMENT", "MYISAM", "9918");

                    if (noPostInstall == false)
                        doMysqlPostConfig();

                    setMysqlUserPrivileges(null);
                    break;
                }
             

            }
           
          

          
           // System.Console.In.ReadLine();
        }

    
     

        #region mysql post configuration

      
        static short doMysqlPostConfig()
        {
            short c;
            c = changeTheIniFile();
            if (c == -1) return -1;

            //stop service
            startOrStopMysqlService(0);

            System.Threading.Thread.Sleep(5000);

            startOrStopMysqlService(1);


            return 0;
        }

        static short changeTheIniFile()
        {
            string myIniPath = systemPath + defaultMyiniPath;
            string iniContent=null;

            System.Console.Out.WriteLine("Post configuration started...");


            try
            {
                System.Console.Out.WriteLine("opening my.ini file from installed location");

                using (StreamReader sr = new StreamReader(myIniPath))
                {
                    iniContent = sr.ReadToEnd();
                };
                System.Console.Out.WriteLine(iniContent);

                if (iniContent.Contains("[mysqldump]"))
                {
                    iniContent = iniContent.Replace("[mysqldump]", "[mysqldump]\r\n\r\nmax_allowed_packet=1G \r\n \r\n");
                    iniContent = iniContent.Replace("[mysql]", "[mysql]\r\n\r\nmax_allowed_packet=1G \r\n \r\n");

                }
                else
                    iniContent = iniContent.Replace("[mysql]", "[mysqldump]\r\n\r\n max_allowed_packet=1G \r\n[mysql]\r\n max_allowed_packet=1G  \r\n \r\n ");

              //  if (instantType=="serverType")
                    iniContent = iniContent.Replace("[mysqld]", "[mysqld]\r\n\r\n max_allowed_packet=1G \r\n ");
              
              // if (instantType == "clientType")
                  //  iniContent = iniContent.Replace("[mysqld]", "[mysqld]\r\n\r\n max_allowed_packet=1G \r\n skip-networking\r\n  ");

                System.Console.Out.WriteLine(iniContent);

                
                System.Console.Out.WriteLine("writing my.ini file ....");


                using (StreamWriter sw = new StreamWriter(myIniPath))
                {
                    sw.Write(iniContent);
                };

                System.Console.Out.WriteLine("my.ini file changed successfully...");

            }catch(Exception ex)
            {
                System.Console.Out.WriteLine("error occured in changeTheIniFile() ....");
                System.Console.Out.WriteLine(ex.Message);

                return -1; 
            }

           return 0;

        }

        /// <summary>
        /// action=0 to stop the service
        /// action=1 to start the service
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        static short startOrStopMysqlService(short action)
        {
            short errorCode = 0;
            try
            {
                ServiceController sc = new ServiceController();
                sc.ServiceName = "mysql";
                 
                System.Console.Out.WriteLine("mysql service configuration started...");
                System.Console.Out.WriteLine("initial status of service:"+sc.Status.ToString());

                if (action == 0) //stop service
                {
                    if (!sc.Status.Equals(ServiceControllerStatus.Running))
                    {
                        sc.Start();
                        System.Threading.Thread.Sleep(5000);
                        if (sc.Status.Equals(ServiceControllerStatus.Running))
                            errorCode= 0;
                        else
                            errorCode = -1;
                    }
                    else
                    {
                        sc.Stop();
                        System.Threading.Thread.Sleep(5000);
                        if (sc.Status.Equals(ServiceControllerStatus.Stopped))
                            errorCode = 0;
                        else
                            errorCode = -1;

                    }
               

                }

                if (action == 1) //start service
                {

                    sc.Start();
                    System.Threading.Thread.Sleep(5000);
                    if (sc.Status.Equals(ServiceControllerStatus.Running))
                        errorCode = 0;
                    else
                        errorCode = -1;
 
                }

                sc.Refresh();
                System.Console.Out.WriteLine("Final status of service:"+sc.Status.ToString());
                return errorCode;

            }
            catch (Exception ex)
            {
                return -1;
            }
          
        }

        static void ss(short action)
        {
            short errorCode = 0;
            try
            {
                ServiceController sc = new ServiceController();
                sc.Refresh();
                sc.ServiceName = "mysql";

              
                System.Console.Out.WriteLine("initial status of service:" + sc.Status.ToString());

               
               
            }
            catch (Exception ex)
            {
                return ;
            }

        }

        #endregion mysql post configuration


        #region mysql initial configuration

        //configMySQL("mysql","1","DEVELOPMENT", "MIXED", "3306");
  
        static void configMySQL(string serviceName,string rootpassword, string serviceType, string databaseType, string port)
        {
            string parameter = null;

            ////if(instantType=="--serverType")
            ////    parameter = string.Format(" -i -q ServiceName={0} RootPassword={1} ServerType={2} DatabaseType={3} Port={4} wait_timeout=6000 StrictMode=yes ConnectionCount=20 Charset=utf8 max_allowed_packet=1G named_pipe=yes", serviceName, rootpassword, serviceType, databaseType, port);
            ////else
            ////    parameter = string.Format(" -i -q ServiceName={0} RootPassword={1} ServerType={2} DatabaseType={3} Port={4} wait_timeout=6000 StrictMode=yes  ConnectionCount=3 skip_networking=yes Charset=utf8 max_allowed_packet=1G", serviceName, rootpassword, serviceType, databaseType, port);

            if (instantType == "serverType")
                parameter = string.Format(" -i -q ServiceName={0} RootPassword={1} ServerType={2} DatabaseType={3} Port={4} wait_timeout=6000 StrictMode=yes ConnectionCount=20 SkipNetworking=no Charset=utf8 ConnectionUsage=DSS ", serviceName, rootpassword, serviceType, databaseType, port);
           
            if (instantType == "clientType")
                parameter = string.Format(" -i -q ServiceName={0} RootPassword={1} ServerType={2} DatabaseType={3} Port={4} wait_timeout=6000 StrictMode=yes  ConnectionCount=2 SkipNetworking=yes Charset=utf8 ConnectionUsage=DSS ", serviceName, rootpassword, serviceType, databaseType, port);


            //string parameter = string.Format(" -i -q ServiceName={0} RootPassword={1} ServerType={2} DatabaseType={3} Port={4} wait_timeout=6000 default-character-set=utf8 max_allowed_packet=1G", serviceName, rootpassword, serviceType, databaseType, port);
            
            doConfigMySQL(parameter, rootpassword);
        }
        
       /// <summary>
       /// we need old password in case reconfiguration is required!
       /// bool falgConfig=false
       /// </summary>
       /// <param name="parameter"></param>
       /// <param name="oldPassword"></param>
       
     
        
        static void doConfigMySQL(string parameter,string oldPassword)
        {
                  
            if (flagConfig == true) return;

            System.Console.Out.WriteLine("mysql initial configuration ....");

            System.IO.FileInfo fi = new System.IO.FileInfo(fullConfigPath);
            if (!fi.Exists)
            {
                System.Console.Out.WriteLine("Binary Location not found!");
                System.Console.Out.WriteLine("Please contact administrator!");
                return;
            }

            System.Console.Out.WriteLine("Binary Location found!");

            ProcessStartInfo _process = new ProcessStartInfo(fullConfigPath, parameter);
            _process.LoadUserProfile = true;

            _process.RedirectStandardError = true;
            _process.UseShellExecute = false;
            _process.WindowStyle = ProcessWindowStyle.Hidden;
            _process.CreateNoWindow = true;

            Process p = null;
            try
            {
                System.Console.Out.WriteLine("Process Started configuration...");
                
                p = Process.Start(_process);
                string er = p.StandardError.ReadToEnd();
              //  p.ErrorDataReceived += (x, y) => MessageBox.Show(y.Data);
                System.Console.Out.WriteLine("Please wait...(will take 15 seconds)");
                p.WaitForExit(10000); //wati 15 sec inorder service started

                System.Console.Out.WriteLine("Process Finished its job, waiting for service to be started...!");

                if (er != "")
                { parameter = parameter + "  RootCurrentPassword=" + oldPassword + ""; doConfigMySQL(parameter, oldPassword); flagConfig = true; }

                System.Console.Out.WriteLine("No Error Found!");
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine("exception occured in doConfigMySQL funciton");
                System.Console.Out.WriteLine(ex.Message);


                parameter = parameter + "  RootCurrentPassword=" + oldPassword + ""; doConfigMySQL(parameter, oldPassword);
                flagConfig = true;
              // MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (p != null)
                {
                    p.Dispose();
                }
            }
           
        }

       #endregion mysql initial configuration


        #region mysql privileges

        static void setMysqlUserPrivileges(string arguement)
        {
         //   mysql -uroot -ppass -e "GRANT SELECT,INSERT,UPDATE, DELETE,CREATE,DROP,ALTER ON nwdicdad2.* TO root@'localhost' IDENTIFIED by 'pass';"
            //mysqlPassword

           // ex = {"Access denied for user 'root'@'192.168.2.5' (using password: YES)"}
         
           // string[] excp = arguement.Split('#');
            //string parameter = string.Format(" -h {0}  -uroot -p{1} -e \"GRANT ALL PRIVILEGES ON nwdicdad2.* TO '{2}'@'{3}' IDENTIFIED by '{4}' with grant option;\" ", excp[2], mysqlPassword, excp[1], excp[2], mysqlPassword);
            string parameter = string.Format(" -uroot -p{0} -e \"GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' IDENTIFIED by '{1}' with grant option;\" ", mysqlPassword, mysqlPassword);
            string mysqlexePath = systemPath + defaultBinPath + "mysql.exe";

            //System.Console.Out.WriteLine(parameter);

            System.IO.FileInfo fi = new System.IO.FileInfo(mysqlexePath);
            if (!fi.Exists)
            {
                System.Console.Out.WriteLine("Binary Location not found!");
                System.Console.Out.WriteLine("Please contact administrator!");
                System.Console.In.ReadLine();
                return;
            }

            System.Console.Out.WriteLine("Binary Location found!");

            ProcessStartInfo _process = new ProcessStartInfo(mysqlexePath, parameter);
            _process.LoadUserProfile = true;

            _process.RedirectStandardError = true;
            _process.UseShellExecute = false;
            _process.WindowStyle = ProcessWindowStyle.Hidden;
            _process.CreateNoWindow = true;

            Process p = null;
            try
            {
                System.Console.Out.WriteLine("Process Started setting user privileges...");

                p = Process.Start(_process);
                string er = p.StandardError.ReadToEnd();
                //  p.ErrorDataReceived += (x, y) => MessageBox.Show(y.Data);
                System.Console.Out.WriteLine("Please wait...");
                p.WaitForExit(); //wati 15 sec inorder service started

                if (er == "")
                   System.Console.Out.WriteLine("No Error Found!");
                else
                    System.Console.Out.WriteLine("Error Found!"+er);
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine("exception occured in setting privileges");
                System.Console.Out.WriteLine(ex.Message);
            }
            finally
            {
                if (p != null)
                {
                    p.Dispose();
                }
            }
           // System.Console.In.ReadLine();
      }




        #endregion mysql privileges



    }
}
