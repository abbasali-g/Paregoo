using System;
using System.Collections.Generic;
 
using System.Text;
using System.Reflection;
using System.Net;

namespace Lawyer.Common.CS.Update
{
    public class InitialDownload
    {

        public delegate void DesignHandler(ResultUpdate ut);

        System.Windows.Forms.TextBox txtMessage;
        System.Windows.Forms.TextBox lblMessage;
        string dbVersion;
        string Cversion;
        ResultUpdate resultByInternet;

        public void SetBeforeUpdate(System.Windows.Forms.TextBox txtMessage, System.Windows.Forms.TextBox lblMessage, string connection, string dbVersion, String Cversion)
        {
            this.lblMessage = lblMessage;
            this.txtMessage = txtMessage;
            this.Cversion = Cversion;
            this.dbVersion = dbVersion;
            UpdateManager.SetConnection(connection);


        }

        public ResultUpdate DoUpdate()
        {
            try
            {

                bool hasUpdate = false;
                //برای آپدیت رکوردی وجود دارد
                if (UpdateDataBase(ref hasUpdate))
                    if (UpdateServer(ref hasUpdate))
                    {

                        if (hasUpdate)
                        {
                            lblMessage.Text = "عملیات بروز رسانی به اتمام رسید.";
                            
                            return ResultUpdate.update;
                        }
                        else
                        {
                            if (HasDownloaded(UpdateType.d, dbVersion, ref hasUpdate))
                                if (HasDownloaded(UpdateType.c, Cversion, ref hasUpdate))
                                {
                                    if (hasUpdate)
                                    {
                                        lblMessage.Text = "عملیات بروز رسانی به اتمام رسید.";
                                       
                                        return ResultUpdate.update;

                                    }
                                    else
                                    {
                                        //download new version
                                        if (downloadNewFile(UpdateType.d, dbVersion, ref hasUpdate))
                                        {
                                            if (downloadNewFile(UpdateType.c, Cversion, ref  hasUpdate))
                                            {
                                                lblMessage.Text = "عملیات بروز رسانی به اتمام رسید.";
                                               
                                                return ResultUpdate.update;
                                            }
                                        }

                                        
                                        return ResultUpdate.fatal;

                                    }

                                }

                            return ResultUpdate.fatal;
                        }
                    }
                return resultByInternet;

            }
            catch (Exception )
            {
                return ResultUpdate.fatal;
            }

        }

        private bool UpdateDataBase(ref  bool HasUpdate)
        {

            switch (IsReadyForUpdate(UpdateType.d, dbVersion))
            {
                case ResultUpdate.exit:

                    resultByInternet = ResultUpdate.exit;
                    return false;

                case ResultUpdate.update:

                    HasUpdate = true;
                    break;

                case ResultUpdate.fatal:
                    resultByInternet = ResultUpdate.fatal;

                    return false;

            }

            return true;

        }

        private bool UpdateServer(ref  bool HasUpdate)
        {
            switch (IsReadyForUpdate(UpdateType.c, Cversion))
            {

                case ResultUpdate.exit:

                    resultByInternet = ResultUpdate.exit;
                    return false;

                case ResultUpdate.update:
                    HasUpdate = true;
                    break;

                case ResultUpdate.fatal:

                    resultByInternet = ResultUpdate.fatal;
                    return false;

            }

            return true;

        }

        private bool HasDownloaded(UpdateType ut, string curVersion, ref  bool HasUpdate)
        {
            string result = UpdateManager.CheckFileHasDownloaded(ut, Convert.ToInt32(curVersion.Replace(".", "")));

            if (result != string.Empty)
            {
                UpdateStatus.CanClose = false;
                txtMessage.Text = "در حال آماده سازی نسخه جدید....";
                UpdateManager.ReadyUpdate(result);
                switch (ut)
                {
                    case UpdateType.d:
                        UpdateStatus.CanClose = true;
                        return UpdateDataBase(ref HasUpdate);
                    case UpdateType.c:
                        UpdateStatus.CanClose = true;
                        return UpdateServer(ref HasUpdate);
                }

            }

            return true;

        }

