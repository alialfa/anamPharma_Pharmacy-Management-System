namespace Anam_Pharma
{
    partial class ClientDosage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.units_lbl = new System.Windows.Forms.Label();
            this.unitsOUT_txt = new MetroFramework.Controls.MetroTextBox();
            this.done_btn = new MetroFramework.Controls.MetroButton();
            this.cancel_btn = new MetroFramework.Controls.MetroButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prodName_lbl = new System.Windows.Forms.Label();
            this.dosage_txt = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.units_lbl);
            this.groupBox1.Controls.Add(this.unitsOUT_txt);
            this.groupBox1.Controls.Add(this.done_btn);
            this.groupBox1.Controls.Add(this.cancel_btn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.prodName_lbl);
            this.groupBox1.Controls.Add(this.dosage_txt);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(27, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 208);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // units_lbl
            // 
            this.units_lbl.AutoSize = true;
            this.units_lbl.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.units_lbl.ForeColor = System.Drawing.Color.OliveDrab;
            this.units_lbl.Location = new System.Drawing.Point(357, 36);
            this.units_lbl.Name = "units_lbl";
            this.units_lbl.Size = new System.Drawing.Size(94, 23);
            this.units_lbl.TabIndex = 37;
            this.units_lbl.Text = "502315";
            // 
            // unitsOUT_txt
            // 
            // 
            // 
            // 
            this.unitsOUT_txt.CustomButton.Image = null;
            this.unitsOUT_txt.CustomButton.Location = new System.Drawing.Point(119, 2);
            this.unitsOUT_txt.CustomButton.Name = "";
            this.unitsOUT_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.unitsOUT_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.unitsOUT_txt.CustomButton.TabIndex = 1;
            this.unitsOUT_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.unitsOUT_txt.CustomButton.UseSelectable = true;
            this.unitsOUT_txt.CustomButton.Visible = false;
            this.unitsOUT_txt.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.unitsOUT_txt.Lines = new string[0];
            this.unitsOUT_txt.Location = new System.Drawing.Point(11, 71);
            this.unitsOUT_txt.MaxLength = 32767;
            this.unitsOUT_txt.Name = "unitsOUT_txt";
            this.unitsOUT_txt.PasswordChar = '\0';
            this.unitsOUT_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.unitsOUT_txt.SelectedText = "";
            this.unitsOUT_txt.SelectionLength = 0;
            this.unitsOUT_txt.SelectionStart = 0;
            this.unitsOUT_txt.Size = new System.Drawing.Size(143, 26);
            this.unitsOUT_txt.TabIndex = 1;
            this.unitsOUT_txt.UseSelectable = true;
            this.unitsOUT_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.unitsOUT_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // done_btn
            // 
            this.done_btn.Location = new System.Drawing.Point(322, 172);
            this.done_btn.Name = "done_btn";
            this.done_btn.Size = new System.Drawing.Size(129, 25);
            this.done_btn.TabIndex = 3;
            this.done_btn.Text = "Done";
            this.done_btn.UseSelectable = true;
            this.done_btn.Click += new System.EventHandler(this.done_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(10, 172);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(129, 25);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseSelectable = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(341, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "[ Units Available ]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Quantity Dispensed:";
            // 
            // prodName_lbl
            // 
            this.prodName_lbl.AutoSize = true;
            this.prodName_lbl.BackColor = System.Drawing.Color.OliveDrab;
            this.prodName_lbl.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodName_lbl.ForeColor = System.Drawing.Color.White;
            this.prodName_lbl.Location = new System.Drawing.Point(8, 16);
            this.prodName_lbl.Name = "prodName_lbl";
            this.prodName_lbl.Size = new System.Drawing.Size(281, 22);
            this.prodName_lbl.TabIndex = 30;
            this.prodName_lbl.Text = "........... stock name displayed here";
            // 
            // dosage_txt
            // 
            this.dosage_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dosage_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dosage_txt.Location = new System.Drawing.Point(10, 123);
            this.dosage_txt.Name = "dosage_txt";
            this.dosage_txt.Size = new System.Drawing.Size(441, 43);
            this.dosage_txt.TabIndex = 2;
            this.dosage_txt.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(8, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "Instructions:";
            // 
            // ClientDosage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 300);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(525, 300);
            this.MinimizeBox = false;
            this.Name = "ClientDosage";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Drugs Dispensed";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox dosage_txt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label prodName_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroButton done_btn;
        private MetroFramework.Controls.MetroButton cancel_btn;
        private System.Windows.Forms.Label units_lbl;
        private MetroFramework.Controls.MetroTextBox unitsOUT_txt;

    }
}