using System;
using System.Collections.Generic;
 
using System.Text;
using MySql.Data.MySqlClient;
using DbAccessLayer;
using System.Data;
using System.IO;

namespace Lawyer.Common.CS.Update
{
    public class UpdateManager
    {

        private static String _ConnectionString;

        public static void SetConnection(string connection)
        {
            _ConnectionString = connection;
        }

        public static String ConnectionString()
        {
            try
            {

                return _ConnectionString;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static bool IsNewVersionAccesible(UpdateType versionType, int curversion, String connection)
        {
            MySqlParameter[] param = new MySqlParameter[2];

            param[0] = new MySqlParameter("_updVersion", curversion);

            param[1] = new MySqlParameter("_updDescription", versionType.ToString());

            DbAccessLayer.MySqlDbAccess db = new MySqlDbAccess(connection, ConnectionStringSourceType.MySetting);

            long version = (long)db.GetScalarFromProcedure("stpDad_updateUtiIsExistNewVer", param);

            if (db.HasError)
                throw db.ErrorException;

            if (version > 0)

                return true;

            return false;

        }

        public static Nullable<int> GetLastVersionDownloaded(UpdateType ut)
        {
            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("_updDescription", ut.ToString());

            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            System.Data.IDataReader reader = db.GetDataReaderFromProcedure("stpDadupdateSelLastVerDownloaded", param);

            Nullable<int> result = null;

            if (db.HasError) throw db.ErrorException;

            if (reader.Read())
            {
                result = DbAccessLayer.MySqlDataHelper.GetNullableInt(reader, "updVersion");
            }

            reader.Close();

            return result;

        }

        public static string GetUpdateUrl()
        {

            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            System.Data.IDataReader reader = db.GetDataReaderFromProcedure("stpDad_settingsSelUpdateUrl");

            string url = string.Empty;

            if (db.HasError) return string.Empty;

            if (reader.Read())
            {
                url = DbAccessLayer.MySqlDataHelper.GetString(reader, "settingValue");
            }
            reader.Close();
            return url;

        }

        public static string GetFTPPass()
        {

            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            System.Data.IDataReader reader = db.GetDataReaderFromProcedure("stpDad_SettingSelFtpPas");

            string url = string.Empty;

            if (db.HasError) return string.Empty;

            if (reader.Read())
            {
                url = DbAccessLayer.MySqlDataHelper.GetString(reader, "settingValue");
            }
            return url;

        }

        public static string GetFTPUse()
        {

            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            System.Data.IDataReader reader = db.GetDataReaderFromProcedure("stpDad_settingsSelFtpUse");

            string url = string.Empty;

            if (db.HasError) return string.Empty;

            if (reader.Read())
            {
                url = DbAccessLayer.MySqlDataHelper.GetString(reader, "settingValue");
            }
            return url;

        }

        public static void SaveDownloadedFile(string versionDesc, string newVersion, string filepath)
        {

            MySqlParameter[] param = new MySqlParameter[6];

            param[0] = new MySqlParameter("_updId", Guid.NewGuid());

            param[1] = new MySqlParameter("_versionDesc", versionDesc);

            param[2] = new MySqlParameter("_updVersion", newVersion.Replace(".", ""));

            param[3] = new MySqlParameter("_updContent", Lawyer.Coding.FileManager.GetFileInBinaryFormat(filepath));

            param[4] = new MySqlParameter("_updVersionName", newVersion);

            param[5] = new MySqlParameter("_updFileName", System.IO.Path.GetFileNameWithoutExtension(filepath));


            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            db.ExecuteProcedure("stpDad_updateDownloadFile", param);

            if (db.HasError) throw db.ErrorException;

        }

        public static string CheckFileHasDownloaded(UpdateType ut, int curversion)
        {

            MySqlParameter[] param = new MySqlParameter[2];

            param[0] = new MySqlParameter("_updDescription", ut.ToString());
            param[1] = new MySqlParameter("_curVersion", curversion);


            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            //db.ExecuteProcedure("stpDad_updateHasDownloadedBefore", param);
            string  result = db.GetScalarFromProcedure("stpDad_updateHasDownloadedBefore", param).ToString();
          if (db.HasError) throw db.ErrorException;

            return result;

        }

        public static void ReadyUpdate(string upId)
        {

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("_updId", upId);

            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            db.ExecuteProcedure("stpDad_updateReady", param).ToString();

            if (db.HasError) throw db.ErrorException;

        }

        public static string GetLastVersion(UpdateType ut)
        {
            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("_updDescription", ut.ToString());

            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            System.Data.IDataReader reader = db.GetDataReaderFromProcedure("stpDad_updateSelLastVersion", param);

            string result = string.Empty;

            if (db.HasError) throw db.ErrorException;

            if (reader.Read())
            {
                result = DbAccessLayer.MySqlDataHelper.GetString(reader, "updVersionName");
            }

            reader.Close();

            return result;

        }             

        public static string[] GetNewFileDownloadedContent(UpdateType ut, int curVersion)
        {
            MySqlParameter[] param = new MySqlParameter[2];

            byte[] content = null;

            string[] result =new string[3];

            param[0] = new MySqlParameter("_updDescription", ut.ToString() );

            param[1] = new MySqlParameter("_curVersion", curVersion);

            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            System.Data.IDataReader reader = db.GetDataReaderFromProcedure("stpDad_updateSelFileContent", param);

            if (db.HasError) throw db.ErrorException;

            string url = string.Empty;

            if (reader.Read())
            {
                content = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "updContent");
                result[1] = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "updId").ToString();
                result[0] = DbAccessLayer.MySqlDataHelper.GetString(reader, "updFileName");
                result[2] = DbAccessLayer.MySqlDataHelper.GetString(reader, "updVersionName");
            }

            reader.Close();

            if (content != null && content.Length > 0)
            {
                if (ut == UpdateType.d)
                {
                    if (Directory.Exists(Common.DefaultValues.updateTemplate))
                    {
                        Directory.Delete(Common.DefaultValues.updateTemplate, true);
                    }
                    Directory.CreateDirectory(Common.DefaultValues.updateTemplate);

                    string filePath = Common.DefaultValues.updateTemplate + "\\" + result[0];

                    Lawyer.Coding.FileManager.GetFileFromZipBinaryFormat(content, System.IO.Path.ChangeExtension(filePath, ".zip"), true);

                    result[0] = System.IO.Path.ChangeExtension(filePath, ".txt");

                    return result;
                }

                if (ut == UpdateType.s)
                {
                    if (Directory.Exists(Common.DefaultValues.updateTemplate))
                    {
                        Directory.Delete(Common.DefaultValues.updateTemplate, true);
                    }
                    Directory.CreateDirectory(Common.DefaultValues.updateTemplate);

                    string filePath = Common.DefaultValues.updateTemplate + "\\" + result[0];

                    Lawyer.Coding.FileManager.GetFileFromZipBinaryFormat(content, System.IO.Path.ChangeExtension(filePath, ".zip"), true);

                    result[0] = System.IO.Path.ChangeExtension(filePath, ".txt");

                    return result;
                }
            }


            return null;
        }

