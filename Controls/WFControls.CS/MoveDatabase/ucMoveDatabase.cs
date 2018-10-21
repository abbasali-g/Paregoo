using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ServiceProcess;

namespace WFControls.CS.MoveDatabase
{
    public partial class ucMoveDatabase : UserControl
    {
        public ucMoveDatabase()
        {
            InitializeComponent();
            btnTransferToNewPlace.Visible = false;
        }

        private void btnSelectNewPath_Click(object sender, EventArgs e)
        {
            DialogResult drz = fldBrowser.ShowDialog();
            if (drz == DialogResult.OK)
            {
                lblNewPath.Text = fldBrowser.SelectedPath;
                btnTransferToNewPlace.Visible = true;
            }
        }

        private void btnTransferToNewPlace_Click(object sender, EventArgs e)
        {
            DialogResult rz = MessageBox.Show("آیا واقعا می خواهید فایلهای پایگاه داده را به مسیر جدید انتقال دهید؟", "انتقال پایگاه داده", MessageBoxButtons.OKCancel);
            if (rz == DialogResult.Cancel)
            {
                this.ParentForm.Close();
                return;
            }

            try
            {
                txtActionLog.AppendText("\r\n" + "در حال پیدا کردن مسیر پیش فرض پایگاه داده");

                txtActionLog.AppendText("\r\n" + "در حال پیدا کردن تغییر فایل تنظیمات");
                replaceIniFile();
                txtActionLog.AppendText("\r\n" + "فایل تنظیمات تغییر یافت");

                txtActionLog.AppendText("\r\n" + "در حال کپی فایل های پایگاه داده به مقصد");

                string sourcePath = lblCurrentPath.Text;
                string destPath = lblNewPath.Text;
                CopyDirectory(sourcePath, destPath);
                txtActionLog.AppendText("\r\n" + "فایل های پایگاه داده به مقصد کپی شد");

                txtActionLog.AppendText("\r\n" + "در حال توقف سرویس");
                startOrStopMysqlService(0);
                startOrStopMysqlService(1);
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(myIniPath))
                {
                    txtActionLog.AppendText("\r\n" + "بروز خطا در انتقال");
                    txtActionLog.AppendText("\r\n" + "در حال برگرداندن به حالت اولیه");
                    sw.Write(iniOriginalContent);
                    try { startOrStopMysqlService(0); }
                    catch (Exception ex1) { }
                    
                    startOrStopMysqlService(1);
                    txtActionLog.AppendText("\r\n" + "وضعیت به حالت اول برگردانده شد");
                };
                return;
            }

            MessageBox.Show("فایلهای پایگاه داده به مسیر جدید منتقل شد");

        }

        string myIniPath = string.Empty;
        string iniOriginalContent = string.Empty;

        private string getcurrentPathOfDataFile()
        {
            string systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\";
            string defaultMyiniPath = "MySQL\\MySQL Server 5.1\\my.ini";
            myIniPath = systemPath + defaultMyiniPath;

            
                        
            using (StreamReader sr = new StreamReader(myIniPath))
            {
                iniOriginalContent = sr.ReadToEnd();
            };
           

            //replace
            int startIndex = iniOriginalContent.IndexOf("datadir=");
            string afterDataDir = iniOriginalContent.Substring(startIndex);
            int endIndex = afterDataDir.IndexOf("#") + startIndex;

            string path= iniOriginalContent.Substring(startIndex, endIndex - startIndex).Replace("\r\n","").Trim().Replace("/","\\").Replace("datadir=","").Replace("\"","");
            if (path.EndsWith("\\"))
                path = path.Remove(path.Length - 1);

            return path;

        }
        private void replaceIniFile()
        {
            string systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\";
            string defaultMyiniPath = "MySQL\\MySQL Server 5.1\\my.ini";
            string myIniPath = systemPath + defaultMyiniPath;

            string iniOriginalContent = string.Empty;
            string iniNewContent = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(myIniPath))
                {
                    iniOriginalContent = sr.ReadToEnd();
                    iniNewContent = iniOriginalContent;
                };
           

                //replace
                int startIndex = iniNewContent.IndexOf("datadir=");
                string afterDataDir = iniNewContent.Substring(startIndex);
                int endIndex = afterDataDir.IndexOf("#") + startIndex;

                iniNewContent = iniNewContent.Replace(iniNewContent.Substring(startIndex, endIndex - startIndex), string.Format("datadir=\"{0}\"", lblNewPath.Text.Replace("\\", "/") + "/") + "\r\n\r\n");

                using (StreamWriter sw = new StreamWriter(myIniPath))
                {
                    sw.Write(iniNewContent);
                };

            }
            catch (Exception ex)
            {
                txtActionLog.AppendText("\r\n" + ex.Message);

                using (StreamWriter sw = new StreamWriter(myIniPath))
                {
                    sw.Write(iniNewContent);
                };
            }
        }

        private void CopyDirectory(string sourcePath , string destPath)
        {
            
            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string dest = Path.Combine(destPath, Path.GetFileName(file));
                File.Copy(file, dest);
            }

            foreach (string folder in Directory.GetDirectories(sourcePath))
            {
                string dest = Path.Combine(destPath, Path.GetFileName(folder));
                CopyDirectory(folder, dest);
            }
        }

        private short startOrStopMysqlService(short action)
        {
            short errorCode = 0;
            try
            {
                ServiceController sc = new ServiceController();
                sc.ServiceName = "mysql";

                txtActionLog.AppendText("\r\n" + "initial status of service:" + sc.Status.ToString());

                if (action == 0) //stop service
                {
                    if (!sc.Status.Equals(ServiceControllerStatus.Running))
                    {
                        sc.Start();
                        System.Threading.Thread.Sleep(5000);
                        if (sc.Status.Equals(ServiceControllerStatus.Running))
                            errorCode = 0;
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
                txtActionLog.AppendText("\r\n" + "وضعیت سرویس:" + sc.Status.ToString());
                return errorCode;

            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        private void ucMoveDatabase_Load(object sender, EventArgs e)
        {
            lblCurrentPath.Text = getcurrentPathOfDataFile();

            MessageBox.Show("لطفا قبل از انجام عملیات انتقال، از اطلاعات خود فایل پشتیبان تهیه نمایید");
        }



    }
}
