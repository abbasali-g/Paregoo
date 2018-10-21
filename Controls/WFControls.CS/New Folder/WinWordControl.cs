
/// Some functionality added to the user control by Abbas Gharakhanlou
/// using the user control in a client server project also done by Abbas
/// for any query please feel free to contact me:abbasali_g@yahoo.com
/// Thanks for Matthias Haenel and Anup Shinde
/// 
///This code has been changed by Anup Shinde.
/// contact: anup@micromacs.com   ...:)

/// The original code is written by Matthias Haenel
/// contact: www.intercopmu.de
/// Code was received from: http://www.codeproject.com/cs/miscctrl/winwordcontrol.asp
/// 
/// you can use it free of charge, but please 
/// mention my name ;)
/// 
/// WinWordControl utilizes MS-WinWord2000 and 
/// WinWord-XP
/// 
/// It simulates a form element, with simple tricks.
///


using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Word;
using System.Diagnostics;
using Lawyer.Common.VB.Docs;
using Lawyer.Common.VB.LawyerError;

namespace WinWordControl
{
	/// <summary>
	/// WinWordControl allows you to load doc-Files to your
	/// own application without any loss, because it uses 
	/// the real WinWord.
	/// </summary>
	public class WinWordControl : System.Windows.Forms.UserControl
	{


		#region "API usage declarations"

		[DllImport("user32.dll")]
		public static extern int FindWindow(string strclassName, string strWindowName);

		[DllImport("user32.dll")]
		static extern int SetParent( int hWndChild, int hWndNewParent);

		[DllImport("user32.dll", EntryPoint="SetWindowPos")]
		static extern bool SetWindowPos(
			int hWnd,               // handle to window
			int hWndInsertAfter,    // placement-order handle
			int X,                  // horizontal position
			int Y,                  // vertical position
			int cx,                 // width
			int cy,                 // height
			uint uFlags             // window-positioning options
			);
		
		[DllImport("user32.dll", EntryPoint="MoveWindow")]
		static extern bool MoveWindow(
			int hWnd, 
			int X, 
			int Y, 
			int nWidth, 
			int nHeight, 
			bool bRepaint
			);

		[DllImport("user32.dll", EntryPoint="DrawMenuBar")]
		static extern Int32 DrawMenuBar(
			Int32 hWnd
			);

		[DllImport("user32.dll", EntryPoint="GetMenuItemCount")]
		static extern Int32 GetMenuItemCount(
			Int32 hMenu
			);

		[DllImport("user32.dll", EntryPoint="GetSystemMenu")]
		static extern Int32 GetSystemMenu(
			Int32 hWnd,
			bool bRevert
			);

		[DllImport("user32.dll", EntryPoint="RemoveMenu")]
		static extern Int32 RemoveMenu(
			Int32 hMenu,
			Int32 nPosition,
			Int32 wFlags
			);

		
		private const int MF_BYPOSITION = 0x400;
		private const int MF_REMOVE = 0x1000;

		
		const int SWP_DRAWFRAME = 0x20;
		const int SWP_NOMOVE = 0x2;
		const int SWP_NOSIZE = 0x1;
		const int SWP_NOZORDER = 0x4;

		#endregion

				

		/* I was testing wheater i could fix some exploid bugs or not.
		 * I left this stuff in here for people who need to know how to 
		 * interface the Win32-API

		[StructLayout(LayoutKind.Sequential)]
			public struct RECT 
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
		
		[DllImport("user32.dll")]
		public static extern int GetWindowRect(int hwnd, ref RECT rc);
		
		[DllImport("user32.dll")]
		public static extern IntPtr PostMessage(
			int hWnd, 
			int msg, 
			int wParam, 
			int lParam
		);
		*/


		/// <summary>
		/// Change. Made the following variables public.
		/// </summary>

       	public  Word.Document wDoc;
        public static Word.ApplicationClass wAppC = null;//static
		public  static int wordWnd				= 0;
		public  static string filename			= null;
		
