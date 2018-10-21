using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;

namespace Lawyer.Common.CS.Update
{
   public  class Downloader
    {

       private static void SetVariable(bool IsCorrectUpdate)
       {
           if (IsCorrectUpdate)

               UpdateStatus.IsExistNewVersion = true;

           else
           {
               UpdateStatus.IsExistNewVersion = true;
               UpdateStatus.LastVersion = string.Empty;
               UpdateStatus.LastVersionName = string.Empty;
           }
       }
       
       public static bool IsNewVersionAccesible(string curVersion1,string connection)
       {
          
           try 
	        {
                return UpdateManager.IsNewVersionAccesible(UpdateType.c, Convert.ToInt32(curVersion1.Replace(".", "")), connection);
        
	        }
	        catch (Exception)
	        {
        		
		       return false;
	        }

          
       }

       public static ResultUpdate Download(string curVersion1, string downloadedFilePath, string tempLawyerfolderPath, string connection, System.Windows.Forms.TextBox lblProcess, System.Windows.Forms.TextBox txtError)
        {

            try
            {
                int curVersion = Convert.ToInt32(curVersion1.Replace(".", ""));

                UpdateStatus.LastVersion = string.Empty;
                UpdateStatus.IsExistNewVersion = false;
                UpdateStatus.LastVersionName = string.Empty;
                UpdateStatus.RestartApp = false; // در صورتی که کاربر دکمه بلی را برای انجام عمل بروز رسانی کلیک کند ===>  true
                UpdateStatus.CanClose = true;
                if (UpdateStatus.CloseClick)
                    return ResultUpdate.exit;

                lblProcess.Text = "در حال دریافت اطلاعات از سرور ....";
                txtError.Text = string.Empty;
                string zipFilepath = string.Empty;

                try
                {
                    zipFilepath = IsServerVersionNewer(curVersion, downloadedFilePath, connection);
                }
                catch (Exception)
                {
                    SetVariable(false);

                    txtError.Text = "خطا در بروز رسانی نرم افزار  ===> " + "خطا در دانلود فایل ";
                    lblProcess.Text = string.Empty;

                    return ResultUpdate.fatal;

                }

                if (UpdateStatus.CloseClick)
                    return ResultUpdate.exit;

                UpdateStatus.CanClose = false;

                if (zipFilepath == string.Empty)
                {

                    SetVariable(false);

                    lblProcess.Text = " نرم افزار  بروز می باشد ....";
                    txtError.Text = string.Empty;
                    return ResultUpdate.uptodate;
                }

                if (downloadedFilePath != string.Empty)
                {
                    lblProcess.Text = "در حال بروز رسانی نسخه نرم افزار  ....";

                    try
                    {
                        Unzip(zipFilepath, tempLawyerfolderPath);
                    }
                    catch (Exception)
                    {

                        SetVariable(false);

                        txtError.Text = "خطا در بروز رسانی نرم افزار  ===> " + "خطا در unzip فایل ";
                        lblProcess.Text = string.Empty;
                        return ResultUpdate.fatal;
                    }

                    try
                    {
                        MergeDirectory(downloadedFilePath, tempLawyerfolderPath);
                    }
                    catch (Exception)
                    {
                        SetVariable(false);

                        txtError.Text = "خطا در بروز رسانی نرم افزار ===> " + "خطا در merge  ";
                        lblProcess.Text = string.Empty;
                        return ResultUpdate.fatal;
                    }
                    SetVariable(true);

                    lblProcess.Text = "نسخه پایگاه داده به " + UpdateStatus.LastVersion + " ارتقاء یافت.... ";
                    txtError.Text = string.Empty;
                    return ResultUpdate.update;

                }

                else
                {
                    SetVariable(false);

                    txtError.Text = "خطا در بروز رسانی نرم افزار  ===> " + "خطا درمحل دانلود  ";
                    lblProcess.Text = string.Empty;
                    return ResultUpdate.fatal;
                }  
           
            }
            catch (Exception)
            {

                SetVariable(false);

                txtError.Text = "خطا در بروز رسانی نرم افزار ...." ;
                lblProcess.Text = string.Empty;
                return ResultUpdate.fatal;
            }
            
        }

        //**************************************************************
        // در صورتی که ورژن جدید موجود باشد باشد
	    //  در اینصورت فایل ارسالی که در قالب 
        // zip
        // می باشد در پوشه 
        //lawyer
        //نوشته می شود
        //**************************************************************
        
        private static string   IsServerVersionNewer(int curversion , string filepath, string Connection)
        {

            MySqlParameter[] param = new MySqlParameter[2];

            byte[] content = null;

            string[] result = new string[3];

            param[0] = new MySqlParameter("_updDescription", 'c');

            param[1] = new MySqlParameter("_curVersion", curversion);

            DbAccessLayer.MySqlDbAccess db = new DbAccessLayer.MySqlDbAccess(Connection, DbAccessLayer.ConnectionStringSourceType.MySetting);

            System.Data.IDataReader reader = db.GetDataReaderFromProcedure("stpDad_updateSelFileContent", param);

            if (db.HasError) throw db.ErrorException;

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
                UpdateStatus.LastVersion = result[2];

                filepath += "\\" + result[0] + ".zip";

                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                Lawyer.Coding.FileManager.GetFileFromBinaryFormat(content, filepath, true);

                return filepath;
            }

            return string.Empty;   
        }

        //**************************************************************
        //unzip file
        //**************************************************************
        private static void Unzip(string sourcepath , string targetpath)
        {
            //برای پاک کردن محتوای پوشه
            if (Directory.Exists(targetpath))
             Directory.Delete (targetpath,true);

             Directory.CreateDirectory(targetpath);

            Ionic.Zip.ZipFile oZipFile = new Ionic.Zip.ZipFile(sourcepath);

            oZipFile.ExtractAll(targetpath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);

            oZipFile.Dispose();

            File.Delete(sourcepath);

        }

        //**************************************************************
        //merge two directory
        //**************************************************************
        private static void MergeDirectory(string source, string destination)
        {
              DirectoryInfo Source = new DirectoryInfo(source);

                
                FileInfo[] Files = Source.GetFiles();

                foreach (FileInfo pFile in Files)
                {
                    if (!File.Exists(Path.Combine(destination, pFile.Name)))
                        pFile.CopyTo(Path.Combine(destination, pFile.Name), true);
                }

                //برای کپی تمامی زیر دایرکتوریها
                DirectoryInfo[] Directories = Source.GetDirectories();

                foreach (DirectoryInfo pDirectory in Directories)
                {
                    if (!Directory.Exists(Path.Combine(destination, pDirectory.Name)))
                    {
                        Directory.CreateDirectory(Path.Combine(destination, pDirectory.Name));
                    }
                    MergeDirectory(Path.Combine(source, pDirectory.Name), Path.Combine(destination, pDirectory.Name));

                }
            }
            
    }
}
