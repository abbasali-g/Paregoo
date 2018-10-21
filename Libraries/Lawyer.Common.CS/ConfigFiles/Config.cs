using System;
using System.Collections.Generic;
 
using System.Text;
using System.Xml;
using System.IO;
namespace Lawyer.Common.CS.ConfigFile
{
    
   public  class Config
    {
        public enum ConfigSatus
        {

            corrupt = 0, nOConfig = 1, Complete=2, DefaultPass=3, DefaultMySql=4, CreateNwdicdad2=5, Unknown=6, Manual=7 , ManualSql=8

        }

        private string key = "1213214532123454";
        private string _Port;
        private string _LPort;
        private string _UserName;
        private string _LUserName;
        private string _Password;
        private string _LPassword;
        private string _IP;
        private string _LIP;
        private string _BackupLocation;
        private ConfigSatus _status;
        private string ConfigPath;
        private bool _Decrypt;



        public string LPort
        {
            get
            {
                return _LPort;
            }
            set
            {
                if (Decrypt)
                    _LPort = Common.SecurityHelper.Decrypt(value, key);
                else
                    _LPort = value;
            }
        }

        public string LIP
        {
            get
            {
                return _LIP;
            }
            set
            {
                if (Decrypt)
                    _LIP = Common.SecurityHelper.Decrypt(value, key);
                else
                    _LIP = value;
            }
        }

        public string LUserName
        {
            get
            {
                return _LUserName;
            }
            set
            {
                if (Decrypt)
                    _LUserName = Common.SecurityHelper.Decrypt(value, key);
                else
                    _LUserName = value;
            }
        }

        public string LPassword
        {
            get
            {
                return _LPassword;
            }
            set
            {
                if (Decrypt)
                    _LPassword = Common.SecurityHelper.Decrypt(value, key);
                else
                    _LPassword = value;

            }
        }

        public string Port
        {
            get
            {
                return _Port;
            }
            set
            {
                if (Decrypt)
                     _Port =   Common.SecurityHelper.Decrypt(value, key);
                else
                    _Port =value ;
            }
        } 

        public bool Decrypt
        {
            get
            {
                return _Decrypt;
            }
            set
            {
                _Decrypt = value;
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                if (Decrypt)
                    _UserName = Common.SecurityHelper.Decrypt(value, key);
                else
                    _UserName = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (Decrypt)
                    _Password = Common.SecurityHelper.Decrypt(value, key);
                else
                    _Password = value;

            }
        }
       
