using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;

using System.Data.OleDb;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;

namespace Anam_Pharma
{
    public partial class Supplier : MetroForm
    {
        public Supplier()
        {
            InitializeComponent();
            fillCityCombo();
        }

        private void fillCityCombo()
        {
            city_cmb.Items.Add("Eldoret"); city_cmb.Items.Add("Nairobi"); 
            city_cmb.Items.Add("Kisumu"); city_cmb.Items.Add("Mombasa");
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

        /// ////////////////////////////// SUPPLIER ADMIN ////////////////////////////////////////////

        private void new_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = false;
            supplierDetails_grp.Enabled = true;
            query_grp.Visible = true;
            save_btn.Enabled = true;
            update_btn.Enabled = false;
            delete_btn.Enabled = false;
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            loadSupplierTable_btn.PerformClick();
            supplierGrid.Focus();

            actions_grp.Enabled = false;
            supplierDetails_grp.Enabled = true;
            query_grp.Visible = true;
            save_btn.Enabled = false;
            update_btn.Enabled = true;
            delete_btn.Enabled = false;
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            loadSupplierTable_btn.PerformClick();
            supplierGrid.Focus();

            actions_grp.Enabled = false;
            supplierDetails_grp.Enabled = false;
            query_grp.Visible = true;
            save_btn.Enabled = false;
            update_btn.Enabled = false;
            delete_btn.Enabled = true;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string name = this.name_txt.Text;
            string city = this.city_cmb.Text;
            string address = this.address_txt.Text;
            string phone = this.phone_txt.Text;
            string phone2 = this.phone2_txt.Text;
            string email = this.email_txt.Text;

            // form validation
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("~ please provide supplier name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(city))
            { MessageBox.Show("~ please provide supplier city", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(address))
            { MessageBox.Show("~ please provide supplier address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(phone))
            { MessageBox.Show("~ please provide supplier phone #", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(email))
            { MessageBox.Show("~ please provide supplier email", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // eid AI - autoincrements
            string Query = "insert into apms.supplier (`name`,`city`,`address`,`phone`,`phone2`,`email`) values('"
            + name + "', '" + city + "', '" + address + "', '" + phone + "', '" + phone2 + "', '" + email + "'); ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                MessageBox.Show("> Supplier Captured", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            clear_btn.PerformClick();
            done_btn.Enabled = true;
            loadSupplierTable_btn.PerformClick();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string sid = this.sid_txt.Text;
            string name = this.name_txt.Text;
            string city = this.city_cmb.Text;
            string address = this.address_txt.Text;
            string phone = this.phone_txt.Text;
            string phone2 = this.phone2_txt.Text;
            string email = this.email_txt.Text;

            // form validation
            // form validation
            if (string.IsNullOrEmpty(sid))
            { MessageBox.Show("~ please select a record to edit", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("~ please provide supplier name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(city))
            { MessageBox.Show("~ please provide supplier city", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(address))
            { MessageBox.Show("~ please provide supplier address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(phone))
            { MessageBox.Show("~ please provide supplier phone #", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(email))
            { MessageBox.Show("~ please provide supplier email", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // UPDATE apms.employee SET `name`='max' WHERE `Eid`='8';
            string Query = "update apms.supplier SET " +
            "`name` = '" + name + "'," +
            "`city` = '" + city + "'," +
            "`address` = '" + address + "'," +
            "`phone` = '" + phone + "'," +
            "`phone2` = '" + phone2 + "'," +
            "`email` = '" + email + "'" +
            " where `sid` = '" + sid + "'; ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                MessageBox.Show("> Supplier Updated", "Edit Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            clear_btn.PerformClick();
            done_btn.Enabled = true;
            loadSupplierTable_btn.PerformClick();
            supplierGrid.Focus();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string sid = this.sid_txt.Text;

            // form validation
            if (string.IsNullOrEmpty(sid))
            { MessageBox.Show("~ please select a record to remove", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            DialogResult result = MessageBox.Show("Are you sure you wish to delete this record ?", "Delete Supplier",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // DELETE FROM apms.employee WHERE eid = 6 ;
                string Query = "delete from apms.supplier where sid = ' " + sid + " ' ; ";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    MessageBox.Show("> Supplier Deleted", "Remove Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read())
                    { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                clear_btn.PerformClick();
                done_btn.Enabled = true;
                loadSupplierTable_btn.PerformClick();
                supplierGrid.Focus();
            }
        }

        private void done_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = true;
            supplierDetails_grp.Enabled = false;
            done_btn.Enabled = false;
            query_grp.Visible = false;
            supplierGrid.Visible = false;

            clear_btn.PerformClick();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = true;
            supplierDetails_grp.Enabled = false;
            query_grp.Visible = false;
            supplierGrid.Visible = false;

            clear_btn.PerformClick();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            sid_txt.Clear(); name_txt.Clear(); 
            //city_cmb.Clear(); 
            address_txt.Clear(); phone_txt.Clear(); phone2_txt.Clear(); email_txt.Clear();
        }

        private void loadSupplierTable_btn_Click(object sender, EventArgs e)
        {
            supplierGrid.Visible = true;

            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string Query = " select sid as 'ID', Name as 'Supplier Name', City, Address, Phone, Phone2, Email from `apms`.`supplier` ; ";

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
                supplierGrid.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void supplierGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.supplierGrid.Rows[e.RowIndex];

                sid_txt.Text = row.Cells["ID"].Value.ToString();
                name_txt.Text = row.Cells["Supplier Name"].Value.ToString();
                city_cmb.Text = row.Cells["City"].Value.ToString();
                phone_txt.Text = row.Cells["Phone"].Value.ToString();
                phone2_txt.Text = row.Cells["Phone2"].Value.ToString();
                address_txt.Text = row.Cells["Address"].Value.ToString(); 
                email_txt.Text = row.Cells["email"].Value.ToString();
            }
        }
    }
}