        private static bool	deactivateevents	= false;
        private string FileID  ;
        private string TableName;
        private string docFullName;
        private WFControls.CS.Document.ucWordType ucWordType1;
       
		/// <summary>
		/// needed designer variable
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinWordControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// cleanup Ressources
		/// </summary>
		protected override void Dispose( bool disposing )
		{
            //CloseControl();
			if( disposing )
			{
                Process[] myProcesses;
                // Returns array containing all instances of Notepad.
                myProcesses = Process.GetProcessesByName("winword");
                foreach (Process myProcess in myProcesses)
                {
                    myProcess.Kill ();
                }

                ////if( components != null )
                ////    components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// !do not alter this code! It's designer code
		/// </summary>
		private void InitializeComponent()
		{
            this.ucWordType1 = new WFControls.CS.Document.ucWordType();
            this.SuspendLayout();
            // 
            // ucWordType1
            // 
            this.ucWordType1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(163)))), ((int)(((byte)(61)))));
            this.ucWordType1.Location = new System.Drawing.Point(0, 271);
            this.ucWordType1.Name = "ucWordType1";
            this.ucWordType1.Size = new System.Drawing.Size(678, 33);
            this.ucWordType1.TabIndex = 0;
            // 
            // WinWordControl
            // 
            this.AllowDrop = true;
            this.Controls.Add(this.ucWordType1);
            this.Name = "WinWordControl";
            this.Size = new System.Drawing.Size(678, 353);
            this.Load += new System.EventHandler(this.WinWordControl_Load);
            this.Resize += new System.EventHandler(this.OnResize);
            this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// Preactivation
		/// It's usefull, if you need more speed in the main Program
		/// so you can preload Word.
		/// </summary>
		public void PreActivate()
		{
			if(wAppC == null) wAppC = new Word.ApplicationClass();
            
        }


		/// <summary>
		/// Close the current Document in the control --> you can 
		/// load a new one with LoadDocument
		/// </summary>
		public void CloseControl()
		{
			/*
			* this code is to reopen Word.
			*/
		
            //////try
            //////{
            //////    deactivateevents = true;
            //////    object dummy=null;
            //////    object dummy2=(object)false;
            //////    if (this.document != null)
            //////    {
            //////        this.document.Close(ref dummy, ref dummy, ref dummy);
            //////        wd.Quit(ref dummy2, ref dummy, ref dummy);
            //////    }
            //////    // Change the line below.
				
            //////    deactivateevents = false;
            //////}
            //////catch(Exception ex)
            //////{
            //////   String strErr = ex.Message;
            //////}

            Dispose();

		}


		/// <summary>
		/// catches Word's close event 
		/// starts a Thread that send a ESC to the word window ;)
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="test"></param>
		private void OnClose(Word.Document doc, ref bool cancel)
		{
			if(!deactivateevents)
			{
				cancel=true;
			}
            ////////saveDoc(wDoc);
          
		}

        //public void closeDoc()
        //{
        //     object missing = System.Reflection.Missing.Value;
        //    //document.Save();
            
        //    document.Close(ref missing, ref missing, ref missing);
        //}

		/// <summary>
		/// catches Word's open event
		/// just close
		/// </summary>
		/// <param name="doc"></param>
		private void OnOpenDoc(Word.Document doc)
		{

            //try
            //{
            //    if (doc != null && docFullName != doc.FullName)
                   OnNewDoc(doc);
            //}
            //catch
            //{
            //}
          
            
		}

		/// <summary>
		/// catches Word's newdocument event
		/// just close
		/// </summary>
		/// <param name="doc"></param>
		private void OnNewDoc(Word.Document doc)
		{
			if(!deactivateevents)
			{

                //wd = null;
                 //deactivateevents=true;
               //object dummy = null;
               
                string fileName = doc.FullName;
                //doc.Close(ref dummy,ref dummy,ref dummy);
                LoadDocument(fileName ,true);
                 

                //deactivateevents=false;
			}
		}
        private void OnBeforSaveDoc(Word.Document doc, ref Boolean dummy, ref Boolean du)
        {
            //MessageBox.Show("before saving");
           // wd.ActiveDocument.Save();
           // saveDoc(doc);
        }

