namespace Toys.Module.Win.Editors
{
    partial class PreSchoolControl
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
            this.chkReading = new System.Windows.Forms.CheckBox();
            this.chkSocial = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PreSchool";
            // 
            // chkReading
            // 
            this.chkReading.AutoSize = true;
            this.chkReading.Location = new System.Drawing.Point(35, 60);
            this.chkReading.Name = "chkReading";
            this.chkReading.Size = new System.Drawing.Size(94, 17);
            this.chkReading.TabIndex = 2;
            this.chkReading.Text = "Helps Reading";
            this.chkReading.UseVisualStyleBackColor = true;
            // 
            // chkSocial
            // 
            this.chkSocial.AutoSize = true;
            this.chkSocial.Location = new System.Drawing.Point(35, 96);
            this.chkSocial.Name = "chkSocial";
            this.chkSocial.Size = new System.Drawing.Size(100, 17);
            this.chkSocial.TabIndex = 3;
            this.chkSocial.Text = "Good For Social";
            this.chkSocial.UseVisualStyleBackColor = true;
            // 
            // PreSchoolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkSocial);
            this.Controls.Add(this.chkReading);
            this.Controls.Add(this.label1);
            this.Name = "PreSchoolControl";
            this.Size = new System.Drawing.Size(236, 148);
            this.Load += new System.EventHandler(this.PreSchoolControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkReading;
        private System.Windows.Forms.CheckBox chkSocial;
    }
}
