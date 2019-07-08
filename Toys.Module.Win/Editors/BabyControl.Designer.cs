namespace Toys.Module.Win.Editors
{
    partial class BabyControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.chkTeething = new System.Windows.Forms.CheckBox();
            this.chkCrawling = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            // 
            // chkTeething
            // 
            this.chkTeething.Location = new System.Drawing.Point(38, 86);
            this.chkTeething.Name = "chkTeething";
            this.chkTeething.Size = new System.Drawing.Size(104, 24);
            this.chkTeething.TabIndex = 3;
            this.chkTeething.Text = "Helps Teething";
            // 
            // chkCrawling
            // 
            this.chkCrawling.AutoSize = true;
            this.chkCrawling.Location = new System.Drawing.Point(38, 142);
            this.chkCrawling.Name = "chkCrawling";
            this.chkCrawling.Size = new System.Drawing.Size(96, 17);
            this.chkCrawling.TabIndex = 2;
            this.chkCrawling.Text = "Helps Crawling";
            this.chkCrawling.UseVisualStyleBackColor = true;
            // 
            // BabyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkCrawling);
            this.Controls.Add(this.chkTeething);
            this.Controls.Add(this.label1);
            this.Name = "BabyControl";
            this.Size = new System.Drawing.Size(187, 264);
            this.Load += new System.EventHandler(this.BabyControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox chkTeething;
        internal System.Windows.Forms.CheckBox chkCrawling;
    }
}
