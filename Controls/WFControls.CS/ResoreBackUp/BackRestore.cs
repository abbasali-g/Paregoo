using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Lawyer.Common.VB.LawyerError;
using System.Reflection;
using MySql.Data.MySqlClient;


namespace WFControls.CS.ResoreBackup
{
    public partial class BackRestore : UserControl
    {
        public BackRestore()
        {
            InitializeComponent();
        }

         Lawyer.Common.CS.ConfigFile.Config currentConfig = null;

        private bool RestoreLaws = false;

        private bool IsInstallDefault = false;

        private bool isAutomaticStart = false;

        public delegate void _closeFormHandler();
        public event _closeFormHandler _closeForm;

        private void BackRestore_Load(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(btnStart, "شروع");

            ToolTip1.SetToolTip(btnCancel, "توقف");

            ToolTip1.SetToolTip(btnBrows, "مشخص کردن فایل");

            ////////ToolTip1.SetToolTip(btnClose, "نمایش جزئیات");

            //pnlDetail.Visible = false;

             //lblMessage.Text = string.Empty;
        }

        string backupLocation = null;

        /// <summary>
        /// this function just create a backup file name 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CreateFileName()
        {
            try
            {
              
                DirectoryInfo dir = new DirectoryInfo(backupLocation);
                showDirectoryFiles(dir);
            }
            catch (Exception) { }

            string extension = ".nbp";
            //nbk is my extension for bakup file and stands for n as www.nwdic.com and bk as backup 
            if (chkLaws.Checked)
                extension = ".nbk";
            string backupFileName = System.DateTime.Now.Year + "." + System.DateTime.Now.Month + "." + System.DateTime.Now.Day + "." + System.DateTime.Now.Hour + "." + System.DateTime.Now.Minute + extension;
            txtPath.Text = backupLocation + backupFileName;
            backupFileName = null;

        }

        
        private void rdBackup_CheckedChanged_1(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (!rdBackup.Checked)
                return;

            btnStart.Enabled = true;
            CreateFileName();

        }

        private void rdRestore_CheckedChanged_1(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (!rdRestore.Checked)
                return;


            btnStart.Enabled = true;

            SetIP();
            //DirectoryInfo dir = new DirectoryInfo(backupLocation);
            //showDirectoryFiles(dir);

        }

        /// <summary>
        /// this function aborts two threads, one thread that takes backup or restore and 
        /// the other is progressbar thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                tbs.Abort();
                System.Threading.Thread.Sleep(200);
                thrdPrgress.Abort();
                System.Threading.Thread.Sleep(200);
                grpBackRestore.Enabled = true;
                btnStart.Enabled = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }


        /// <summary>
        /// start button sets the parameter of backup and restore function
        /// one:the batch file name should be excuted
        /// two: the parameter should be passed to batch file
        /// </summary>

        Thread tbs = null;
        string computerName;
        private void btnStart_Click(object sender, EventArgs e)
        {
            doStart();

        }

        public  void doStart()
        {
            lblMessage.Text = string.Empty;
            computerName = txtIPAddress.Text;
            if (rdbLocal.Checked)
                computerName = "127.0.0.1";

            string databaseName = txtDatabaseName.Text;
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string port = txtPort.Text;

            //if ((computerName == string.Empty) || (databaseName == string.Empty) || (userName == string.Empty) || (password == string.Empty))
            //{ grpBackRestore.Enabled = true; lblMessage.Text = "Please fill textbox values..."; return; }
            if ((rdbServer.Checked) && (computerName == string.Empty))
            { grpBackRestore.Enabled = true; lblMessage.Text = "IP Address را وارد نمایید . "; return; }

            grpBackRestore.Enabled = false;
            btnCancel.Enabled = true;
            btnStart.Enabled = false;


            createBackupRestoreParameter(computerName, txtDatabaseName.Text, txtUserName.Text, txtPassword.Text, port);
        }

