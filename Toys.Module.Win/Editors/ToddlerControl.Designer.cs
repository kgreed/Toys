namespace Toys.Module.Win.Editors
{
    partial class ToddlerControl
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
            this.chkHelpsTalking = new System.Windows.Forms.CheckBox();
            this.chkGoodForWalking = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Toddler";
            // 
            // chkHelpsTalking
            // 
            this.chkHelpsTalking.AutoSize = true;
            this.chkHelpsTalking.Location = new System.Drawing.Point(24, 56);
            this.chkHelpsTalking.Name = "chkHelpsTalking";
            this.chkHelpsTalking.Size = new System.Drawing.Size(88, 17);
            this.chkHelpsTalking.TabIndex = 2;
            this.chkHelpsTalking.Text = "Helps Talking";
            this.chkHelpsTalking.UseVisualStyleBackColor = true;
            // 
            // chkGoodForWalking
            // 
            this.chkGoodForWalking.AutoSize = true;
            this.chkGoodForWalking.Location = new System.Drawing.Point(24, 96);
            this.chkGoodForWalking.Name = "chkGoodForWalking";
            this.chkGoodForWalking.Size = new System.Drawing.Size(110, 17);
            this.chkGoodForWalking.TabIndex = 3;
            this.chkGoodForWalking.Text = "Good For Walking";
            this.chkGoodForWalking.UseVisualStyleBackColor = true;
            // 
            // ToddlerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkGoodForWalking);
            this.Controls.Add(this.chkHelpsTalking);
            this.Controls.Add(this.label1);
            this.Name = "ToddlerControl";
            this.Load += new System.EventHandler(this.ToddlerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHelpsTalking;
        private System.Windows.Forms.CheckBox chkGoodForWalking;
    }
}
