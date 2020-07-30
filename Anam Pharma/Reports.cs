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
    public partial class Reports : MetroForm
    {
        public Reports()
        {
            InitializeComponent();
            fillRPTCombos();
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

        private void fillRPTCombos()
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";
            string Query = " select * from apms.stock_names ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string pnname = myReader.GetString("pnname");
                    pnnameRPT_cmb.Items.Add(pnname);
                    pnnameRPT_cmb2.Items.Add(pnname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// ////////////////////////////// PRODUCT REPORTS TAB ////////////////////////////////////////////

        public static string RelativeDate(DateTime theDate)
        {
            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            int minute = 60;
            int hour = 60 * minute;
            int day = 24 * hour;
            thresholds.Add(60, "{0} seconds ago");
            thresholds.Add(minute * 2, "a minute ago");
            thresholds.Add(45 * minute, "{0} minutes ago");
            thresholds.Add(120 * minute, "an hour ago");
            thresholds.Add(day, "{0} hours ago");
            thresholds.Add(day * 2, "yesterday");
            thresholds.Add(day * 30, "{0} days ago");
            thresholds.Add(day * 365, "{0} months ago");
            thresholds.Add(long.MaxValue, "{0} years ago");

            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;
            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                }
            }
            return "";
        }

        private void loadReportTable()
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string Query = " select pid as 'Product ID', Name as 'Product Name', CPU, Units, batch as 'Batch No', expiry as 'Expiry No' from `apms`.`stock` ; ";


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
                reportGrid.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// ////////////////////////////// Expiry Cast

        private void ecClearChart_btn_Click(object sender, EventArgs e)
        {
            ecClearChart_btn.Enabled = false;
            ecLoadProductChart_btn.Enabled = true;
            ecLoadFullChart_btn.Enabled = true;

            ExpiryChart.Series["D2E"].Points.Clear();
        }

        private void ecLoadProductChart_btn_Click(object sender, EventArgs e)
        {
            loadReportTable();

            ecLoadProductChart_btn.Enabled = false;
            ecLoadFullChart_btn.Enabled = false;
            ecClearChart_btn.Enabled = true;

            string thepnname = "";
            string comboText = pnnameRPT_cmb.Text;

            // form validation
            if (string.IsNullOrEmpty(comboText))
            { MessageBox.Show("~ please provide product name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            for (int i = 0; i < reportGrid.Rows.Count; i++)
            {
                thepnname = Convert.ToString(reportGrid.Rows[i].Cells[1].Value);

                if (comboText == thepnname)
                {
                    String batchNo = Convert.ToString(reportGrid.Rows[i].Cells[4].Value);

                    DateTime Expiry = Convert.ToDateTime(reportGrid.Rows[i].Cells[5].Value);
                    DateTime Today = DateTime.Today;
                    double daysLeft = (Expiry - Today).TotalDays;

                    this.ExpiryChart.Series["D2E"].Points.AddXY(batchNo, daysLeft);
                }
            }
        }

        private void ecLoadFullChart_btn_Click(object sender, EventArgs e)
        {
            loadReportTable();

            ecLoadFullChart_btn.Enabled = false;
            ecLoadProductChart_btn.Enabled = false;
            ecClearChart_btn.Enabled = true;

            DateTime Expiry; // = null; // new DateTime(0001, 01, 01);

            for (int i = 0; i < reportGrid.Rows.Count - 1; i++)
            {
                String productName = Convert.ToString(reportGrid.Rows[i].Cells[1].Value);
                String batchNo = Convert.ToString(reportGrid.Rows[i].Cells[4].Value);

                Expiry = Convert.ToDateTime(reportGrid.Rows[i].Cells[5].Value);
                DateTime Today = DateTime.Today;
                double daysLeft = (Expiry - Today).TotalDays; // (EndDate - StartDate).TotalDays

                /*
                this.allProducts_chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}K";
                this.allProducts_chart.ChartAreas[0].AxisX.Title = "Product Name";
                this.allProducts_chart.ChartAreas[0].AxisY.Title = "Days Left to Expire";*/

                String lineX = productName + " " + batchNo;
                this.ExpiryChart.Series["D2E"].Points.AddXY(lineX, daysLeft);
            }

            /*
            The following code demonstrates how to sort series data using the default first Y value.
            // Sort series in ascending order.
            Chart1.Series["MySeries"].Sort(PointsSortOrder.Ascending);

            // Sort series in descending order.
            Chart1.DataManipulator.Sort(PointsSortOrder.Descending, "MySeries");
                     
            By default the first Y value of the data points is used for sorting. 
            However, you can sort data points using their X value, or any of their other Y values, such as Y2. 
            You can also sort by each value's AxisLabel property.
                    
            The following code demonstrates how to sort series data using non-default point values.
                    
            // Sort series in ascending order by X value.
            Chart1.Series["MySeries"].Sort(PointsSortOrder.Ascending, "X");

            // Sort series in descending order by axis label.
            Chart1.DataManipulator.Sort(PointsSortOrder.Descending, "AxisLabel", "MySeries");
            */

            //this.allProducts_chart.DataManipulator.Sort(PointsSortOrder.Ascending);   
        }

        /// ////////////////////////////// Stock Cast
        private void scClearChart_btn_Click(object sender, EventArgs e)
        {
            scClearChart_btn.Enabled = false;
            scLoadProductChart_btn.Enabled = true;
            scLoadFullChart_btn.Enabled = true;

            LevelsChart.Series["Units"].Points.Clear();
        }

        private void scLoadProductChart_btn_Click(object sender, EventArgs e)
        {
            loadReportTable();

            scLoadProductChart_btn.Enabled = false;
            scLoadFullChart_btn.Enabled = false;
            scClearChart_btn.Enabled = true;

            string thepnname = "";
            string comboText = pnnameRPT_cmb2.Text;

            // form validation
            if (string.IsNullOrEmpty(comboText))
            { MessageBox.Show("~ please provide product name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            for (int i = 0; i < reportGrid.Rows.Count; i++)
            {
                thepnname = Convert.ToString(reportGrid.Rows[i].Cells[1].Value);

                if (comboText == thepnname)
                {
                    String batchNo = Convert.ToString(reportGrid.Rows[i].Cells[4].Value);
                    String units = Convert.ToString(reportGrid.Rows[i].Cells[3].Value);

                    this.LevelsChart.Series["Units"].Points.AddXY(batchNo, units);
                }
            }
        }

        private void scLoadFullChart_btn_Click(object sender, EventArgs e)
        {
            loadReportTable();

            scLoadFullChart_btn.Enabled = false;
            scLoadProductChart_btn.Enabled = false;
            scClearChart_btn.Enabled = true;

            for (int i = 0; i < reportGrid.Rows.Count - 1; i++)
            {
                String productName = Convert.ToString(reportGrid.Rows[i].Cells[1].Value);
                String batchNo = Convert.ToString(reportGrid.Rows[i].Cells[4].Value);
                String units = Convert.ToString(reportGrid.Rows[i].Cells[3].Value);

                String lineX = productName;// +" " + batchNo;
                this.LevelsChart.Series["Units"].Points.AddXY(lineX, units);
            }
        }


    }
}