        private void createBackupRestoreParameter(string computerName, string databaseName, string userName, string password, string port)
        {
            string fileName = Lawyer.Common.CS.Common.DefaultValues.App_ParentDir()+"\\";
                       
            string parameters = null;
            
            try
            {
                
                //myd.bat for backing up database
                if (rdBackup.Checked == true)
                {
                    if (RestoreLaws )
                        fileName += "mydr.bat";
                    else
                    {
                     if (chkLaws.Checked)
                        fileName += "myd.bat";
                    else
                        fileName += "mydp.bat";
                    }
                    //mysqldump --max_allowed_packet=16M --quick --host %1 --port  --routines -u %2 -p%3 %4>%5

                    parameters = string.Format("{0} {1} {2} {3} {4} {5}", computerName, port, txtUserName.Text, txtPassword.Text, databaseName, txtPath.Text);

                }

                //myr.bat for restoring database
                if (rdRestore.Checked == true)
                {
                    //mysql ----host=%1 --port=%2   -u %3  -p%4  %5<%6
                    fileName += "myr.bat";
                    parameters = string.Format("{0} {1} {2} {3} {4} {5}", computerName, port, txtUserName.Text, txtPassword.Text, databaseName, txtPath.Text);
                    // parameters = @" --max_allowed_packet=16M  --quick  --default-character-set=utf8  --host=" + txtIPAddress.Text + " --port=" + port + "  --user= " + txtUserName.Text + " --password=" + txtPassword.Text + " "+databaseName+" <"  +  txtPath.Text + "";

                }

                               
                tbs = new Thread(delegate() { Backup_Restore(fileName, parameters); });
                tbs.Start();
                //////Backup_Restore(fileName, parameters);

            }
            catch (Exception ex)
            { lblMessage.Text = ex.Message;
            ErrorManager.WriteMessage("createBackupRestoreParameter",ex.ToString(),this.ParentForm.Text);
            }
        }

        /// <summary>
        /// this function excutes the specified shell command through excuting the batch files
        /// and create the backup or restore the database
        /// </summary>

        Thread thrdPrgress = null;
    
        private void Backup_Restore(string fileName, string parameters)
        {
            try
            {
                if (IsInstallDefault)
                {
                    if (!System.IO.File.Exists(Lawyer.Common.CS.Common.DefaultValues.backupPath))
                    {
                        lblMessage.Text = "فایل مورد نظر یافت نشد.";
                        return;
                    }

                    else
                    {
                        if (RestoreLaws)
                        {
                            if (System.IO.File.Exists(Lawyer.Common.CS.Common.DefaultValues.RestoreLawPath ))
                            {
                                System.IO.File.Delete(Lawyer.Common.CS.Common.DefaultValues.RestoreLawPath);
                            }
                        }
                        else
                        {
                            if (System.IO.File.Exists(Lawyer.Common.CS.Common.DefaultValues.RestorePath))
                            {
                                System.IO.File.Delete(Lawyer.Common.CS.Common.DefaultValues.RestorePath);
                            }
                        }

                       
                    }

                }

            }
            catch (Exception)
            {
                lblMessage.Text = "خطا در نصب پایگاه داده";
                return;
            }


            string error = null;
            thrdPrgress = new Thread(new ThreadStart(startProgressbar));

            int ExitCode;
            ProcessStartInfo _processInfo = null;
            Process _process = null;
            try
            {
                thrdPrgress.Start();

                if (IsInstallDefault)
                {
                    //unzip
                    Ionic.Zip.ZipFile oZipFile = new Ionic.Zip.ZipFile(Lawyer.Common.CS.Common.DefaultValues.backupPath);
                    oZipFile.ExtractAll(Lawyer.Common.CS.Common.DefaultValues.UnzipPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);

                }

               _processInfo = new ProcessStartInfo(fileName, parameters);
                _processInfo.CreateNoWindow = true;
                _processInfo.UseShellExecute = false;
                _processInfo.RedirectStandardOutput = true;
                _processInfo.RedirectStandardError = true;
                _processInfo.WindowStyle = ProcessWindowStyle.Hidden;
                _processInfo.LoadUserProfile = true;

                _process = Process.Start(_processInfo);
                error = _process.StandardError.ReadToEnd();
                _process.WaitForExit();
                ExitCode = _process.ExitCode;
                _process.Close();

                prgBackupRestore.Value = 100;
                prgBottom.Value = 100;

                thrdPrgress.Abort();
                System.Threading.Thread.Sleep(500);
                btnStart.Enabled = true;

                if (error != "")
                    lblMessage.Text = error;

                if (!IsInstallDefault)
                    grpBackRestore.Enabled = true;

                //refresh list file
                DirectoryInfo dir = new DirectoryInfo(backupLocation);
                showDirectoryFiles(dir);

                if (rdRestore.Checked)
                {
                    if (((!RestoreLaws) && IsAttachDataBase(25, 200)) || (RestoreLaws && IsAttachDataBase(14, 0)))
                    {
                        lblMessage.Text = "عملیات با موفقیت انجام شد.";
                        if(isAutomaticStart)
                            _closeForm();
                    }
                    else
                        lblMessage.Text = "خطا در انجام عملیات.";
                }
                else
                {
                    lblMessage.Text = "عملیات با موفقیت انجام شد.";
                    if (isAutomaticStart)
                        _closeForm();
                }


            }
            catch (IOException ex)
            {
                _process.Close();
                thrdPrgress.Abort();
                lblMessage.Text = ex.ToString() + "\n" + error;
            }
        }

