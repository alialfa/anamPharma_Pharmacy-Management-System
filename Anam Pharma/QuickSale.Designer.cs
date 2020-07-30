namespace Anam_Pharma
{
    partial class QuickSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickSale));
            this.saleItems_listbox = new System.Windows.Forms.ListBox();
            this.query_grp = new System.Windows.Forms.GroupBox();
            this.btnremoveItem = new MetroFramework.Controls.MetroButton();
            this.btnaddItem = new MetroFramework.Controls.MetroButton();
            this.btnPrintReciept = new MetroFramework.Controls.MetroButton();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new MetroFramework.Controls.MetroTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCash = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.query_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // saleItems_listbox
            // 
            this.saleItems_listbox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.saleItems_listbox.FormattingEnabled = true;
            this.saleItems_listbox.Location = new System.Drawing.Point(23, 63);
            this.saleItems_listbox.Name = "saleItems_listbox";
            this.saleItems_listbox.Size = new System.Drawing.Size(771, 264);
            this.saleItems_listbox.TabIndex = 0;
            // 
            // query_grp
            // 
            this.query_grp.BackColor = System.Drawing.Color.White;
            this.query_grp.Controls.Add(this.txtCash);
            this.query_grp.Controls.Add(this.label2);
            this.query_grp.Controls.Add(this.txtName);
            this.query_grp.Controls.Add(this.label1);
            this.query_grp.Controls.Add(this.txtPrice);
            this.query_grp.Controls.Add(this.label17);
            this.query_grp.Controls.Add(this.btnPrintReciept);
            this.query_grp.Controls.Add(this.btnremoveItem);
            this.query_grp.Controls.Add(this.btnaddItem);
            this.query_grp.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.query_grp.ForeColor = System.Drawing.Color.DarkGreen;
            this.query_grp.Location = new System.Drawing.Point(23, 342);
            this.query_grp.Name = "query_grp";
            this.query_grp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.query_grp.Size = new System.Drawing.Size(771, 96);
            this.query_grp.TabIndex = 23;
            this.query_grp.TabStop = false;
            // 
            // btnremoveItem
            // 
            this.btnremoveItem.BackColor = System.Drawing.Color.LightGray;
            this.btnremoveItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnremoveItem.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnremoveItem.Location = new System.Drawing.Point(479, 19);
            this.btnremoveItem.Name = "btnremoveItem";
            this.btnremoveItem.Size = new System.Drawing.Size(126, 33);
            this.btnremoveItem.TabIndex = 18;
            this.btnremoveItem.Text = "Remove Item";
            this.btnremoveItem.UseSelectable = true;
            this.btnremoveItem.Click += new System.EventHandler(this.btnremoveItem_Click);
            // 
            // btnaddItem
            // 
            this.btnaddItem.BackColor = System.Drawing.Color.LightGray;
            this.btnaddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnaddItem.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnaddItem.Location = new System.Drawing.Point(347, 19);
            this.btnaddItem.Name = "btnaddItem";
            this.btnaddItem.Size = new System.Drawing.Size(126, 33);
            this.btnaddItem.TabIndex = 15;
            this.btnaddItem.Text = "Add Item";
            this.btnaddItem.UseSelectable = true;
            this.btnaddItem.Click += new System.EventHandler(this.btnaddItem_Click);
            // 
            // btnPrintReciept
            // 
            this.btnPrintReciept.BackColor = System.Drawing.Color.White;
            this.btnPrintReciept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintReciept.BackgroundImage")));
            this.btnPrintReciept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrintReciept.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnPrintReciept.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.btnPrintReciept.Location = new System.Drawing.Point(611, 19);
            this.btnPrintReciept.Name = "btnPrintReciept";
            this.btnPrintReciept.Size = new System.Drawing.Size(62, 51);
            this.btnPrintReciept.TabIndex = 37;
            this.btnPrintReciept.UseSelectable = true;
            this.btnPrintReciept.Click += new System.EventHandler(this.btnPrintReciept_Click);
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.CustomButton.Image = null;
            this.txtName.CustomButton.Location = new System.Drawing.Point(176, 2);
            this.txtName.CustomButton.Name = "";
            this.txtName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtName.CustomButton.TabIndex = 1;
            this.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtName.CustomButton.UseSelectable = true;
            this.txtName.CustomButton.Visible = false;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(129, 19);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.Size = new System.Drawing.Size(200, 26);
            this.txtName.TabIndex = 41;
            this.txtName.UseSelectable = true;
            this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Product Name";
            // 
            // txtPrice
            // 
            // 
            // 
            // 
            this.txtPrice.CustomButton.Image = null;
            this.txtPrice.CustomButton.Location = new System.Drawing.Point(176, 2);
            this.txtPrice.CustomButton.Name = "";
            this.txtPrice.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrice.CustomButton.TabIndex = 1;
            this.txtPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrice.CustomButton.UseSelectable = true;
            this.txtPrice.CustomButton.Visible = false;
            this.txtPrice.Lines = new string[0];
            this.txtPrice.Location = new System.Drawing.Point(129, 51);
            this.txtPrice.MaxLength = 32767;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrice.SelectedText = "";
            this.txtPrice.SelectionLength = 0;
            this.txtPrice.SelectionStart = 0;
            this.txtPrice.Size = new System.Drawing.Size(200, 26);
            this.txtPrice.TabIndex = 39;
            this.txtPrice.UseSelectable = true;
            this.txtPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(78, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 20);
            this.label17.TabIndex = 38;
            this.label17.Text = "Price";
            // 
            // txtCash
            // 
            // 
            // 
            // 
            this.txtCash.CustomButton.Image = null;
            this.txtCash.CustomButton.Location = new System.Drawing.Point(62, 2);
            this.txtCash.CustomButton.Name = "";
            this.txtCash.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCash.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCash.CustomButton.TabIndex = 1;
            this.txtCash.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCash.CustomButton.UseSelectable = true;
            this.txtCash.CustomButton.Visible = false;
            this.txtCash.Lines = new string[0];
            this.txtCash.Location = new System.Drawing.Point(679, 45);
            this.txtCash.MaxLength = 32767;
            this.txtCash.Name = "txtCash";
            this.txtCash.PasswordChar = '\0';
            this.txtCash.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCash.SelectedText = "";
            this.txtCash.SelectionLength = 0;
            this.txtCash.SelectionStart = 0;
            this.txtCash.Size = new System.Drawing.Size(86, 26);
            this.txtCash.TabIndex = 43;
            this.txtCash.UseSelectable = true;
            this.txtCash.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCash.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(679, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Cash";
            // 
            // QuickSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 470);
            this.Controls.Add(this.query_grp);
            this.Controls.Add(this.saleItems_listbox);
            this.Name = "QuickSale";
            this.Text = "QuickSale";
            this.query_grp.ResumeLayout(false);
            this.query_grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox saleItems_listbox;
        private System.Windows.Forms.GroupBox query_grp;
        private MetroFramework.Controls.MetroButton btnremoveItem;
        private MetroFramework.Controls.MetroButton btnaddItem;
        private MetroFramework.Controls.MetroButton btnPrintReciept;
        private MetroFramework.Controls.MetroTextBox txtCash;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox txtName;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox txtPrice;
        private System.Windows.Forms.Label label17;
    }
}