        public void saveDoc(Word.Document doc, bool SaveInTable)
        {
            //our own function to be handled here

           
                if (!doc.ReadOnly )
                doc.Save();
           
            ApplicationClass ap = new ApplicationClass();
             while (ap.BackgroundSavingStatus > 0)
            {
                System.Threading.Thread.Sleep(250);
            }

             if (FileID != string.Empty && SaveInTable)
            {
                string content = doc.Content.Text;
                object dummy = null;

                wAppC.Documents.Close(ref dummy, ref dummy, ref dummy);
                wDoc = null;
                if (TableName == "tempdocs" && FileID !=string.Empty )
                {
                    
                    TempDocManager.EditFile(FileID, filename , content);
                    FileID = string.Empty;
                 }
                else if (TableName == "filedocs" && FileID != string.Empty )
                {
                    FileDocManager.EditFile(FileID, filename, content);
                    FileID = string.Empty;
                }

              
            }
            //////else
            //////{
            //////    if (!doc.ReadOnly )
            //////    doc.Save();
            //////}
            //////ApplicationClass ap = new ApplicationClass();
            ////// while (ap.BackgroundSavingStatus > 0)
            //////{
            //////    System.Threading.Thread.Sleep(250);
            //////}
 
        }

		/// <summary>
		/// catches Word's quit event
		/// normally it should not fire, but just to be shure
		/// safely release the internal Word Instance 
		/// </summary>
		private void OnQuit()
		{
			//wd=null;
		}


        public void documentSaveAs(string fileNameAs)
        {
            try
            {
                object FileName = fileNameAs;
                object FileFormat = Word.WdSaveFormat.wdFormatRTF;
                object LockComments = false;
                object AddToRecentFiles = true;
                object ReadOnlyRecommended = false;
                object EmbedTrueTypeFonts = false;
                object SaveNativePictureFormat = true;
                object SaveFormsData = true;
                object SaveAsAOCELetter = false;
                object Encoding = Office.MsoEncoding.msoEncodingUTF8;
                object InsertLineBreaks = false;
                object AllowSubstitutions = false;
                object missing = System.Reflection.Missing.Value;
                object AddBiDiMarks = false;


                wDoc.SaveAs(ref FileName, ref missing, ref missing,
                ref missing, ref missing, ref missing,
                ref missing, ref missing,
                ref missing, ref missing,
                ref missing);
                
            }
            catch(Exception ex) {
                ErrorManager.WriteMessage("documentSaveAs", ex.ToString(),this.ParentForm.Text);
                MessageBox.Show("اشکال در ذخیره اطلاعات"+ "\n"+ex.ToString()+ ""); }
        }