        private bool IsAttachDataBase(int tblCount , int procCount)
        {
            MySqlConnection con = new MySqlConnection(string.Format("server={0};Port={1};uid={2}; pwd={3};database=mysql;", computerName, txtPort.Text, txtUserName.Text, txtPassword.Text));

            MySqlCommand com = new MySqlCommand("select count(*) from `information_schema`.`TABLES` where  table_schema='nwdicdad2';", con);

            try
            {
                con.Open();

                long count = (long)com.ExecuteScalar();

                if (count >= tblCount)
                {
                    com.CommandText = "select count(*) from `information_schema`.`ROUTINES` where  routine_schema='nwdicdad2';";
                    count = (long)com.ExecuteScalar();
                    con.Close();
                    if (count > procCount)
                        return true;
                    else
                        return false;

                }
                else

                    con.Close();

                return false;

            }
            catch (Exception)
            {
                try
                {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
                catch (Exception)
                { }

                return false;
            }

        }

        /// <summary>
        /// in fact this two progressbars are just for showing the user that the program is running 
        /// and some how they doesnot show the real progress of backup or restore
        /// But they wait for shell command exution, as the shell command excutes, the valu of progressbar are set to maximum
        /// in order to show the user that job completed!
        /// sometimes as my experience it is usefull to show the user the state of a process even if it doesnot show the real state
        /// but the user comes to know that the process is running...
        /// </summary>
        private void startProgressbar()
        {

            prgBackupRestore.Visible = true;
            prgBottom.Visible = true;

            prgBottom.Style = ProgressBarStyle.Blocks;
            prgBottom.Minimum = 0;
            prgBottom.Maximum = 100;


            prgBackupRestore.Style = ProgressBarStyle.Blocks;
            prgBackupRestore.Minimum = 0;
            prgBackupRestore.Maximum = 100;


            for (int i = 0; i < 100; i++)
            {
                if (chkLaws.Checked)
                {
                    prgBackupRestore.Increment(1);
                    System.Threading.Thread.Sleep(400);
                }
                else
                {
                    prgBackupRestore.Increment(5);
                    System.Threading.Thread.Sleep(50);

                }

                if (i == 99) //if the process not finished yet
                { prgBackupRestore.Value = 50; i = 50; }

                for (int y = 0; y < 11; y++)
                {
                    prgBottom.Increment(10);
                    if (chkLaws.Checked)
                        System.Threading.Thread.Sleep(100);
                    else
                        System.Threading.Thread.Sleep(20);
                }
                prgBottom.Value = 0;
            }
            prgBackupRestore.Maximum = 100;
            prgBottom.Value = 100;

        }

        private void btnBrows_Click(object sender, EventArgs e)
        {

            lblMessage.Text = string.Empty;
            try
            {
                fldrBrws.ShowDialog();
                txtPath.Text = string.Empty;
                txtPath.Text = fldrBrws.SelectedPath;
                DirectoryInfo dirBackup = new DirectoryInfo(fldrBrws.SelectedPath);
                writeToConfig(fldrBrws.SelectedPath + "\\");
                showDirectoryFiles(dirBackup);
                backupLocation = fldrBrws.SelectedPath + "\\";
                CreateFileName();
            }
            catch (Exception) { }

        }

        private void showDirectoryFiles(DirectoryInfo dirBackup)
        {
            if (dirBackup.Exists)
            {
                //nbk is my extension for bakup file and stands for n as www.nwdic.com and bk as backup 
                string extension = "*.nbp";
                //nbk is my extension for bakup file and stands for n as www.nwdic.com and bk as backup 
                if (chkLaws.Checked)
                    extension = "*.nbk";
                FileInfo[] fileList = dirBackup.GetFiles(extension);
                //FileInfo[] fileList = dirBackup.GetFiles();
                lstBackups.Items.Clear();
                lstBackups.Items.AddRange(fileList);
            }
            //write default path to setting

            //   Properties.Settings.Default.BackupPath = fldrBrws.SelectedPath;


        }

        private void lstBackups_DoubleClick_1(object sender, EventArgs e)
        {

            FileInfo f = (FileInfo)lstBackups.SelectedItem;
            txtPath.Text = f.FullName;
            rdRestore.Checked = true;
        }

        private void lstBackups_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
            {
                try
                {
                    FileInfo f = (FileInfo)lstBackups.SelectedItem;
                    f.Delete();
                }
                catch (Exception ex)
                { lblMessage.Text = ex.Message; }
            }
        }



