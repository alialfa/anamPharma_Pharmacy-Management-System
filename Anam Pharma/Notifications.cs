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
    public partial class Notifications : MetroForm
    {
        // delegate
        public delegate void NotifyUpdateHandler(object sender, NotifyUpdateEventArgs e);
        // even of delegate type
        public event NotifyUpdateHandler NotifyUpdated;

        public Notifications()
        {
            InitializeComponent();
        }

        // this button click event handler will raise the event which can then intercepted by any
        // listeners // read the textboxes and set the variables
        // function saves set notification values in DB
        private void set_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Alter Threshold(s)?",
            "Notify Settings",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                string constring = "datasource=localhost; port=3306; username=root; password=5011";

                string theExpiryDays = this.expiryDays_txt.Text;
                string theLevels = this.levels_txt.Text;

                // form validation
                if (string.IsNullOrEmpty(theExpiryDays))
                { MessageBox.Show("~ please provide expiry threshold[days]"); expiryDays_txt.Focus(); return; }
                if (string.IsNullOrEmpty(theLevels))
                { MessageBox.Show("~ please provide levels threshold[days]"); levels_txt.Focus(); return; }

                string Query = "update apms.notifications SET " +
                "`expirydays` = '" + theExpiryDays + "'," +
                "`levels` = '" + theLevels + "'" +
                " where `nid` = 1; ";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    MessageBox.Show("> New Notifications Set", "New Notify Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read())
                    { }

                    runLatestSet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

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

                string daExpirydays = "";
                string daLevels = "";

                while (myReader2.Read())
                {
                    daExpirydays = myReader2["expirydays"].ToString();
                    daLevels = myReader2["levels"].ToString();
                }

                // instance the event args and pass it each value
                NotifyUpdateEventArgs args = new NotifyUpdateEventArgs(daExpirydays, daLevels);
                // raise the event with the updated arguments
                NotifyUpdated(this, args);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class NotifyUpdateEventArgs : System.EventArgs
    {
        private string expiryDays, levels;

        public NotifyUpdateEventArgs(string theExpiryDays, string theLevels)
        {
            this.expiryDays = theExpiryDays;
            this.levels = theLevels;
        }

        public string getExpiryDays
        {
            get { return expiryDays; }
        }

        public string getLevels
        {
            get { return levels; }
        }
    }
}