		/// <summary>
		/// Loads a document into the control
		/// </summary>
		/// <param name="t_filename">path to the file (every type word can handle)</param>
		public void LoadDocument(string t_filename, bool ManualOpen )
		{

           
            docFullName = t_filename;
          	deactivateevents = true;
            FileID = string.Empty;
			filename = t_filename;
            try
            {
                if (wAppC == null) wAppC = new Word.ApplicationClass();
                try
                {
                    wAppC.CommandBars.AdaptiveMenus = false;
                    wAppC.DocumentBeforeClose += new Word.ApplicationEvents2_DocumentBeforeCloseEventHandler(OnClose);
                    wAppC.NewDocument += new Word.ApplicationEvents2_NewDocumentEventHandler(OnNewDoc);
                   wAppC.DocumentOpen += new Word.ApplicationEvents2_DocumentOpenEventHandler(OnOpenDoc);
                   // wd.DocumentBeforeSave += new Word.ApplicationEvents2_DocumentBeforeSaveEventHandler(OnBeforSaveDoc);
                    wAppC.ApplicationEvents2_Event_Quit += new Word.ApplicationEvents2_QuitEventHandler(OnQuit);


                }
                catch { }

                if (wDoc != null)
                {
                    try
                    {
                        object dummy = null;
                        wAppC.Documents.Close(ref dummy, ref dummy, ref dummy);

                        wordWnd = 0;
                        //wDoc = null;
                    }
                    catch { }
                }

                if (wordWnd == 0) wordWnd = FindWindow("Opusapp",null);
                if (wordWnd != 0)
                {
                   if (!ManualOpen)
                        SetParent(wordWnd, this.Handle.ToInt32());
                    object fileName = filename;
                    object newTemplate = false;
                    object docType = 0;
                    object readOnly = true;
                    object isVisible = true;
                    object missing = System.Reflection.Missing.Value;

                    try
                    {
                        if (wAppC == null)
                        {
                            throw new WordInstanceException();
                        }

                        if (wAppC.Documents == null)
                        {
                            throw new DocumentInstanceException();
                        }

                        if (wAppC != null && wAppC.Documents != null)
                        {
                            //document = wd.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);

                            object file = fileName; //this is the path
                            object nullobject = System.Reflection.Missing.Value;
                            wDoc = wAppC.Documents.Open(ref file, ref nullobject, ref nullobject, ref nullobject,
                                ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                                ref nullobject, ref nullobject, ref nullobject, ref nullobject);

                            
                            //MessageBox.Show(document.Path + document.FullName);

                        }

                        if (wDoc == null)
                        {
                            throw new ValidDocumentException();
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        wAppC.ActiveWindow.DisplayRightRuler = false;
                        wAppC.ActiveWindow.DisplayScreenTips = false;
                        wAppC.ActiveWindow.DisplayVerticalRuler = false;
                        wAppC.ActiveWindow.DisplayRightRuler = false;
                        wAppC.ActiveWindow.ActivePane.DisplayRulers = false;
                        wAppC.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;

                        //wd.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;//wdWebView; // .wdNormalView;
                    }
                    catch
                    {

                    }


                    /// Code Added
                    /// Disable the specific buttons of the command bar
                    /// By default, we disable/hide the menu bar
                    /// The New/Open buttons of the command bar are disabled
                    /// Other things can be added as required (and supported ..:) )
                    /// Lots of commented code in here, if somebody needs to disable specific menu or sub-menu items.
                    /// 


                   
                    int counter = wAppC.ActiveWindow.Application.CommandBars.Count;
                    for (int i = 1; i <= counter; i++)
                    {
                        try
                        {

                            String nm = wAppC.ActiveWindow.Application.CommandBars[i].Name;
                            /// MessageBox.Show("The menu:" + nm);

                            ////int count_control1 = wd.ActiveWindow.Application.CommandBars[i].Controls.Count;
                            ////for (int j = 1; j <= count_control1; j++)
                            //////for (int j = 1; j <= count_control; j++)
                            ////{
                            ////    try
                            ////    {
                            ////        //MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].Caption);
                            ////        //wd.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled = false;
                            ////    }
                            ////    catch (Exception ex) { }

                            ////}


                            if (nm == "Standard")
                            {
                                //nm=i.ToString()+" "+nm;
                                //MessageBox.Show(nm);
                                int count_control = wAppC.ActiveWindow.Application.CommandBars[i].Controls.Count;
                                for (int j = 1; j <= 2; j++)
                                //for (int j = 1; j <= count_control; j++)
                                {

                                    try
                                    {
                                        //MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].Caption);
                                        wAppC.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled = false;
                                    }
                                    catch (Exception ex) { ErrorManager.WriteMessage("LoadDocument,part1", ex.ToString(),this.ParentForm.Text); }

                                }
                            }

                            if (nm == "Menu Bar")
                            {
                                //To disable the menubar, use the following (1) line
                                wAppC.ActiveWindow.Application.CommandBars[i].Enabled = false;

                                /// If you want to have specific menu or sub-menu items, write the code here. 
                                /// Samples commented below

                                //							MessageBox.Show(nm);
                                //int count_control=wd.ActiveWindow.Application.CommandBars[i].Controls.Count;
                                //MessageBox.Show(count_control.ToString());						

                                /*
                                //for(int j=1;j<=count_control;j++)
                                for(int j=1;j<=count_control-1;j++)
                                {
                                    /// The following can be used to disable specific menuitems in the menubar	
                                    //wd.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled=false;
                                    wd.ActiveWindow.Application.CommandBars[i].Controls[j].Caption = "سلام";
                                    wd.ActiveWindow.Application.CommandBars[i].Controls[j].Delete((object)true);

                                    ////MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].ToString());
                                    ////MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].Caption);
                                    ////MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].accChildCount.ToString());


                                    ///The following can be used to disable some or all the sub-menuitems in the menubar


                                    Office.CommandBarPopup c;
                                    c = (Office.CommandBarPopup)wd.ActiveWindow.Application.CommandBars[i].Controls[j];

                                    for (int k = 1; k <= c.Controls.Count; k++)
                                    {
                                        //MessageBox.Show(k.ToString()+" "+c.Controls[k].Caption + " -- " + c.Controls[k].DescriptionText + " -- " );
                                        try
                                        {
                                            c.Controls[k].Enabled = false;
                                           // c.Controls["Close Window"].Enabled = false;
                                        }
                                        catch
                                        {

                                        }
                                    }
								
								
                           
                                    //wd.ActiveWindow.Application.CommandBars[i].Controls[j].Control	 Controls[0].Enabled=false;
                                }
                                     */

                            }

                            nm = "";
                        }
                        catch (Exception ex)
                        {
                            ErrorManager.WriteMessage("LoadDocument,part2", ex.ToString(),this.ParentForm.Text);
                            MessageBox.Show(ex.ToString());
                        }
                    }



                    // Show the word-document
                    try
                    {
                        if (!wAppC.Visible)
                        {  wAppC.Visible = true;
                        }
                      

                        wAppC.Activate();
                       if (!ManualOpen)
                            SetWindowPos(wordWnd, this.Handle.ToInt32(), 0, 0, this.Bounds.Width, this.Bounds.Height, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME | SWP_NOSIZE);

                        //Call onresize--I dont want to write the same lines twice
                        OnResize();
                    }
                    catch
                    {
                         MessageBox.Show("Error: do not load the document into the control until the parent window is shown!");
                    }

                    /// We want to remove the system menu also. The title bar is not visible, but we want to avoid accidental minimize, maximize, etc ..by disabling the system menu(Alt+Space)
                    try
                    {
                        int hMenu = GetSystemMenu(wordWnd, false);
                        if (hMenu > 0)
                        {
                            int menuItemCount = GetMenuItemCount(hMenu);
                            RemoveMenu(hMenu, menuItemCount - 1, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 2, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 3, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 4, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 5, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 6, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 7, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 8, MF_REMOVE | MF_BYPOSITION);
                            DrawMenuBar(wordWnd);
                        }
                    }
                    catch { };


                   if (!ManualOpen)
                        this.Parent.Focus();

                }
                deactivateevents = false;
                           }
            catch (Exception ex)
            {
               
               deactivateevents = false;
               ErrorManager.WriteMessage("LoadDocument,part4", ex.ToString(),this.ParentForm.Text);
            }
            WFControls.CS.Document.ucWordType c = new WFControls.CS.Document.ucWordType();
            this.Container.Add(c);
            c.Location=new Point(0,300);
            c.Show();
            //MessageBox.Show(ucWordType1.Location.Y.ToString());
            //ucWordType1.BringToFront();
            //ucWordType1.Visible = true;
		}

        public void LoadDocument(string t_filename, string ID , string TableName , bool ManualOpen)
       {
            deactivateevents = true;
            FileID = ID;
            this.TableName = TableName;
            filename = t_filename;
            try
            {
                if (wAppC == null) wAppC = new Word.ApplicationClass();
                try
                {
                    wAppC.CommandBars.AdaptiveMenus = false;
                    wAppC.DocumentBeforeClose += new Word.ApplicationEvents2_DocumentBeforeCloseEventHandler(OnClose);
                    wAppC.NewDocument += new Word.ApplicationEvents2_NewDocumentEventHandler(OnNewDoc);
                    wAppC.DocumentOpen += new Word.ApplicationEvents2_DocumentOpenEventHandler(OnOpenDoc);
                    wAppC.DocumentBeforeSave += new Word.ApplicationEvents2_DocumentBeforeSaveEventHandler(OnBeforSaveDoc);
                    wAppC.ApplicationEvents2_Event_Quit += new Word.ApplicationEvents2_QuitEventHandler(OnQuit);


                }
                catch { }

                if (wDoc != null)
                {
                    try
                    {
                        object dummy = null;
                        wAppC.Documents.Close(ref dummy, ref dummy, ref dummy);
                        wordWnd = 0;
                    }
                    catch { }
                }

                if (wordWnd == 0) wordWnd = FindWindow("Opusapp", null);
                if (wordWnd != 0)
                {
                    if (!ManualOpen)
                        SetParent(wordWnd, this.Handle.ToInt32());
                    object fileName = filename;
                    object newTemplate = false;
                    object docType = 0;
                    object readOnly = true;
                    object isVisible = true;
                    object missing = System.Reflection.Missing.Value;

                    try
                    {
                        if (wAppC == null)
                        {
                            throw new WordInstanceException();
                        }

                        if (wAppC.Documents == null)
                        {
                            throw new DocumentInstanceException();
                        }

                        if (wAppC != null && wAppC.Documents != null)
                        {
                            //document = wd.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);

                            object file = fileName; //this is the path
                            object nullobject = System.Reflection.Missing.Value;
                            wDoc = wAppC.Documents.Open(ref file, ref nullobject, ref nullobject, ref nullobject,
                                ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                                ref nullobject, ref nullobject, ref nullobject, ref nullobject);
                            

                            //MessageBox.Show(document.Path + document.FullName);

                        }

                        if (wDoc == null)
                        {
                            throw new ValidDocumentException();
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        wAppC.ActiveWindow.DisplayRightRuler = false;
                        wAppC.ActiveWindow.DisplayScreenTips = false;
                        wAppC.ActiveWindow.DisplayVerticalRuler = false;
                        wAppC.ActiveWindow.DisplayRightRuler = false;
                        wAppC.ActiveWindow.ActivePane.DisplayRulers = false;
                        wAppC.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;

                        //wd.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;//wdWebView; // .wdNormalView;
                    }
                    catch
                    {

                    }


                    /// Code Added
                    /// Disable the specific buttons of the command bar
                    /// By default, we disable/hide the menu bar
                    /// The New/Open buttons of the command bar are disabled
                    /// Other things can be added as required (and supported ..:) )
                    /// Lots of commented code in here, if somebody needs to disable specific menu or sub-menu items.
                    /// 
                    int counter = wAppC.ActiveWindow.Application.CommandBars.Count;
                    for (int i = 1; i <= counter; i++)
                    {
                        try
                        {

                            String nm = wAppC.ActiveWindow.Application.CommandBars[i].Name;
                            /// MessageBox.Show("The menu:" + nm);

                            ////int count_control1 = wd.ActiveWindow.Application.CommandBars[i].Controls.Count;
                            ////for (int j = 1; j <= count_control1; j++)
                            //////for (int j = 1; j <= count_control; j++)
                            ////{
                            ////    try
                            ////    {
                            ////        //MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].Caption);
                            ////        //wd.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled = false;
                            ////    }
                            ////    catch (Exception ex) { }

                            ////}


                            if (nm == "Standard")
                            {
                                //nm=i.ToString()+" "+nm;
                                //MessageBox.Show(nm);
                                int count_control = wAppC.ActiveWindow.Application.CommandBars[i].Controls.Count;
                                for (int j = 1; j <= 2; j++)
                                //for (int j = 1; j <= count_control; j++)
                                {

                                    try
                                    {
                                        //MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].Caption);
                                        wAppC.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled = false;
                                    }
                                    catch (Exception ex) { }

                                }
                            }

                            if (nm == "Menu Bar")
                            {
                                //To disable the menubar, use the following (1) line
                                wAppC.ActiveWindow.Application.CommandBars[i].Enabled = false;

                                /// If you want to have specific menu or sub-menu items, write the code here. 
                                /// Samples commented below

                                //							MessageBox.Show(nm);
                                //int count_control=wd.ActiveWindow.Application.CommandBars[i].Controls.Count;
                                //MessageBox.Show(count_control.ToString());						

                                /*
                                //for(int j=1;j<=count_control;j++)
                                for(int j=1;j<=count_control-1;j++)
                                {
                                    /// The following can be used to disable specific menuitems in the menubar	
                                    //wd.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled=false;
                                    wd.ActiveWindow.Application.CommandBars[i].Controls[j].Caption = "سلام";
                                    wd.ActiveWindow.Application.CommandBars[i].Controls[j].Delete((object)true);

                                    ////MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].ToString());
                                    ////MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].Caption);
                                    ////MessageBox.Show(wd.ActiveWindow.Application.CommandBars[i].Controls[j].accChildCount.ToString());


                                    ///The following can be used to disable some or all the sub-menuitems in the menubar


                                    Office.CommandBarPopup c;
                                    c = (Office.CommandBarPopup)wd.ActiveWindow.Application.CommandBars[i].Controls[j];

                                    for (int k = 1; k <= c.Controls.Count; k++)
                                    {
                                        //MessageBox.Show(k.ToString()+" "+c.Controls[k].Caption + " -- " + c.Controls[k].DescriptionText + " -- " );
                                        try
                                        {
                                            c.Controls[k].Enabled = false;
                                           // c.Controls["Close Window"].Enabled = false;
                                        }
                                        catch
                                        {

                                        }
                                    }
								
								
                           
                                    //wd.ActiveWindow.Application.CommandBars[i].Controls[j].Control	 Controls[0].Enabled=false;
                                }
                                     */

                            }

                            nm = "";
                        }
                        catch (Exception ex)
                        {
                            ErrorManager.WriteMessage("LoadDocument,t_filename", ex.ToString(), this.ParentForm.Text);
                            MessageBox.Show(ex.ToString());
                        }
                    }



                    // Show the word-document
                    try
                    {
                        wAppC.Visible = true;
                       if (ManualOpen)
                         wAppC.Activate();
                        if (!ManualOpen)
                            SetWindowPos(wordWnd, this.Handle.ToInt32(), 0, 0, this.Bounds.Width, this.Bounds.Height, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME | SWP_NOSIZE);

                        //Call onresize--I dont want to write the same lines twice
                        OnResize();
                    }
                    catch
                    {
                       
                        MessageBox.Show("Error: do not load the document into the control until the parent window is shown!");
                    }

                    /// We want to remove the system menu also. The title bar is not visible, but we want to avoid accidental minimize, maximize, etc ..by disabling the system menu(Alt+Space)
                    try
                    {
                        int hMenu = GetSystemMenu(wordWnd, false);
                        if (hMenu > 0)
                        {
                            int menuItemCount = GetMenuItemCount(hMenu);
                            RemoveMenu(hMenu, menuItemCount - 1, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 2, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 3, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 4, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 5, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 6, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 7, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 8, MF_REMOVE | MF_BYPOSITION);
                            DrawMenuBar(wordWnd);
                        }
                    }
                    catch { };


                    if (!ManualOpen)
                        this.Parent.Focus();

                }
                deactivateevents = false;
            }
            catch (Exception ex)
            { deactivateevents = false; ID = string.Empty;
            ErrorManager.WriteMessage("LoadDocument,t_filename2", ex.ToString(),this.ParentForm.Text);
            }
        
        }



		/// <summary>
		/// restores Word.
		/// If the program crashed somehow.
		/// Sometimes Word saves it's temporary settings :(
		/// </summary>
		public void RestoreWord()
		{
			try
			{
				int counter = wAppC.ActiveWindow.Application.CommandBars.Count;
				for(int i = 0; i < counter;i++)
				{
					try
					{
						wAppC.ActiveWindow.Application.CommandBars[i].Enabled=true;
					}
					catch
					{

					}
				}
			}
			catch{};
			
		}

		/// <summary>
		/// internal resize function
		/// utilizes the size of the surrounding control
		/// 
		/// optimzed for Word2000 but it works pretty good with WordXP too.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnResize()
		{
			//The original one that I used is shown below. Shows the complete window, but its buttons (min, max, restore) are disabled
			//// MoveWindow(wordWnd,0,0,this.Bounds.Width,this.Bounds.Height,true);


			///Change below
			///The following one is better, if it works for you. We donot need the title bar any way. Based on a suggestion.
			int borderWidth = SystemInformation.Border3DSize.Width;
			int borderHeight = SystemInformation.Border3DSize.Height;
			int captionHeight = SystemInformation.CaptionHeight;
			int statusHeight = SystemInformation.ToolWindowCaptionHeight;
			MoveWindow(
				wordWnd, 
				-2*borderWidth,
				-2*borderHeight - captionHeight, 
				this.Bounds.Width + 4*borderWidth, 
				this.Bounds.Height + captionHeight + 4*borderHeight + statusHeight,
				true);

		}

		private void OnResize(object sender, System.EventArgs e)
		{
			OnResize();
		}


		/// Required. 
		/// Without this, the command bar buttons that have been disabled 
		/// will remain disabled permanently (does not occur at every machine or every time)
		public  void RestoreCommandBars()
		{
			try
			{
				int counter = wAppC.ActiveWindow.Application.CommandBars.Count;
                //I added the below(1)
               
                
				for(int i = 1; i <= counter;i++)
				{
					try
					{
							
						String nm=wAppC.ActiveWindow.Application.CommandBars[i].Name;
                       
						if(nm=="Standard")
						{
							int count_control=wAppC.ActiveWindow.Application.CommandBars[i].Controls.Count;
							for(int j=1;j<=2;j++)
							{
								wAppC.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled=true;
							}
						}
						if(nm=="Menu Bar")
						{
							wAppC.ActiveWindow.Application.CommandBars[i].Enabled=true;
						}
						nm="";
					}
					catch(Exception ex)
					{
                        ErrorManager.WriteMessage("RestoreCommandBars", ex.ToString(),this.ParentForm.Text);
						MessageBox.Show(ex.ToString());						
					}
				}
			}
			catch{}

		}

        private void WinWordControl_Load(object sender, EventArgs e)
        {
           
        }

        //private void WinWordControl_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Copy;
        //}

        //private void WinWordControl_DragDrop(object sender, DragEventArgs e)
        //{

        //    try
        //    {
        //        string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop));
        //        string extension;
        //        foreach (var item in files)
        //        {
        //            extension = System.IO.Path.GetExtension(item);

        //            if (extension != string.Empty && (extension == ".txt" || extension == ".dot" || extension == ".docx" || extension == ".doc"))
        //            {
        //                document = null;
        //                //wd = null;
        //                //wordWnd = 0;
        //                LoadDocument(item, false);
        //                return;
        //            }
        //        }

        //    }
        //    catch
        //    {
        //    }

        //}

        public void ReplaceDefaultText(ArrayList content)
        {
            
            int count = 0;
            foreach (Word.Shape item1 in wDoc.Shapes)
            {
                if (count < content.Count)
                {
                    if (item1.Type == Office.MsoShapeType.msoTextBox)
                    {

                        foreach (string[] item in content)
                        {
                            if (item[0] == item1.Name)
                            {
                                item1.TextFrame.TextRange .Text = item[1];
                                count++;
                                break;
                            }
                        }

                    }

                    //item.Name="rrr" ;
                }
                else
                    return;

            }
           
           
        }
	}
	public class DocumentInstanceException : Exception
	{}
	
	public class ValidDocumentException : Exception
	{}

	public class WordInstanceException : Exception
	{}

  
}
