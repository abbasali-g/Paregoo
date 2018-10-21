using System;
using System.Collections.Generic;
 
using System.Text;
using System.IO;
using System.Reflection;

namespace Lawyer.Common.CS.Common
{
    public class DefaultValues
    {
        public static String DefaultUser = "root";

        public static String DefaultPass = "@@%!mysqlnahani";
        public static String DefaultPort = "9918";

       public static String DefaultIP = "127.0.0.1";

       public static String backupPath = "C:\\nwdic\\InitialDatabase.zip";
       public static String UnzipPath = "C:\\nwdic\\";
       public static String RestorePath = "C:\\nwdic\\InitialDatabase.nbk";
       public static String RestoreLawPath = "C:\\nwdic\\InitialDatabaseLaws.nbk";
       
       public static String AutoConfigExe = App_ParentDir() + "\\ConfigMysql.exe";

        public static String Key = "1213214532123454";

        public static String updateTemplate = App_ParentOuterPath() + "\\UpdateTemplate";

        public static String App_ParentDir()
        {
            string dPath = string.Empty;

            try
            {
                dPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            }
            catch (Exception)
            {

                dPath = string.Empty;
            }
            return dPath;

        }

        public static String App_ParentOuterPath()
        {
            string dPath = string.Empty;

            try
            {
                dPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[2]) + "\\DefaultFolders";

                if (!System.IO.Directory.Exists(dPath))

                    System.IO.Directory.CreateDirectory(dPath);
            }
            catch (Exception)
            {


            }
            return dPath;

        }

        public static String App_ParentInnerPath()
        {
            string dPath = string.Empty;

            try
            {
                dPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\DefaultFolders";

                if (!System.IO.Directory.Exists(dPath))

                    System.IO.Directory.CreateDirectory(dPath);
            }
            catch (Exception)
            {


            }
            return dPath;

        }

    }
}
