namespace Anam_Pharma
{
    partial class ClientPresDoctor
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
            this.presDocName_txt = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.done_btn = new MetroFramework.Controls.MetroButton();
            this.cancel_btn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // presDocName_txt
            // 
            // 
            // 
            // 
            this.presDocName_txt.CustomButton.Image = null;
            this.presDocName_txt.CustomButton.Location = new System.Drawing.Point(225, 2);
            this.presDocName_txt.CustomButton.Name = "";
            this.presDocName_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.presDocName_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.presDocName_txt.CustomButton.TabIndex = 1;
            this.presDocName_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.presDocName_txt.CustomButton.UseSelectable = true;
            this.presDocName_txt.CustomButton.Visible = false;
            this.presDocName_txt.Lines = new string[] {
        "Dr."};
            this.presDocName_txt.Location = new System.Drawing.Point(12, 40);
            this.presDocName_txt.MaxLength = 32767;
            this.presDocName_txt.Name = "presDocName_txt";
            this.presDocName_txt.PasswordChar = '\0';
            this.presDocName_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.presDocName_txt.SelectedText = "";
            this.presDocName_txt.SelectionLength = 0;
            this.presDocName_txt.SelectionStart = 0;
            this.presDocName_txt.Size = new System.Drawing.Size(249, 26);
            this.presDocName_txt.TabIndex = 35;
            this.presDocName_txt.Text = "Dr.";
            this.presDocName_txt.UseSelectable = true;
            this.presDocName_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.presDocName_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Prescribing Doctor\'s Name:";
            // 
            // done_btn
            // 
            this.done_btn.Location = new System.Drawing.Point(161, 72);
            this.done_btn.Name = "done_btn";
            this.done_btn.Size = new System.Drawing.Size(100, 23);
            this.done_btn.TabIndex = 36;
            this.done_btn.Text = "Done";
            this.done_btn.UseSelectable = true;
            this.done_btn.Click += new System.EventHandler(this.done_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(12, 72);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(100, 23);
            this.cancel_btn.TabIndex = 37;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseSelectable = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // ClientPresDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 108);
            this.Controls.Add(this.done_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.presDocName_txt);
            this.Controls.Add(this.label2);
            this.MaximumSize = new System.Drawing.Size(273, 108);
            this.Name = "ClientPresDoctor";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox presDocName_txt;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton done_btn;
        private MetroFramework.Controls.MetroButton cancel_btn;
    }
}