        public string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                if (Decrypt)
                    _IP = Common.SecurityHelper.Decrypt(value, key);
                else
                    _IP = value;
            }
        }      

        public ConfigSatus  Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public string BackupLocation
        {
            get
            {
                return _BackupLocation;
            }
            set
            {
                _BackupLocation = value;
            }
        }

        public bool IsEmptyConfig()
        {
            if (string.IsNullOrEmpty(_IP) || string.IsNullOrEmpty(_Port) || string.IsNullOrEmpty(_Password) || string.IsNullOrEmpty(_UserName))
                return true;
            return false;

        }

        public string  Encrypt( string  str)
        {
            return Common.SecurityHelper.Encrypt(str, key);
        }

        public Config()
        {
        }

        public Config(string ip,string port,string user, string pass)
        {
            _Port = port;
            _IP = ip;
            _UserName = user;
            _Password = pass;
        }
        
        public Config(string filePath)
        {
            ConfigPath = filePath;
        }

        //**************************************************************
        // Load()	
        //**************************************************************

        public static Config  Load(string filePath)
        {

            try
            {
                if (!File.Exists(filePath))
                {
                    CreateDefultXml(filePath);
                }
                Config Config = new Config(filePath);

                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.Load(filePath);               
                Config.Decrypt = true;
                try
                {
                    XmlNode AppStatusNode = XmlDoc.SelectSingleNode(@"//S");
                    Config.Status = (ConfigSatus)Enum.Parse(typeof(ConfigSatus), AppStatusNode.InnerText, true);

                }

                catch (Exception)
                {
                    Config.Status = ConfigSatus.corrupt;

                }

                Config.IP = XmlDoc.SelectSingleNode(@"//I").InnerText;

                Config.Port = XmlDoc.SelectSingleNode(@"//PO").InnerText;

                Config.UserName = XmlDoc.SelectSingleNode(@"//U").InnerText;

                Config.Password = XmlDoc.SelectSingleNode(@"//P").InnerText;

                Config.BackupLocation = XmlDoc.SelectSingleNode(@"//BL").InnerText;

                Config.LIP = XmlDoc.SelectSingleNode(@"//IL").InnerText;

                Config.LPort = XmlDoc.SelectSingleNode(@"//POL").InnerText;

                Config.LUserName = XmlDoc.SelectSingleNode(@"//UL").InnerText;

                Config.LPassword = XmlDoc.SelectSingleNode(@"//PL").InnerText;


                return Config;
            }
            catch (Exception)
            {

                return null;
            }
           
        }

        //**************************************************************
        // create Default config	
        //**************************************************************

        public static Config CreateDefultXml(string filePath)
        {
            string k = "1213214532123454";
            XmlDocument XmlDoc = new XmlDocument();

            XmlElement Root = XmlDoc.CreateElement("Config");
            XmlDoc.AppendChild(Root);

            XmlElement XmlElem = XmlDoc.CreateElement("S");
            XmlElem.InnerText = "0";
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("I");
            XmlElem.InnerText = Common.SecurityHelper.Encrypt(Common.DefaultValues.DefaultIP , k);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("PO");
            XmlElem.InnerText = Common.SecurityHelper.Encrypt(Common.DefaultValues.DefaultPort , k); 
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("U");
            XmlElem.InnerText = Common.SecurityHelper.Encrypt(Common.DefaultValues.DefaultUser , k);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("P");
            XmlElem.InnerText = Common.SecurityHelper.Encrypt(Common.DefaultValues.DefaultPass, k);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("BL");
            XmlElem.InnerText = "D:\\";
            Root.AppendChild(XmlElem);


            XmlElem = XmlDoc.CreateElement("IL");
            XmlElem.InnerText = Common.SecurityHelper.Encrypt(Common.DefaultValues.DefaultIP, k);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("POL");
            XmlElem.InnerText = Common.SecurityHelper.Encrypt(Common.DefaultValues.DefaultPort, k);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("UL");
            XmlElem.InnerText = Common.SecurityHelper.Encrypt(Common.DefaultValues.DefaultUser, k);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("PL");
            XmlElem.InnerText = Common.SecurityHelper.Encrypt(Common.DefaultValues.DefaultPass, k);
            Root.AppendChild(XmlElem);

            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

                if (fileInfo.IsReadOnly)
                    fileInfo.IsReadOnly = false;
            }
            catch (Exception)
            {                
              
            }
           

             XmlDoc.Save(filePath);

              return Load(filePath);
        }

        //**************************************************************
        // Update()	
        //**************************************************************
        public void Udpate()
        {

             XmlDocument XmlDoc = new XmlDocument();

            XmlElement Root = XmlDoc.CreateElement("Config");
            XmlDoc.AppendChild(Root);

            XmlElement XmlElem = XmlDoc.CreateElement("S");
            XmlElem.InnerText = Convert.ToInt32( Status ).ToString();
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("I");
            XmlElem.InnerText = Encrypt(IP);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("PO");
            XmlElem.InnerText = Encrypt(Port );
            Root.AppendChild(XmlElem);

             XmlElem = XmlDoc.CreateElement("U");
             XmlElem.InnerText = Encrypt(UserName );
            Root.AppendChild(XmlElem);

             XmlElem = XmlDoc.CreateElement("P");
             XmlElem.InnerText = Encrypt(Password );
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("BL");
            XmlElem.InnerText = BackupLocation ;
            Root.AppendChild(XmlElem);


            XmlElem = XmlDoc.CreateElement("IL");
            XmlElem.InnerText = Encrypt(LIP);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("POL");
            XmlElem.InnerText = Encrypt(LPort);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("UL");
            XmlElem.InnerText = Encrypt(LUserName);
            Root.AppendChild(XmlElem);

            XmlElem = XmlDoc.CreateElement("PL");
            XmlElem.InnerText = Encrypt(LPassword);
            Root.AppendChild(XmlElem);
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(ConfigPath);

                if (fileInfo.IsReadOnly)
                    fileInfo.IsReadOnly = false;
            }
            catch (Exception)
            {

            }
            
            XmlDoc.Save(ConfigPath);

        }
    }
}
