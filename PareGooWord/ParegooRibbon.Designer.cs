namespace PareGooWord
{
    partial class ParegooRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ParegooRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParegooRibbon));
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl3 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl4 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl5 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl6 = this.Factory.CreateRibbonDropDownItem();
            this.tabParegoo = this.Factory.CreateRibbonTab();
            this.ribbonGrpSave = this.Factory.CreateRibbonGroup();
            this.btnSaveDocToParegoo = this.Factory.CreateRibbonButton();
            this.btnSaveAndClose = this.Factory.CreateRibbonButton();
            this.grpPrint = this.Factory.CreateRibbonGroup();
            this.btnPrintParegooDoc = this.Factory.CreateRibbonButton();
            this.btnPrintOnLetter = this.Factory.CreateRibbonButton();
            this.grpTemplateLetter = this.Factory.CreateRibbonGroup();
            this.cmbCat = this.Factory.CreateRibbonDropDown();
            this.cmbType = this.Factory.CreateRibbonDropDown();
            this.txtFilter = this.Factory.CreateRibbonEditBox();
            this.btnAddTemplateToLetter = this.Factory.CreateRibbonButton();
            this.btnRefresh = this.Factory.CreateRibbonButton();
            this.tabParegoo.SuspendLayout();
            this.ribbonGrpSave.SuspendLayout();
            this.grpPrint.SuspendLayout();
            this.grpTemplateLetter.SuspendLayout();
            // 
            // tabParegoo
            // 
            this.tabParegoo.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabParegoo.Groups.Add(this.ribbonGrpSave);
            this.tabParegoo.Groups.Add(this.grpPrint);
            this.tabParegoo.Groups.Add(this.grpTemplateLetter);
            this.tabParegoo.Label = "پرقو";
            this.tabParegoo.Name = "tabParegoo";
            // 
            // ribbonGrpSave
            // 
            this.ribbonGrpSave.Items.Add(this.btnSaveDocToParegoo);
            this.ribbonGrpSave.Items.Add(this.btnSaveAndClose);
            this.ribbonGrpSave.Label = "ذخیره";
            this.ribbonGrpSave.Name = "ribbonGrpSave";
            // 
            // btnSaveDocToParegoo
            // 
            this.btnSaveDocToParegoo.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveDocToParegoo.Image")));
            this.btnSaveDocToParegoo.Label = "ذخیره در پرقو";
            this.btnSaveDocToParegoo.Name = "btnSaveDocToParegoo";
            this.btnSaveDocToParegoo.ShowImage = true;
            this.btnSaveDocToParegoo.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSaveDocToParegoo_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Image")));
            this.btnSaveAndClose.Label = "ذخیره و بستن";
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.ShowImage = true;
            this.btnSaveAndClose.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSaveAndClose_Click);
            // 
            // grpPrint
            // 
            this.grpPrint.Items.Add(this.btnPrintParegooDoc);
            this.grpPrint.Items.Add(this.btnPrintOnLetter);
            this.grpPrint.Label = "چاپ";
            this.grpPrint.Name = "grpPrint";
            // 
            // btnPrintParegooDoc
            // 
            this.btnPrintParegooDoc.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintParegooDoc.Image")));
            this.btnPrintParegooDoc.Label = "چاپ";
            this.btnPrintParegooDoc.Name = "btnPrintParegooDoc";
            this.btnPrintParegooDoc.ShowImage = true;
            this.btnPrintParegooDoc.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPrintParegooDoc_Click);
            // 
            // btnPrintOnLetter
            // 
            this.btnPrintOnLetter.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintOnLetter.Image")));
            this.btnPrintOnLetter.Label = "چاپ روی فرم اصلی";
            this.btnPrintOnLetter.Name = "btnPrintOnLetter";
            this.btnPrintOnLetter.ShowImage = true;
            this.btnPrintOnLetter.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPrintOnLetter_Click);
            // 
            // grpTemplateLetter
            // 
            this.grpTemplateLetter.Items.Add(this.cmbCat);
            this.grpTemplateLetter.Items.Add(this.cmbType);
            this.grpTemplateLetter.Items.Add(this.txtFilter);
            this.grpTemplateLetter.Items.Add(this.btnAddTemplateToLetter);
            this.grpTemplateLetter.Items.Add(this.btnRefresh);
            this.grpTemplateLetter.Label = "متون تیپ";
            this.grpTemplateLetter.Name = "grpTemplateLetter";
            // 
            // cmbCat
            // 
            this.cmbCat.Image = ((System.Drawing.Image)(resources.GetObject("cmbCat.Image")));
            ribbonDropDownItemImpl1.Label = "Item0";
            ribbonDropDownItemImpl2.Label = "Item1";
            ribbonDropDownItemImpl3.Label = "Item2";
            ribbonDropDownItemImpl4.Label = "Item3";
            ribbonDropDownItemImpl5.Label = "Item4";
            ribbonDropDownItemImpl6.Label = "Item5";
            this.cmbCat.Items.Add(ribbonDropDownItemImpl1);
            this.cmbCat.Items.Add(ribbonDropDownItemImpl2);
            this.cmbCat.Items.Add(ribbonDropDownItemImpl3);
            this.cmbCat.Items.Add(ribbonDropDownItemImpl4);
            this.cmbCat.Items.Add(ribbonDropDownItemImpl5);
            this.cmbCat.Items.Add(ribbonDropDownItemImpl6);
            this.cmbCat.Label = "نوع";
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.ShowImage = true;
            this.cmbCat.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.cmbCat_SelectionChanged);
            // 
            // cmbType
            // 
            this.cmbType.Image = ((System.Drawing.Image)(resources.GetObject("cmbType.Image")));
            this.cmbType.Label = "عنوان";
            this.cmbType.Name = "cmbType";
            this.cmbType.ShowImage = true;
            // 
            // txtFilter
            // 
            this.txtFilter.Label = "فیلتر";
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Text = null;
            this.txtFilter.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.txtFilter_TextChanged);
            // 
            // btnAddTemplateToLetter
            // 
            this.btnAddTemplateToLetter.Label = "اضافه کردن";
            this.btnAddTemplateToLetter.Name = "btnAddTemplateToLetter";
            this.btnAddTemplateToLetter.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAddTemplateToLetter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Label = "تازه گردانی";
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRefresh_Click);
            // 
            // ParegooRibbon
            // 
            this.Name = "ParegooRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabParegoo);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ParegooRibbon_Load);
            this.tabParegoo.ResumeLayout(false);
            this.tabParegoo.PerformLayout();
            this.ribbonGrpSave.ResumeLayout(false);
            this.ribbonGrpSave.PerformLayout();
            this.grpPrint.ResumeLayout(false);
            this.grpPrint.PerformLayout();
            this.grpTemplateLetter.ResumeLayout(false);
            this.grpTemplateLetter.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabParegoo;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ribbonGrpSave;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSaveDocToParegoo;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPrintParegooDoc;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPrintOnLetter;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpPrint;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpTemplateLetter;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown cmbCat;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown cmbType;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSaveAndClose;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAddTemplateToLetter;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox txtFilter;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRefresh;
    }

    partial class ThisRibbonCollection
    {
        internal ParegooRibbon ParegooRibbon
        {
            get { return this.GetRibbon<ParegooRibbon>(); }
        }
    }
}
