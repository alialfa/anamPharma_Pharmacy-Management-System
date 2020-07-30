using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anam_Pharma
{
    public partial class EmployeeProfile : MetroForm
    {
        public EmployeeProfile()
        {
            InitializeComponent();
            password_txt.PasswordChar = '*'; password_txt.MaxLength = 10;
            password2_txt.PasswordChar = '*'; password2_txt.MaxLength = 10;
        }

        private void completeRegistration_btn_Click(object sender, EventArgs e)
        {
            string name = this.name_txt.Text;
            string surname = this.surname_txt.Text;
            string designation = this.designation_txt.Text;
            string regno = this.regno_txt.Text;
            string password = this.password_txt.Text;
            string password2 = this.password2_txt.Text;

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
            if (string.IsNullOrEmpty(password2))
            { MessageBox.Show("~ please provide re-typed password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if ( password == password2)
            {
                string constring = "datasource=localhost; port=3306; username=root; password=5011";
        
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

                    MessageBox.Show("> Registration Successful :)", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Hide();
                    Login newLogin = new Login(); newLogin.Show();

                    while (myReader.Read())
                    { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else // password mismatch
            {
                MessageBox.Show("~ passwords did not match", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }
        }
    }
}
