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
    public partial class Login : MetroForm
    {
        String theusername = "xxxxx";

        public Login()
        {
            /*
            Thread t = new Thread(new ThreadStart(splashStart));
            t.Start();
            Thread.Sleep(5000);
            t.Abort();
            */
            InitializeComponent();
            //password_txt.PasswordChar = '*';
            password_txt.MaxLength = 10;
            //name_txt.Focus(); 
            this.ActiveControl = name_txt;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            String loginName = this.name_txt.Text;
            String passW = this.password_txt.Text;
            
            // form validation
            if (string.IsNullOrEmpty(loginName))
            {
                MessageBox.Show("~ please key employee firstname", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                name_txt.Focus();
                return; 
            }
            if (string.IsNullOrEmpty(passW))
            {
                MessageBox.Show("Please key password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                password_txt.Focus();
                return;
            }

            try
            {
                string myConnection = "datasource=localhost; port=3306; username=root; password=5011";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                // e.g. select * from apms.employee where username = 'admin' and password = '1234'
                MySqlCommand SelectCommand = new MySqlCommand("select * from apms.employee where name = '" + loginName + "' and password = '" + passW + "' ;", myConn);

                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();

                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Login successful! Press OK to proceed.", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    setloginName(loginName);

                    this.Hide();
                    Home homeF = new Home();
                    homeF.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate Login-name & Password!", "Access Denied", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Login Unsuccessful!", "Access Denied", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setloginName(string userN)
        {
            theusername = userN;
        }

        public string getloginName()
        {
            return this.theusername;
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            EmployeeProfile empRegF = new EmployeeProfile();
            empRegF.Show();
        }
    }
}
