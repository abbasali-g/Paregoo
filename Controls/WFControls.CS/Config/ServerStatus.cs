using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace WFControls.CS.Config
{
    public partial class ServerStatus : UserControl
    {                        
        public ServerStatus()
        {
            InitializeComponent();
        }

        private static bool IsCorrectConnection(Lawyer.Common.CS.ConfigFile.Config  c)
        {
            if (c == null)
                return false;

            MySqlConnection con = new MySqlConnection(string.Format("server={0};Port={1};uid={2}; pwd={3};database=mysql;", c.IP, c.Port, c.UserName, c.Password));

            try
            {
                con.Open();
                con.Close();
                return true;

            }
            catch (Exception)
            {

                con.Close();
                return false;

            }
        }

        private static bool IsServiceRuning()
        {
            try
            {
                ServiceController sc = new ServiceController();

                sc.ServiceName = "mysql";

                sc.Refresh();

                if (sc.Status.Equals(ServiceControllerStatus.Running))
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
                
            }

           
        }

        public void ShowStatus(Lawyer.Common.CS.ConfigFile.Config c)
        {
            
            try
            {

                btnConfig.Text = "";

                BtnRun.Text = "";

                btnRestore.Text = "";

                ToolTip1.SetToolTip(btnConfig, "پیکربندی نشده");

                ToolTip1.SetToolTip(BtnRun, "Stop");

                ToolTip1.SetToolTip(btnRestore, "نصب نشده");

                 btnConfig.Image = global::WFControls.CS.Properties.Resources.noConnect;

                btnRestore.Image = global::WFControls.CS.Properties.Resources.noInstalData24;

                if (IsServiceRuning())
                {
                    ToolTip1.SetToolTip(BtnRun, "Run");

                    BtnRun.Image = global::WFControls.CS.Properties.Resources.Signal24;

                    if (IsCorrectConnection(c))
                    {
                        btnConfig.Image = global::WFControls.CS.Properties.Resources.Connect;

                        ToolTip1.SetToolTip(btnConfig, "پیکربندی شده");

                        CreateDataBase(c);

                        if (IsInstallDataBase(c))
                        {

                            if (IsAttachDataBase(c))
                            {
                                ToolTip1.SetToolTip(btnRestore, "نصب شده");
                                btnRestore.Image = global::WFControls.CS.Properties.Resources.InstallData24;
                            }

                        }

                    }

                }
                else
                {
                    //ایا نصب شده است
                    string defaultMySqlPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\" + "MySQL\\MySQL Server 5.1\\bin\\MySQLInstanceConfig.exe";

                    if (System.IO.File.Exists(defaultMySqlPath))
                    {
                        BtnRun.Image = global::WFControls.CS.Properties.Resources.nosignal24;
                        ToolTip1.SetToolTip(BtnRun, "Stop");
                    }

                    else
                    {
                        BtnRun.Image = global::WFControls.CS.Properties.Resources.nosignal24_u;
                        ToolTip1.SetToolTip(BtnRun, "نصب نشده");
                    }


                }

            }
            catch (Exception)
            {
               
            }
         
           
                }

        private static bool IsInstallDataBase(Lawyer.Common.CS.ConfigFile.Config c)
        {
            MySqlConnection con = new MySqlConnection(string.Format("server={0};Port={1};uid={2}; pwd={3};database=nwdicdad2;", c.IP, c.Port, c.UserName, c.Password));
            try
            {
                con.Open();
                con.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        private static bool IsAttachDataBase(Lawyer.Common.CS.ConfigFile.Config c)
        {
            MySqlConnection con = new MySqlConnection(string.Format("server={0};Port={1};uid={2}; pwd={3};database=mysql;", c.IP, c.Port, c.UserName, c.Password));

            MySqlCommand com = new MySqlCommand("select count(*) from `information_schema`.`TABLES` where  table_schema='nwdicdad2';", con);

            try
            {
                con.Open();

                long count = (long)com.ExecuteScalar();

                if (count >=25)
                {
                    com.CommandText = "select count(*) from `information_schema`.`ROUTINES` where  routine_schema='nwdicdad2';";
                    count = (long)com.ExecuteScalar();
                    con.Close();
                    if (count > 200)
                        return true;
                    else
                        return false;

                }
                else

                   con.Close();               

                return false ;

            }
            catch (Exception)
            {

                return false;
            }
           
        }

        private static bool CreateDataBase(Lawyer.Common.CS.ConfigFile.Config c)
        {

            MySqlConnection con = new MySqlConnection(string.Format("server={0};Port={1};uid={2}; pwd={3};database=mysql;", c.IP, c.Port, c.UserName, c.Password));

            MySqlCommand com = new MySqlCommand("CREATE  SCHEMA IF NOT EXISTS nwdicdad2   COLLATE ='utf8_persian_ci'", con);
            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void ShowDataBaseStatus(Lawyer.Common.CS.ConfigFile.Config c)
        {
           
            try
            {
                ToolTip1.SetToolTip(btnRestore, "نصب نشده");

                btnRestore.Image = global::WFControls.CS.Properties.Resources.noInstalData24;

               if (IsCorrectConnection(c))
                {
                    btnConfig.Image = global::WFControls.CS.Properties.Resources.Connect;

                    CreateDataBase(c);

                    if (IsInstallDataBase(c))
                    {

                        if (IsAttachDataBase(c))
                        {
                            ToolTip1.SetToolTip(btnRestore, "نصب شده");

                            btnRestore.Image = global::WFControls.CS.Properties.Resources.InstallData24;
                        }

                    }

                }
            }
            catch (Exception)
            {
                
              
            }
             
        }

   }
}
