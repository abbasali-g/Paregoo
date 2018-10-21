using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Lawyer.Common.VB.Docs;
using System.Reflection;
using System.Windows.Forms;
using Lawyer.Common.VB.tempDocs;


namespace PareGooWord
{
    public partial class ParegooRibbon
    {
        static string content = string.Empty;
        static string tableName = string.Empty;
        static string fileName = string.Empty;
        static string conString =string.Empty;// "server=127.0.0.1;Port=9918;uid=root; pwd=@@%!mysqlnahani;database=nwdicdad2;";
        static string filePath = string.Empty;
        static string fileID = string.Empty;
        private void ParegooRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            try
            {

                try
                {
                    filePath = PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.FullName;
                    
                }
                catch (Exception ex)
                {
                    PareGooWord.Globals.Ribbons.ParegooRibbon.ribbonGrpSave.Visible = false;
                    PareGooWord.Globals.Ribbons.ParegooRibbon.grpPrint.Visible = false;
                    return;
                }

                System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
                fileID = System.IO.Path.GetFileNameWithoutExtension(filePath);
                System.IO.FileInfo fii = new System.IO.FileInfo(fi.DirectoryName + "\\" + fileID + ".txt");
                if (!fii.Exists)
                {
                    PareGooWord.Globals.Ribbons.ParegooRibbon.ribbonGrpSave.Visible = false;
                    PareGooWord.Globals.Ribbons.ParegooRibbon.grpPrint.Visible = false;
                    return;
                }
                              
                
                System.IO.TextReader tr = new System.IO.StreamReader(fi.DirectoryName + "\\" + fileID + ".txt");

                //filename,tablename,conString 
                fileName = Lawyer.Common.VB.Common.SecurityHelper.DecryptUTF(tr.ReadLine());
                tableName = Lawyer.Common.VB.Common.SecurityHelper.DecryptUTF(tr.ReadLine());
                conString = Lawyer.Common.VB.Common.SecurityHelper.DecryptUTF(tr.ReadLine());
                tr.Close();

                fii.Delete();
                FillCombobox();

            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show("خطا در آفیس:" + "\r\n" + ex.Message); }

           
        }

        private void btnSaveDocToParegoo_Click(object sender, RibbonControlEventArgs e)
        {
            saveFileToParegooDB();
        }

        private static void saveFileToParegooDB()
        {
            try
            {



                PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.Save();
               
                Microsoft.Office.Interop.Word.Shapes tx = PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.Shapes;
                for (int i = 0; i < tx.Count; i++)
                {
                    try
                    {
                        if (tx[i].Type == Microsoft.Office.Core.MsoShapeType.msoTextBox)
                            if (tx[i].TextFrame.TextRange.Text != "\r" && tx[i].TextFrame.TextRange.Text != " \r")
                                content += tx[i].TextFrame.TextRange.Text.Trim() + " ";
                    }
                    catch (Exception ex) { }
                }


                if (tableName == "tempdocs" && fileID != string.Empty)
                    TempDocManager.EditFile(fileID, filePath, content, conString);

                else if (tableName == "filedocs" && fileID != string.Empty)
                    FileDocManager.EditFile(fileID, filePath, content, conString);

                else if (tableName == "deskdocs" && fileID != string.Empty)
                    Lawyer.Common.VB.Timing.TimingManager.EditTimeDocs(filePath, fileName, conString);

                if (tableName != string.Empty && fileID != string.Empty)
                    System.Windows.Forms.MessageBox.Show("فایل ذخیره شد");

            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show("خطا در آفیس:" + "\r\n" + ex.Message); }
        }