        public static void RunScript(string content)
        {
            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting);

            db.ExecuteSqlCommandText(content);

            if (db.HasError) throw db.ErrorException;
        }
           
        public static UpdateReview GetNewVersionFiles(Int32 curVersion, String connection)
        {
      
            MySqlParameter[] param=new MySqlParameter[2];

            param[0] = new MySqlParameter("_versionDesc", 'c');

            param[1] = new MySqlParameter("_Curver", curVersion);

           UpdateReview u = null;

            DbAccessLayer.MySqlDbAccess db=new MySqlDbAccess(connection, ConnectionStringSourceType.MySetting);

            IDataReader reader = db.GetDataReaderFromProcedure("stpDad_updateSelCurrentVersion", param);

            if (db.HasError) 

                throw db.ErrorException ;
            
            if( reader.Read())
            {
                u = GetUpdateReviewFromReader(reader);

            }
            reader.Close();

            return u;


        }

        private static UpdateReview GetUpdateReviewFromReader(IDataReader reader)
        {

            if (reader == null)
                return null;

            UpdateReview param = new UpdateReview();

            param.updContent = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "updContent");

            param.updVersion = DbAccessLayer.MySqlDataHelper.GetInt(reader, "updVersion");

            param.updVersionName = DbAccessLayer.MySqlDataHelper.GetString(reader, "updVersionName");

            param.updFileName = DbAccessLayer.MySqlDataHelper.GetString(reader, "updFileName");

            return param;
          
        }
                 
        public static  Int32 GetCurrentVersion(Char versionType , String connection)
        {
             MySqlParameter[] param=null;

             param[0]=new  MySqlParameter("_versionDesc", versionType);

             DbAccessLayer.MySqlDbAccess db=new MySqlDbAccess(connection, ConnectionStringSourceType.MySetting);
                       
            Int32 version=(Int32)db.GetScalarFromProcedure("stpDad_updateSelCurrentVersion", param);

             if (db.HasError) 
                throw db.ErrorException ;
            
            return version;


        }
              

     
    }
}
