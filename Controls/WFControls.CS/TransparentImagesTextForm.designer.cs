namespace WindowsApplication1
{
    partial class TransparentImagesTextForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.transparencyPanel1 = new TransparencyPanel();
            this.SuspendLayout();
            // 
            // transparencyPanel1
            // 
            this.transparencyPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparencyPanel1.Name = "transparencyPanel1";
            this.transparencyPanel1.Size = new System.Drawing.Size(200, 196);
            this.transparencyPanel1.TabIndex = 0;
            // 
            // TransparentImagesTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 239);
            this.Controls.Add(this.transparencyPanel1);
            this.Name = "TransparentImagesTextForm";
            this.Text = "Transparent Images and Text";
            this.ResumeLayout(false);

        }

        #endregion

        private TransparencyPanel transparencyPanel1;



    }
}