        private void btnSaveAndClose_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                object dummy = null;
                saveFileToParegooDB();
                PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.Close(ref dummy, ref dummy, ref dummy);
                System.IO.FileInfo fii = new System.IO.FileInfo(filePath);
                fii.Delete();
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show("خطا در آفیس:" + "\r\n" + ex.Message); }
        }


        private void btnPrintParegooDoc_Click(object sender, RibbonControlEventArgs e)
        {
            showPrintDialog();

        }

        private static void showPrintDialog()
        {
            object nullobj = Missing.Value;
            int dialogResult = PareGooWord.Globals.ThisAddIn.Application.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint].Show(ref nullobj);
            if (dialogResult == 1)
            {
                PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.PrintOut(ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                             ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                             ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                             ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                             ref nullobj, ref nullobj);
            }
        }

        private void btnPrintOnLetter_Click(object sender, RibbonControlEventArgs e)
        {
            //if(!PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.ProtectionType== Microsoft.Office.Interop.Word.WdProtectionType.wdNoProtection)
            //    PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.Protect()
            int Undo_NO = 0;

            Microsoft.Office.Interop.Word.Shapes tx = PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.Shapes;
            for (int i = 0; i < tx.Count; i++)
            {
                try
                {
                    if (tx[i].Type == Microsoft.Office.Core.MsoShapeType.msoPicture)
                    {
                        tx[i].Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                        Undo_NO += 1;
                    }

                }
                catch (Exception ex) { }
            }

            Microsoft.Office.Interop.Word.Tables tb = PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.Tables;
            for (int i = 0; i < tb.Count; i++)
            {
                try
                {
                    tb[i].Borders.InsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorWhite;
                    tb[i].Borders.OutsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorWhite;
                    Undo_NO += 2;

                }
                catch (Exception ex) { }
            }

            showPrintDialog();

            for (int i = 0; i < Undo_NO; i++)
                PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.Undo();

        }

        private void cmbCat_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            tmDetail = tempDocsDetailManager.GetTempDocsReviewsByParentID(cmbCat.SelectedItem.Tag.ToString(), conString).ToList();
            FillType();
            
        }
        private void FillCombobox()
        {
            try
            {
                cmbCat.Items.Clear();
                List<tempDocDetailReview> tmDetail = tempDocsDetailManager.GetTempDocsReviewsByParentID(string.Empty, conString).ToList();
              
                foreach (var item in tmDetail)
                {
                    RibbonDropDownItem drpItem = this.Factory.CreateRibbonDropDownItem();
                    drpItem.Label = item.tpCatName;
                    drpItem.Tag = item.tpDID;
                    cmbCat.Items.Add(drpItem);
                }
                RibbonDropDownItem drpZero = this.Factory.CreateRibbonDropDownItem();
                drpZero.Label ="--انتخاب--";
                drpZero.Tag = "-1";
                cmbCat.Items.Insert(0, drpZero);

              

            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show("خطا در آفیس:" + "\r\n" + ex.Message); }

        }

        List<tempDocDetailReview> tmDetail = null;
        private void FillType()
        {
            try
            {
                cmbType.Items.Clear();
                if (cmbCat.SelectedItemIndex != 0)
                {

                   // tmDetail = tempDocsDetailManager.GetTempDocsReviewsByParentID(cmbCat.SelectedItem.Tag.ToString(), conString).ToList();
                    foreach (var item in tmDetail)
                    {
                        RibbonDropDownItem drpItem2 = this.Factory.CreateRibbonDropDownItem();
                        drpItem2.Label = item.tpCatName;
                        drpItem2.Tag = item.tpDID;
                        cmbType.Items.Add(drpItem2);
                    }
                }

            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show("خطا در آفیس:" + "\r\n" + ex.Message); }


        }

        private void txtFilter_TextChanged(object sender, RibbonControlEventArgs e)
        {
            tmDetail=tmDetail.Where( x => x.tpCatName.Contains(txtFilter.Text)).ToList();
            txtFilter.Text = string.Empty;
            FillType();
            
        }
        private void btnAddTemplateToLetter_Click(object sender, RibbonControlEventArgs e)
        {
            FillTypeChild();
        }

        private void FillTypeChild()
        {

            try
            {
                if (cmbType.SelectedItemIndex != -1)
                {
                    TempDocsDetailCollection t = tempDocsDetailManager.GetTempDocsByParentID(cmbType.SelectedItem.Tag.ToString(),conString);
                    if (t != null && t.Count > 0)
                        ReplaceDefaultText(t);
                }

            }
            catch (Exception)
            {
            }

        }
        public void ReplaceDefaultText(TempDocsDetailCollection content)
        {

            try
            {
                int count = 0;


                Microsoft.Office.Interop.Word.Shapes tx = PareGooWord.Globals.ThisAddIn.Application.ActiveDocument.Shapes;
                for (int i = 0; i < tx.Count; i++)
                {
                    try
                    {
                        if (tx[i].Type == Microsoft.Office.Core.MsoShapeType.msoTextBox)
                        {

                            foreach (TempDocsDetail item in content)
                            {
                                if (item.tpControlKey == tx[i].Name)
                                {
                                    tx[i].TextFrame.TextRange.Text = "\n" + item.tpkeyContent;

                                    break;
                                }
                            }

                        }

                    }
                    catch (Exception ex) { }
                }


            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show("خطا در آفیس:" + "\r\n" + ex.Message); }

        }

        private void btnRefresh_Click(object sender, RibbonControlEventArgs e)
        {
            tmDetail = tempDocsDetailManager.GetTempDocsReviewsByParentID(cmbCat.SelectedItem.Tag.ToString(), conString).ToList();
            FillType();
        }

       

        
    
    }

}