        /// <summary>
        /// writes the backup location to a file
        /// </summary>
        /// <param name="path"></param>
        private void writeToConfig(string path)
        {
            if (!IsInstallDefault)
            {
                try
                {

                    currentConfig.BackupLocation = path;
                    currentConfig.Udpate();

                    ////////using (TextWriter tw = new StreamWriter("backupPath.txt", false))
                    ////////{

                    ////////    tw.WriteLine("this file saves the last backup location, please do not delete this file.");
                    ////////    tw.WriteLine(path);
                    ////////    tw.Close();
                    ////////};
                }
                catch (Exception ex)
                {
                    ErrorManager.WriteMessage("writeToConfig", ex.ToString(),this.ParentForm.Text);
                    lblMessage.Text = "Error:writing to config file\n " + ex.Message + ""; }

            }
        }

        private void SetIP()
        {      
            if (rdRestore.Checked)
                rdbLocal.Checked = true;

            else
                if (computerName.ToLower() != "Localhost" && computerName.Trim().ToLower() != "127.0.0.1")
                    rdbServer.Checked = true;
        }

        public void SetInitial(Lawyer.Common.CS.ConfigFile.Config c, bool IsRestore , bool restoreLaws, bool? automaticstart=false)
        {
            RestoreLaws = restoreLaws;

            isAutomaticStart =(bool) automaticstart;
            
            currentConfig = c;

            if (currentConfig != null)
            {
                txtIPAddress.Text = c.LIP;
               
              
                txtUserName.Text = c.LUserName;

                txtPassword.Text = c.LPassword;

                txtPort.Text = c.LPort;

               
                                
                backupLocation = currentConfig.BackupLocation;

                if ((backupLocation != "") && (backupLocation != null))
                {
                    try
                    {
                        DirectoryInfo dir = new DirectoryInfo(backupLocation);
                        showDirectoryFiles(dir);
                    }
                    catch (Exception)
                    {

                    }
                }


                if (IsRestore)
                {
                    txtIPAddress.Text = c.IP;

                    txtUserName.Text = c.UserName;

                    txtPassword.Text = c.Password;

                    txtPort.Text = c.Port;

                    rdRestore.Checked = true;
                    IsInstallDefault = true;
                    rdBackup.Enabled = false;
                    chkLaws.Checked = true;
                    grpBackRestore.Enabled = false;
                    if (restoreLaws)
                    {
                        txtPath.Text = Lawyer.Common.CS.Common.DefaultValues.RestoreLawPath;
                        lblMessage.Text = "برای نصب قوانین دکمه start را کلیک نمایید.";

                    }
                    else
                    {
                        txtPath.Text = Lawyer.Common.CS.Common.DefaultValues.RestorePath;
                        lblMessage.Text = "برای نصب پایگاه داده دکمه start را کلیک نمایید.";

                    }
                   

                   
                }
                //unzip & restore
                else
                    rdBackup.Checked = true;

                computerName = txtIPAddress.Text;

                SetIP();

                if (isAutomaticStart)
                    doStart();
            }

        }

        private void chkLaws_CheckedChanged(object sender, EventArgs e)
        {
            CreateFileName();
        }

        private void rdbLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLocal.Checked)
                pnlIP.Visible = false;
            else
                pnlIP.Visible = true ;
        }

           }
}
