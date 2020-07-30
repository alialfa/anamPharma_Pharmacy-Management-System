namespace Anam_Pharma
{
    partial class Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.actions_grp = new System.Windows.Forms.GroupBox();
            this.remove_btn = new MetroFramework.Controls.MetroButton();
            this.new_btn = new MetroFramework.Controls.MetroButton();
            this.edit_btn = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.employeeDetails_grp = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.password_txt = new MetroFramework.Controls.MetroTextBox();
            this.name_txt = new MetroFramework.Controls.MetroTextBox();
            this.surname_txt = new MetroFramework.Controls.MetroTextBox();
            this.regno_txt = new MetroFramework.Controls.MetroTextBox();
            this.designation_txt = new MetroFramework.Controls.MetroTextBox();
            this.clear_btn = new MetroFramework.Controls.MetroButton();
            this.query_grp = new System.Windows.Forms.GroupBox();
            this.cancel_btn = new MetroFramework.Controls.MetroButton();
            this.done_btn = new MetroFramework.Controls.MetroButton();
            this.delete_btn = new MetroFramework.Controls.MetroButton();
            this.update_btn = new MetroFramework.Controls.MetroButton();
            this.save_btn = new MetroFramework.Controls.MetroButton();
            this.loadEmpTable_btn = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.username_txt = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eid_txt = new MetroFramework.Controls.MetroTextBox();
            this.employeeGrid = new MetroFramework.Controls.MetroGrid();
            this.home_btn = new System.Windows.Forms.Button();
            this.metroTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.actions_grp.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.employeeDetails_grp.SuspendLayout();
            this.query_grp.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(47, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Reg No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(20, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "First Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(34, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Surname";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(15, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 20);
            this.label15.TabIndex = 3;
            this.label15.Text = "Designation";
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(27, 65);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1180, 688);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTabControl1.TabIndex = 20;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.actions_grp);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1172, 646);
            this.tabPage2.TabIndex = 0;
            // 
            // actions_grp
            // 
            this.actions_grp.BackColor = System.Drawing.Color.White;
            this.actions_grp.Controls.Add(this.remove_btn);
            this.actions_grp.Controls.Add(this.new_btn);
            this.actions_grp.Controls.Add(this.edit_btn);
            this.actions_grp.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actions_grp.ForeColor = System.Drawing.Color.DarkBlue;
            this.actions_grp.Location = new System.Drawing.Point(8, 11);
            this.actions_grp.Name = "actions_grp";
            this.actions_grp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.actions_grp.Size = new System.Drawing.Size(227, 95);
            this.actions_grp.TabIndex = 29;
            this.actions_grp.TabStop = false;
            // 
            // remove_btn
            // 
            this.remove_btn.BackColor = System.Drawing.Color.LightGray;
            this.remove_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("remove_btn.BackgroundImage")));
            this.remove_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.remove_btn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.remove_btn.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.remove_btn.Location = new System.Drawing.Point(152, 20);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(65, 65);
            this.remove_btn.TabIndex = 21;
            this.remove_btn.Text = "Remove";
            this.remove_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.remove_btn.UseSelectable = true;
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.BackColor = System.Drawing.Color.LightGray;
            this.new_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("new_btn.BackgroundImage")));
            this.new_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.new_btn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.new_btn.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.new_btn.Location = new System.Drawing.Point(10, 20);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(65, 65);
            this.new_btn.TabIndex = 20;
            this.new_btn.Text = "New";
            this.new_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.new_btn.UseSelectable = true;
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.BackColor = System.Drawing.Color.LightGray;
            this.edit_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("edit_btn.BackgroundImage")));
            this.edit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edit_btn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.edit_btn.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.edit_btn.Location = new System.Drawing.Point(81, 20);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(65, 65);
            this.edit_btn.TabIndex = 19;
            this.edit_btn.Text = "Edit";
            this.edit_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.edit_btn.UseSelectable = true;
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(2, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1156, 588);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.employeeDetails_grp);
            this.groupBox5.Controls.Add(this.clear_btn);
            this.groupBox5.Controls.Add(this.query_grp);
            this.groupBox5.Controls.Add(this.loadEmpTable_btn);
            this.groupBox5.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox5.Location = new System.Drawing.Point(10, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(362, 400);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            // 
            // employeeDetails_grp
            // 
            this.employeeDetails_grp.BackColor = System.Drawing.Color.Transparent;
            this.employeeDetails_grp.Controls.Add(this.label8);
            this.employeeDetails_grp.Controls.Add(this.password_txt);
            this.employeeDetails_grp.Controls.Add(this.name_txt);
            this.employeeDetails_grp.Controls.Add(this.label15);
            this.employeeDetails_grp.Controls.Add(this.label5);
            this.employeeDetails_grp.Controls.Add(this.surname_txt);
            this.employeeDetails_grp.Controls.Add(this.regno_txt);
            this.employeeDetails_grp.Controls.Add(this.label6);
            this.employeeDetails_grp.Controls.Add(this.designation_txt);
            this.employeeDetails_grp.Controls.Add(this.label7);
            this.employeeDetails_grp.Enabled = false;
            this.employeeDetails_grp.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeDetails_grp.ForeColor = System.Drawing.Color.Black;
            this.employeeDetails_grp.Location = new System.Drawing.Point(15, 24);
            this.employeeDetails_grp.Name = "employeeDetails_grp";
            this.employeeDetails_grp.Size = new System.Drawing.Size(332, 190);
            this.employeeDetails_grp.TabIndex = 14;
            this.employeeDetails_grp.TabStop = false;
            this.employeeDetails_grp.Text = "Details";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(33, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Password";
            // 
            // password_txt
            // 
            // 
            // 
            // 
            this.password_txt.CustomButton.Image = null;
            this.password_txt.CustomButton.Location = new System.Drawing.Point(176, 2);
            this.password_txt.CustomButton.Name = "";
            this.password_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.password_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.password_txt.CustomButton.TabIndex = 1;
            this.password_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.password_txt.CustomButton.UseSelectable = true;
            this.password_txt.CustomButton.Visible = false;
            this.password_txt.Lines = new string[0];
            this.password_txt.Location = new System.Drawing.Point(111, 152);
            this.password_txt.MaxLength = 32767;
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '\0';
            this.password_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password_txt.SelectedText = "";
            this.password_txt.SelectionLength = 0;
            this.password_txt.SelectionStart = 0;
            this.password_txt.Size = new System.Drawing.Size(200, 26);
            this.password_txt.TabIndex = 28;
            this.password_txt.UseSelectable = true;
            this.password_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.password_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // name_txt
            // 
            // 
            // 
            // 
            this.name_txt.CustomButton.Image = null;
            this.name_txt.CustomButton.Location = new System.Drawing.Point(176, 2);
            this.name_txt.CustomButton.Name = "";
            this.name_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.name_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.name_txt.CustomButton.TabIndex = 1;
            this.name_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.name_txt.CustomButton.UseSelectable = true;
            this.name_txt.CustomButton.Visible = false;
            this.name_txt.Lines = new string[0];
            this.name_txt.Location = new System.Drawing.Point(111, 24);
            this.name_txt.MaxLength = 32767;
            this.name_txt.Name = "name_txt";
            this.name_txt.PasswordChar = '\0';
            this.name_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.name_txt.SelectedText = "";
            this.name_txt.SelectionLength = 0;
            this.name_txt.SelectionStart = 0;
            this.name_txt.Size = new System.Drawing.Size(200, 26);
            this.name_txt.TabIndex = 3;
            this.name_txt.UseSelectable = true;
            this.name_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.name_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // surname_txt
            // 
            // 
            // 
            // 
            this.surname_txt.CustomButton.Image = null;
            this.surname_txt.CustomButton.Location = new System.Drawing.Point(176, 2);
            this.surname_txt.CustomButton.Name = "";
            this.surname_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.surname_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.surname_txt.CustomButton.TabIndex = 1;
            this.surname_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.surname_txt.CustomButton.UseSelectable = true;
            this.surname_txt.CustomButton.Visible = false;
            this.surname_txt.Lines = new string[0];
            this.surname_txt.Location = new System.Drawing.Point(111, 56);
            this.surname_txt.MaxLength = 32767;
            this.surname_txt.Name = "surname_txt";
            this.surname_txt.PasswordChar = '\0';
            this.surname_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.surname_txt.SelectedText = "";
            this.surname_txt.SelectionLength = 0;
            this.surname_txt.SelectionStart = 0;
            this.surname_txt.Size = new System.Drawing.Size(200, 26);
            this.surname_txt.TabIndex = 4;
            this.surname_txt.UseSelectable = true;
            this.surname_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.surname_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // regno_txt
            // 
            // 
            // 
            // 
            this.regno_txt.CustomButton.Image = null;
            this.regno_txt.CustomButton.Location = new System.Drawing.Point(176, 2);
            this.regno_txt.CustomButton.Name = "";
            this.regno_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.regno_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.regno_txt.CustomButton.TabIndex = 1;
            this.regno_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.regno_txt.CustomButton.UseSelectable = true;
            this.regno_txt.CustomButton.Visible = false;
            this.regno_txt.Lines = new string[0];
            this.regno_txt.Location = new System.Drawing.Point(111, 120);
            this.regno_txt.MaxLength = 32767;
            this.regno_txt.Name = "regno_txt";
            this.regno_txt.PasswordChar = '\0';
            this.regno_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.regno_txt.SelectedText = "";
            this.regno_txt.SelectionLength = 0;
            this.regno_txt.SelectionStart = 0;
            this.regno_txt.Size = new System.Drawing.Size(200, 26);
            this.regno_txt.TabIndex = 6;
            this.regno_txt.UseSelectable = true;
            this.regno_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.regno_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // designation_txt
            // 
            // 
            // 
            // 
            this.designation_txt.CustomButton.Image = null;
            this.designation_txt.CustomButton.Location = new System.Drawing.Point(176, 2);
            this.designation_txt.CustomButton.Name = "";
            this.designation_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.designation_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.designation_txt.CustomButton.TabIndex = 1;
            this.designation_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.designation_txt.CustomButton.UseSelectable = true;
            this.designation_txt.CustomButton.Visible = false;
            this.designation_txt.Lines = new string[0];
            this.designation_txt.Location = new System.Drawing.Point(111, 88);
            this.designation_txt.MaxLength = 32767;
            this.designation_txt.Name = "designation_txt";
            this.designation_txt.PasswordChar = '\0';
            this.designation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.designation_txt.SelectedText = "";
            this.designation_txt.SelectionLength = 0;
            this.designation_txt.SelectionStart = 0;
            this.designation_txt.Size = new System.Drawing.Size(200, 26);
            this.designation_txt.TabIndex = 7;
            this.designation_txt.UseSelectable = true;
            this.designation_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.designation_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(247, 368);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(100, 23);
            this.clear_btn.TabIndex = 31;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseSelectable = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // query_grp
            // 
            this.query_grp.BackColor = System.Drawing.Color.White;
            this.query_grp.Controls.Add(this.cancel_btn);
            this.query_grp.Controls.Add(this.done_btn);
            this.query_grp.Controls.Add(this.delete_btn);
            this.query_grp.Controls.Add(this.update_btn);
            this.query_grp.Controls.Add(this.save_btn);
            this.query_grp.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.query_grp.ForeColor = System.Drawing.Color.DarkGreen;
            this.query_grp.Location = new System.Drawing.Point(15, 220);
            this.query_grp.Name = "query_grp";
            this.query_grp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.query_grp.Size = new System.Drawing.Size(332, 96);
            this.query_grp.TabIndex = 22;
            this.query_grp.TabStop = false;
            this.query_grp.Visible = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(223, 62);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(100, 23);
            this.cancel_btn.TabIndex = 33;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseSelectable = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // done_btn
            // 
            this.done_btn.Enabled = false;
            this.done_btn.Location = new System.Drawing.Point(223, 20);
            this.done_btn.Name = "done_btn";
            this.done_btn.Size = new System.Drawing.Size(100, 23);
            this.done_btn.TabIndex = 32;
            this.done_btn.Text = "Done";
            this.done_btn.UseSelectable = true;
            this.done_btn.Click += new System.EventHandler(this.done_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.BackColor = System.Drawing.Color.LightGray;
            this.delete_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delete_btn.BackgroundImage")));
            this.delete_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.delete_btn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.delete_btn.Location = new System.Drawing.Point(152, 20);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(65, 65);
            this.delete_btn.TabIndex = 17;
            this.delete_btn.Text = "Delete";
            this.delete_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.delete_btn.UseSelectable = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.Color.LightGray;
            this.update_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("update_btn.BackgroundImage")));
            this.update_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.update_btn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.update_btn.Location = new System.Drawing.Point(81, 20);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(65, 65);
            this.update_btn.TabIndex = 18;
            this.update_btn.Text = "Update";
            this.update_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.update_btn.UseSelectable = true;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.LightGray;
            this.save_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("save_btn.BackgroundImage")));
            this.save_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.save_btn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.save_btn.Location = new System.Drawing.Point(10, 20);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(65, 65);
            this.save_btn.TabIndex = 15;
            this.save_btn.Text = "Save";
            this.save_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.save_btn.UseSelectable = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // loadEmpTable_btn
            // 
            this.loadEmpTable_btn.Image = null;
            this.loadEmpTable_btn.Location = new System.Drawing.Point(247, 322);
            this.loadEmpTable_btn.Name = "loadEmpTable_btn";
            this.loadEmpTable_btn.Size = new System.Drawing.Size(100, 40);
            this.loadEmpTable_btn.TabIndex = 30;
            this.loadEmpTable_btn.Text = "Load Table";
            this.loadEmpTable_btn.UseSelectable = true;
            this.loadEmpTable_btn.UseVisualStyleBackColor = true;
            this.loadEmpTable_btn.Click += new System.EventHandler(this.loadEmpTable_btn_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.username_txt);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.eid_txt);
            this.groupBox6.Controls.Add(this.employeeGrid);
            this.groupBox6.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(381, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox6.Size = new System.Drawing.Size(761, 400);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Record";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(72, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Username";
            this.label4.Visible = false;
            // 
            // username_txt
            // 
            // 
            // 
            // 
            this.username_txt.CustomButton.Image = null;
            this.username_txt.CustomButton.Location = new System.Drawing.Point(176, 2);
            this.username_txt.CustomButton.Name = "";
            this.username_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.username_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.username_txt.CustomButton.TabIndex = 1;
            this.username_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.username_txt.CustomButton.UseSelectable = true;
            this.username_txt.CustomButton.Visible = false;
            this.username_txt.Lines = new string[0];
            this.username_txt.Location = new System.Drawing.Point(157, 90);
            this.username_txt.MaxLength = 32767;
            this.username_txt.Name = "username_txt";
            this.username_txt.PasswordChar = '\0';
            this.username_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.username_txt.SelectedText = "";
            this.username_txt.SelectionLength = 0;
            this.username_txt.SelectionStart = 0;
            this.username_txt.Size = new System.Drawing.Size(200, 26);
            this.username_txt.TabIndex = 34;
            this.username_txt.UseSelectable = true;
            this.username_txt.Visible = false;
            this.username_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.username_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(54, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Employee ID";
            this.label2.Visible = false;
            // 
            // eid_txt
            // 
            // 
            // 
            // 
            this.eid_txt.CustomButton.Image = null;
            this.eid_txt.CustomButton.Location = new System.Drawing.Point(176, 2);
            this.eid_txt.CustomButton.Name = "";
            this.eid_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.eid_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.eid_txt.CustomButton.TabIndex = 1;
            this.eid_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.eid_txt.CustomButton.UseSelectable = true;
            this.eid_txt.CustomButton.Visible = false;
            this.eid_txt.Enabled = false;
            this.eid_txt.Lines = new string[0];
            this.eid_txt.Location = new System.Drawing.Point(157, 48);
            this.eid_txt.MaxLength = 32767;
            this.eid_txt.Name = "eid_txt";
            this.eid_txt.PasswordChar = '\0';
            this.eid_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.eid_txt.SelectedText = "";
            this.eid_txt.SelectionLength = 0;
            this.eid_txt.SelectionStart = 0;
            this.eid_txt.Size = new System.Drawing.Size(200, 26);
            this.eid_txt.TabIndex = 32;
            this.eid_txt.UseSelectable = true;
            this.eid_txt.Visible = false;
            this.eid_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.eid_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // employeeGrid
            // 
            this.employeeGrid.AllowUserToResizeRows = false;
            this.employeeGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.employeeGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.employeeGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.employeeGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(219)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.employeeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(219)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.employeeGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.employeeGrid.EnableHeadersVisualStyles = false;
            this.employeeGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.employeeGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.employeeGrid.Location = new System.Drawing.Point(15, 25);
            this.employeeGrid.Name = "employeeGrid";
            this.employeeGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(219)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.employeeGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.employeeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeeGrid.Size = new System.Drawing.Size(731, 291);
            this.employeeGrid.Style = MetroFramework.MetroColorStyle.Lime;
            this.employeeGrid.TabIndex = 30;
            this.employeeGrid.Visible = false;
            this.employeeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeeGrid_CellClick);
            // 
            // home_btn
            // 
            this.home_btn.BackColor = System.Drawing.Color.YellowGreen;
            this.home_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("home_btn.BackgroundImage")));
            this.home_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.home_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.home_btn.Location = new System.Drawing.Point(1213, 64);
            this.home_btn.Name = "home_btn";
            this.home_btn.Size = new System.Drawing.Size(50, 50);
            this.home_btn.TabIndex = 26;
            this.home_btn.UseVisualStyleBackColor = false;
            this.home_btn.Click += new System.EventHandler(this.home_btn_Click);
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1278, 804);
            this.Controls.Add(this.home_btn);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "Employee";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "EMPLOYEES";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.metroTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.actions_grp.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.employeeDetails_grp.ResumeLayout(false);
            this.employeeDetails_grp.PerformLayout();
            this.query_grp.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox actions_grp;
        private MetroFramework.Controls.MetroButton remove_btn;
        private MetroFramework.Controls.MetroButton new_btn;
        private MetroFramework.Controls.MetroButton edit_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private MetroFramework.Controls.MetroButton clear_btn;
        private System.Windows.Forms.GroupBox query_grp;
        private MetroFramework.Controls.MetroButton cancel_btn;
        private MetroFramework.Controls.MetroButton done_btn;
        private MetroFramework.Controls.MetroButton delete_btn;
        private MetroFramework.Controls.MetroButton update_btn;
        private MetroFramework.Controls.MetroButton save_btn;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton loadEmpTable_btn;
        private System.Windows.Forms.GroupBox employeeDetails_grp;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroTextBox password_txt;
        private MetroFramework.Controls.MetroTextBox name_txt;
        private MetroFramework.Controls.MetroTextBox surname_txt;
        private MetroFramework.Controls.MetroTextBox regno_txt;
        private MetroFramework.Controls.MetroTextBox designation_txt;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button home_btn;
        private MetroFramework.Controls.MetroGrid employeeGrid;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox eid_txt;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTextBox username_txt;

    }
}