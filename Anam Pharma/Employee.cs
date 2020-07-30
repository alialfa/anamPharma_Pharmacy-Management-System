using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;

namespace Anam_Pharma
{
    public partial class Employee : MetroForm
    {
        /// ////////////////////////////// DECLARATIONS ////////////////////////////////////////////

        public Employee()
        {
            InitializeComponent();
            password_txt.PasswordChar = '*';
            password_txt.MaxLength = 10;
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void calculator_btn_Click(object sender, EventArgs e)
        {
            Calculator calculatorF = new Calculator();
            calculatorF.Show();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to exit ?",
            "EXIT",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// ////////////////////////////// EMPLOYEE ADMIN ////////////////////////////////////////////

        private void new_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = false;
            employeeDetails_grp.Enabled = true;
            query_grp.Visible = true;
            save_btn.Enabled = true;
            update_btn.Enabled = false;
            delete_btn.Enabled = false;
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            loadEmpTable_btn.PerformClick();
            employeeGrid.Focus();

            actions_grp.Enabled = false;
            employeeDetails_grp.Enabled = true;
            query_grp.Visible = true;
            save_btn.Enabled = false;
            update_btn.Enabled = true;
            delete_btn.Enabled = false;
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            loadEmpTable_btn.PerformClick();
            employeeGrid.Focus();

            actions_grp.Enabled = false;
            employeeDetails_grp.Enabled = false;
            query_grp.Visible = true;
            save_btn.Enabled = false;
            update_btn.Enabled = false;
            delete_btn.Enabled = true;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string name = this.name_txt.Text;
            string surname = this.surname_txt.Text;
            string designation = this.designation_txt.Text;
            string regno = this.regno_txt.Text;
            //string username = this.username_txt.Text;
            string password = this.password_txt.Text;

            // form validation
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("~ please provide first name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(surname))
            { MessageBox.Show("~ please provide surname", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(designation))
            { MessageBox.Show("~ please provide designation", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(regno))
            { MessageBox.Show("~ please provide registration no", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(password))
            { MessageBox.Show("~ please provide password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // eid AI - autoincrements
            string Query = "insert into apms.employee (`name`,`surname`,`designation`,`regno`,`password`) values('"
            + name + "', '" + surname + "', '" + designation + "', '" + regno + "', '" + password + "'); ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                MessageBox.Show("> Employee Registered", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            clear_btn.PerformClick();
            done_btn.Enabled = true;
            //load_table(); //refreshes table after saving
            loadEmpTable_btn.PerformClick();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string eid = this.eid_txt.Text;
            string name = this.name_txt.Text;
            string phone = this.regno_txt.Text;
            string role = this.designation_txt.Text;
            string surname = this.surname_txt.Text;
            string username = this.username_txt.Text;
            string password = this.password_txt.Text;

            // form validation
            if (string.IsNullOrEmpty(eid))
            { MessageBox.Show("~ please select a record to edit", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("~ please provide first name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(surname))
            { MessageBox.Show("~ please provide surname", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(username))
            { MessageBox.Show("~ please provide username", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(password))
            { MessageBox.Show("~ please provide password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // UPDATE apms.employee SET `name`='max' WHERE `Eid`='8';
            string Query = "update apms.employee SET " +
            "`name` = '" + name + "'," +
            "`surname` = '" + surname + "'," +
            "`phone` = '" + phone + "'," +
            "`role` = '" + role + "'," +
            "`username` = '" + username + "'," +
            "`password` = '" + password + "'" +
            " where `eid` = '" + eid + "'; ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                MessageBox.Show("> Employee Updated", "Edit Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            clear_btn.PerformClick();
            done_btn.Enabled = true;
            loadEmpTable_btn.PerformClick(); 
            employeeGrid.Focus();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string eid = this.eid_txt.Text;

            // form validation
            if (string.IsNullOrEmpty(eid))
            { MessageBox.Show("~ please select a record to remove", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            DialogResult result = MessageBox.Show("Are you sure you wish to delete this record ?", "Delete Employee",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // DELETE FROM apms.employee WHERE eid = 6 ;
                string Query = "delete from apms.employee where eid = ' " + eid + " ' ; ";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    MessageBox.Show("> Employee Deleted", "Remove Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read())
                    { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                clear_btn.PerformClick();
                done_btn.Enabled = true;
                loadEmpTable_btn.PerformClick();
                employeeGrid.Focus();
            }
        }

        private void done_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = true;
            employeeDetails_grp.Enabled = false;
            done_btn.Enabled = false;
            query_grp.Visible = false;
            employeeGrid.Visible = false;

            clear_btn.PerformClick();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = true;
            employeeDetails_grp.Enabled = false;
            query_grp.Visible = false;
            employeeGrid.Visible = false;

            clear_btn.PerformClick();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            eid_txt.Clear(); name_txt.Clear(); surname_txt.Clear(); regno_txt.Clear();
            designation_txt.Clear(); username_txt.Clear(); password_txt.Clear();
        }

        private void loadEmpTable_btn_Click(object sender, EventArgs e)
        {
            employeeGrid.Visible = true;

            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            // show all table columns
            //string Query = " select * from `apms`.`employee` ; ";

            // show portion of table columns
            //string Query = " select eid , name, surname, age from apms.employee ; ";

            // 20 - CHANGE COLUMN TITLE IN DATA-GRID-VIEW / MYSQL
            //string Query = " select eid as 'Employee ID', name as 'First Name', surname as 'Last Name', age as 'Age' from apms.employee ; ";

            string Query = " select eid as 'Employee ID', Name, Surname, Designation, RegNo from `apms`.`employee` ; ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;

                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                employeeGrid.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void employeeGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.employeeGrid.Rows[e.RowIndex];

                eid_txt.Text = row.Cells["Employee ID"].Value.ToString();
                name_txt.Text = row.Cells["Name"].Value.ToString();
                surname_txt.Text = row.Cells["Surname"].Value.ToString();
                designation_txt.Text = row.Cells["Designation"].Value.ToString();
                regno_txt.Text = row.Cells["RegNo"].Value.ToString();
                //password_txt.Text = row.Cells["Password"].Value.ToString();
            }
        }
    }
}