        public ResultUpdate IsReadyForUpdate(UpdateType ut, string lastVersion)
        {

            UpdateStatus.CanClose = true;

            if (UpdateStatus.CloseClick)
                return ResultUpdate.exit;

            switch (ut)
            {
                case UpdateType.d:

                    int curVersion = Lawyer.Common.Default.DefaultValue.DefaultDatabaseVI;

                    txtMessage.Text = "در حال بررسی نسخه پایگاه داده...";
                    lblMessage.Text = string.Empty;

                    try
                    {
                        curVersion = Convert.ToInt32(lastVersion.Replace(".", ""));

                    }
                    catch (Exception ex)
                    {

                        lblMessage.Text = "خطا در بروز رسانی پایگاه داده ===> " + ex.Message;
                        txtMessage.Text = string.Empty;
                        return ResultUpdate.fatal;
                    }

                    try
                    {
                        string[] result = UpdateManager.GetNewFileDownloadedContent(ut, curVersion);

                        if (result != null)
                        {
                            if (UpdateStatus.CloseClick)
                                return ResultUpdate.exit;

                            UpdateStatus.CanClose = false;

                            txtMessage.Text = "در حال بروز رسانی نسخه پایگاه داده...";

                            StringBuilder content = Lawyer.Coding.HsPublic.ReadTextFile(result[0]);

                            content.AppendLine(" UPDATE    `nwdicdad2`.`update`  SET              updIsCurrentVersion =0, updIsReady =1 where updIsCurrentVersion=1 and updIsReady =1 and updDescription='d';");
                            content.AppendLine(string.Format("UPDATE    `nwdicdad2`.`update`  SET   updIsCurrentVersion= 1, updIsReady =1 where updId='{0}';", result[1]));
                            
                            UpdateManager.RunScript(content.ToString());
                            System.IO.File.Delete(result[0]);

                            txtMessage.Text = "نسخه پایگاه داده به " + result[2] + " ارتقاء یافت.... ";
                            lblMessage.Text = string.Empty;
                            dbVersion = GetDBLastVersion();
                            return ResultUpdate.update;
                        }
                        else
                        {
                            txtMessage.Text = "نسخه پایگاه داده بروز می باشد ....";
                            lblMessage.Text = string.Empty;
                            return ResultUpdate.uptodate;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "خطا در بروز رسانی پایگاه داده ===> " + ex.Message;
                        txtMessage.Text = string.Empty;
                        return ResultUpdate.fatal;
                    }

                case UpdateType.c:

                    curVersion = Lawyer.Common.Default.DefaultValue.DefaultSoftVI;

                    txtMessage.Text = "در حال بررسی نسخه نرم افزار...";

                    try
                    {
                        curVersion = Convert.ToInt32(lastVersion.Replace(".", ""));
                    }
                    catch (Exception ex)
                    {

                        lblMessage.Text = "خطا در بروز رسانی نرم افزار  ===> " + ex.Message;
                        txtMessage.Text = string.Empty;
                        return ResultUpdate.fatal;
                    }

                    try
                    {
                       return Downloader.Download(curVersion.ToString(), System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Environment.GetCommandLineArgs()[3], UpdateManager.ConnectionString(), txtMessage ,lblMessage );
                                        
                    }
                    catch (Exception)
                    {
                        lblMessage.Text = "خطا در بروز رسانی نرم افزار ";
                        txtMessage.Text = string.Empty;
                        return ResultUpdate.fatal;
                    }

            }
            return ResultUpdate.fatal;
        }

        private bool downloadNewFile(UpdateType ut, string curVersion, ref  bool HasUpdate)
        {
            try
            {
                //قابل دسترس است
                System.Net.IPHostEntry objIPHE = System.Net.Dns.GetHostEntry("www.nwdic.com");
            }
            catch (Exception)
            {
                lblMessage.Text = " امکان بروز رسانی به دلیل عدم  اتصال به اینترنت وجود ندارد ...";
                txtMessage.Text = string.Empty;
                return false;
            }
            switch (downloadFile(ut))
            {
                case ResultUpdate.exit:
                    resultByInternet = ResultUpdate.exit;
                    return false;
                case ResultUpdate.uptodate:
                    return true;
                case ResultUpdate.update:
                    return HasDownloaded(ut, curVersion, ref HasUpdate);
                case ResultUpdate.fatal:
                    resultByInternet = ResultUpdate.fatal;
                    return false;
            }
            return false;
        }

        private ResultUpdate downloadFile(UpdateType ut)
        {

            string VersionName = " پایگاه داده  ";
            if (ut == UpdateType.c)
                VersionName = "کاربر  ";
            else if (ut == UpdateType.s)
                VersionName = " سرور  ";
            UpdateStatus.CanClose = true;

            if (UpdateStatus.CloseClick)
                return ResultUpdate.exit;
            txtMessage.Text = "در حال بررسی نسخه " + VersionName + "....";
            // گرفتن ورژن جاری
             Nullable<int> curVersion ;
            if (ut == UpdateType.c)
                    curVersion = Lawyer.Common.Default.DefaultValue.DefaultSoftVI;
            else
            {
                curVersion = UpdateManager.GetLastVersionDownloaded(ut);
                 if (!curVersion.HasValue)
                    curVersion = Lawyer.Common.Default.DefaultValue.DefaultDatabaseVI;
            }

            //Nullable<int> curVersion = UpdateManager.GetLastVersionDownloaded(ut);
            //if (!curVersion.HasValue) 
            //    if (ut==UpdateType.c)
            //        curVersion = Lawyer.Common.Default.DefaultValue.DefaultSoftVI;
            //    else
            //        curVersion = Lawyer.Common.Default.DefaultValue.DefaultDatabaseVI;


            PostSubmitter post = new PostSubmitter();

            try
            {
               post.Url = Lawyer.Coding.HsPublic.DecryptText(UpdateManager.GetUpdateUrl());
                if (post.Url == string.Empty) throw new Exception();
            }
            catch (Exception)
            {
                lblMessage.Text = "مسیر دانلود یافت نشد....";
                txtMessage.Text = string.Empty;

                return ResultUpdate.fatal;
            }

            post.PostItems.Add("Type", ut.ToString());
            
            post.PostItems.Add("CurVersion", curVersion.ToString());

            post.PostItems.Add("Method", "down");

            post.Type = PostSubmitter.PostTypeEnum.Post;

            string[] stringSeparators = new string[] { "\r\n" };

            string result;

            string[] filepath;

            UpdateStatus.CanClose = false;
            try
            {
                result = post.Post();
            
            }
            catch ( Exception )
            {

                lblMessage.Text = "خطا در ارسال درخواست....";
                txtMessage.Text = string.Empty;
                return ResultUpdate.fatal;

            }

            filepath = result.Split(stringSeparators, StringSplitOptions.None);

            if (filepath.Length == 0)
            {
                lblMessage.Text = "خطا در دریافت پاسخ از مرکز....";
                txtMessage.Text = string.Empty;
                return ResultUpdate.fatal;
            }

            string file = filepath[0];

            if (file == "0")
            {
                lblMessage.Text = "خطا در ارسال نسخه....";
                txtMessage.Text = string.Empty;
                return ResultUpdate.fatal;
            }
            else if (file == "1")
            {
                lblMessage.Text = curVersion.ToString() + "\n" + "امکان دریافت نسخه جدید وجود ندارد ،  لطفا بعدا اقدام کنید.....";
                txtMessage.Text = string.Empty;
                return ResultUpdate.fatal;

            }
            else if (file == "2")
            {
                txtMessage.Text = "نسخه " + VersionName + " به روز می باشد.... ";
                lblMessage.Text = string.Empty ;
               
                return ResultUpdate.uptodate;
            }
            else
            {
                string remoteUri = string.Empty;
                string fileName = string.Empty;
                string newVersion = string.Empty;

                try
                {
                    stringSeparators[0] = ";";

                    filepath = file.Split(stringSeparators, StringSplitOptions.None);

                    remoteUri = filepath[0];

                    fileName = filepath[1];

                    newVersion = filepath[2];

                }
                catch (Exception )
                {
                    lblMessage.Text = "خطا در دریافت فایل درخواستی  از مرکز....";
                   // lblMessage.Text =curVersion.ToString()+"\n" +  result ;
                    txtMessage.Text = string.Empty;
                    return ResultUpdate.fatal;

                }

                UpdateStatus.CanClose = true;

                txtMessage.Text = "در حال دریافت نسخه جدید " + VersionName + ".....";

                //دانلود فایل در یک محل
                string tempfilepath = Common.DefaultValues.updateTemplate;

                try
                {
                    if (System.IO.Directory.Exists(Common.DefaultValues.updateTemplate))
                    {
                        System.IO.Directory.Delete(Common.DefaultValues.updateTemplate, true);
                    }

                    System.IO.Directory.CreateDirectory(Common.DefaultValues.updateTemplate);
                }
                catch (Exception)
                {
                    lblMessage.Text = " خطا در عمل دانلود محلی....";
                    txtMessage.Text = string.Empty;
                    return ResultUpdate.fatal;
                }

                if (UpdateStatus.CloseClick)
                    return ResultUpdate.exit;

                try
                {
                    WebClient myWebClient = new WebClient();

                    myWebClient.Credentials = new NetworkCredential(Lawyer.Coding.HsPublic.DecryptText(UpdateManager.GetFTPUse()), Lawyer.Coding.HsPublic.DecryptText(UpdateManager.GetFTPPass()));
                  
                    myWebClient.DownloadFile(remoteUri, tempfilepath + "\\" + fileName);

                }
                catch (Exception )
                {
                    //lblMessage.Text = remoteUri;
                    lblMessage.Text = " خطا در عمل دانلود....";
                    txtMessage.Text = string.Empty;
                    return ResultUpdate.fatal;
                }


                try
                {
                    UpdateStatus.CanClose = false;
                    UpdateManager.SaveDownloadedFile(ut.ToString(), newVersion, tempfilepath + "\\" + fileName);

                }
                catch (Exception)
                {
                    lblMessage.Text = " خطا در عمل ذخیره....";
                    txtMessage.Text = string.Empty;
                    return ResultUpdate.fatal;
                }
                UpdateStatus.CanClose = true;
                return ResultUpdate.update;


            }
        }

        public static string GetDBLastVersion()
        {
            return UpdateManager.GetLastVersion(UpdateType.d);
        }
    }


}
