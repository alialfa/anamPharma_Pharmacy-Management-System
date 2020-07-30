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
using System.Threading;
using MetroFramework.Forms;

namespace Anam_Pharma
{
    public partial class Home : MetroForm
    {
        int ExpiryThreshold, LevelsThreshold = 00;

        public Home()
        {
            InitializeComponent();
            clockTime.Start();
            refresh_timer.Start(); //refresh_timer.Interval = 2000; // in miliseconds ~ 2 seconds
            runHomeDisplays();
            runLatestSet();
        }

        /// /// ////////////////////////////// HELPER FUNCTIONS ////////////////////////////////////////////

        private void runHomeDisplays()
        {
            string doctorName = getDocName();
            hi_lbl.Text = "Hi, " + doctorName;

            // manage employees setting
            string uname = whosOnline();
            if (uname == "admin" || uname == "aisha")
            {
                employee_btn.Visible = true;
            }
        }

        private string whosOnline()
        {
            // You need to find the instance of the LOGIN form to call the method on.  
            // If you know there will always be exactly one open you can use:
            var loginForm = Application.OpenForms.OfType<Login>().Single();

            string lName = loginForm.getloginName();
            return lName;
        }

        private string getDocName()
        {
            string loginName = whosOnline();
            string doctorName = "";

            string constring = "datasource=localhost; port=3306; username=root; password=5011";
            string Query = "SELECT surname,name FROM apms.employee where name = '" + loginName + "';";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    /*  string col1Value = myReader["ColumnOneName"].ToString(); OR
                        string col1Value = myReader[0].ToString();

                        var myString = rdr.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                        listDeclaredElsewhere.Add(myString); / Do somthing with this rows string, for example to put them in to a list
                    */

                    string name = myReader["name"].ToString();
                    string surname = myReader["surname"].ToString();
                    doctorName = "Dr. " + surname;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return doctorName;
        }

        // DYNAMIC DISPLAY OF CURRENT DATE & TIME
        private void clockTime_Tick(object sender, EventArgs e)
        {
            // timer1 default 100 msec refresh interval - ticking
            DateTime dateTime = DateTime.Now;
            this.clock_lbl.Text = dateTime.ToString();
        }

        // GRACEFUL CODE EXIT - FULL EXIT NOT IN DEBUG MODE
        private void Home_Closing(object sender, FormClosingEventArgs e)
        {
            exit_btn.PerformClick();
        }

        /// /// ////////////////////////////// MENU ////////////////////////////////////////////
        private void client_btn_Click(object sender, EventArgs e)
        {
            Client clientF = new Client();
            clientF.Show();
        }

        private void product_btn_Click(object sender, EventArgs e)
        {
            Stock productF = new Stock();
            productF.Show();
        }

        private void quickSale_btn_Click(object sender, EventArgs e)
        {
            QuickSale quicksaleF = new QuickSale();
            quicksaleF.Show();
        }

        private void employee_btn_Click(object sender, EventArgs e)
        {
            Employee employeeF = new Employee();
            employeeF.Show();
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            Supplier orderF = new Supplier();
            orderF.Show();
        }

        private void calculator_btn_Click(object sender, EventArgs e)
        {
            Calculator calculatorF = new Calculator();
            calculatorF.Show();
        }

        private void report_btn_Click(object sender, EventArgs e)
        {
            Reports reportF = new Reports();
            reportF.Show();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
            /*DialogResult result = MessageBox.Show("Are you sure you wish to exit ?",
            "EXIT",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }*/
        }
        private void help_btn_Click(object sender, EventArgs e)
        {
            Help helpF = new Help();
            helpF.Show();
        }

        private void about_btn_Click(object sender, EventArgs e)
        {
            AboutUs aboutF = new AboutUs();
            aboutF.Show();
        }

        /// /// ////////////////////////////// NOTIFICATIONS ////////////////////////////////////////////
        
        // retrieves saved notification values from DB
        private void runLatestSet()
        {
            string constring2 = "datasource=localhost; port=3306; username=root; password=5011";
            string Query2 = "SELECT expirydays,levels FROM apms.notifications WHERE nid = 1;";

            MySqlConnection conDataBase2 = new MySqlConnection(constring2);
            MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2);
            MySqlDataReader myReader2;

            try
            {
                conDataBase2.Open();
                myReader2 = cmdDataBase2.ExecuteReader();

                while (myReader2.Read())
                {
                    ExpiryThreshold = Convert.ToInt32( myReader2["expirydays"].ToString() );
                    LevelsThreshold = Convert.ToInt32( myReader2["levels"].ToString() );
                }
                showThresholds();
                refresh_btn.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh_timer_Tick(object sender, EventArgs e)
        {
            refresh_btn.PerformClick();
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            expiry_list.Items.Clear();
            levels_list.Items.Clear();

            loadNotificationGrid();
            runNotificatons();
        }

        private void showThresholds()
        {
            ET_txt.Text = ExpiryThreshold.ToString();
            LT_txt.Text = LevelsThreshold.ToString();
        }

        private void loadNotificationGrid()
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";
 
            string Query = " select stockid as 'Stock ID', Name, Quantity, expiry as 'Expiry Date' from `apms`.`stock` ; ";

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
                notificationGrid.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void runNotificatons()
        {
            expiry_list.Font = new Font(FontFamily.GenericMonospace, expiry_list.Font.Size);
            levels_list.Font = new Font(FontFamily.GenericMonospace, levels_list.Font.Size);

            string expiryLine = "STOCK | DAYS-LEFT";
            expiry_list.Items.Add(expiryLine);

            string levelsLine = "STOCK | QUANTITY";
            levels_list.Items.Add(levelsLine);

            for (int i = 0; i < notificationGrid.Rows.Count - 1; i++)
            {
                string piD = Convert.ToString(notificationGrid.Rows[i].Cells[0].Value);
                string stockname = Convert.ToString(notificationGrid.Rows[i].Cells[1].Value);
                double quantity = Convert.ToDouble(notificationGrid.Rows[i].Cells[2].Value);

                DateTime Expiry = Convert.ToDateTime(notificationGrid.Rows[i].Cells[3].Value);
                DateTime Today = DateTime.Today;
                double daysLeft = (Expiry - Today).TotalDays;

                // e.g. Expires in less than 2 months
                if (daysLeft <= ExpiryThreshold) //if (daysLeft <= 60) 
                {
                    expiryLine = stockname + " | " + daysLeft;
                    expiry_list.Items.Add(expiryLine);
                }

                // Stock almost out
                if (quantity <= LevelsThreshold) // ( units <= 10 )
                {
                    levelsLine = stockname +" | " + quantity;
                    levels_list.Items.Add(levelsLine);
                }
            }
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            // settings for expiry & product levels
            Notifications nty = new Notifications();
            nty.NotifyUpdated += new Notifications.NotifyUpdateHandler(NotifyForm_ButtonClicked);
            nty.ShowDialog();
            showThresholds();
            refresh_btn.PerformClick();
        }

        private void NotifyForm_ButtonClicked(object sender, NotifyUpdateEventArgs e)
        {
            ExpiryThreshold = Convert.ToInt32(e.getExpiryDays);
            LevelsThreshold = Convert.ToInt32(e.getLevels);
        }

        private void myProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
