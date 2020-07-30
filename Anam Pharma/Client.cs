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
using System.Drawing.Printing;
using MetroFramework.Forms;

namespace Anam_Pharma
{
    public partial class Client : MetroForm
    {
        /// ////////////////////////////// DECLARATIONS ////////////////////////////////////////////
        //string prodName_batchNO = "";
        string thegender = ""; 
        string thePrescribingDoc = "PRESdoc";
        string opipRec, fullnameRec;
        int queryValue = 0;

        public Client()
        {
            InitializeComponent();
            fillClientSurnameCombo();
            clockTime.Start();
            clearEntries();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void calculator_Click(object sender, EventArgs e)
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

        private void clockTime_Tick(object sender, EventArgs e)
        {
            // timer1 default 100 msec refresh interval - ticking
            DateTime dateTime = DateTime.Now;
            this.dateclock_txt.Text = dateTime.ToString();
        }

        private string whosOnline()
        {
            // You need to find the instance of the LOGIN form to call the method on.  
            // If you know there will always be exactly one open you can use:
            var loginForm = Application.OpenForms.OfType<Login>().Single();

            string uname = loginForm.getloginName();
            return uname;
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
                    string name = myReader["name"].ToString();
                    string surname = myReader["surname"].ToString();
                    doctorName = "Dr. " + name + " " + surname;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return doctorName;
        }

        private string getSqlDate()
        {
            DateTime dateTime = DateTime.Now;
            string sqlDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return sqlDate;
        }

        private void queryDB(string Query, string QueryTrace)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                if ((QueryTrace == "nameclassSave()") || (QueryTrace == "clientRecordSave()") ||
                     (QueryTrace == "3()") || (QueryTrace == "4()")
                   ) { queryValue = 7; }

                while (myReader.Read())
                {
                    if (QueryTrace == "()")
                    {
                        string stockname = myReader.GetString("name");
                        queryValue = 7;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadTable(string Query, DataGridView theDGV)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

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
                theDGV.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// ////////////////////////////// CLIENT ADMIN TAB ////////////////////////////////////////////
        private void male_radio_CheckedChanged(object sender, EventArgs e)
        {
            thegender = "Male";
        }

        private void female_radio_CheckedChanged(object sender, EventArgs e)
        {
            thegender = "Female";
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = false;
            clientDetails_grp.Enabled = true;
            query_grp.Visible = true;
            save_btn.Enabled = true;
            update_btn.Enabled = false;
            delete_btn.Enabled = false;
            dob_date.Value = new DateTime(1970, 01, 01);
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            loadClientTable_btn.PerformClick();
            clientGrid.Focus();
                        
            actions_grp.Enabled = false;
            clientDetails_grp.Enabled = true;
            query_grp.Visible = true;
            save_btn.Enabled = false;
            update_btn.Enabled = true;
            delete_btn.Enabled = false;
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            loadClientTable_btn.PerformClick();
            clientGrid.Focus();

            actions_grp.Enabled = false;
            clientDetails_grp.Enabled = false;
            query_grp.Visible = true;
            save_btn.Enabled = false;
            update_btn.Enabled = false;
            delete_btn.Enabled = true;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string opip = this.opipno_txt.Text;
            string name = this.name_txt.Text;
            string surname = this.surname_txt.Text;
            string dob = this.dob_date.Text;
            string phone = this.phone_txt.Text;
            string address = this.address_txt.Text;

            // form validation
            if (string.IsNullOrEmpty(opip))
            { MessageBox.Show("~ please provide patient OP/IP no", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(thegender))
            { MessageBox.Show("~ please provide gender", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;}
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("~ please provide first name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(surname))
            { MessageBox.Show("~ please provide surname", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(dob))
            { MessageBox.Show("~ please provide date of birth", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(phone))
            { MessageBox.Show("~ please provide phone no", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(address))
            { MessageBox.Show("~ please provide residential address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
 
            // cid AI - autoincrements
            string Query = "insert into apms.client (`gender`,`name`,`surname`,`dob`,`phone`,`address`,`opipno`) values('"
            + thegender + "', '" + name + "', '" + surname + "', '" + dob + "', '" + phone + "', '" + address + "', '" + opip + "'); ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                MessageBox.Show("> Client Registered", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            clear_btn.PerformClick();
            done_btn.Enabled = true;
            surname_cmb.Items.Add(surname); surname_cmb2.Items.Add(surname); 
            loadClientTable_btn.PerformClick();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string cid = this.cid_txt.Text;
            string opip = this.opipno_txt.Text;
            string name = this.name_txt.Text;
            string surname = this.surname_txt.Text;
            string dob = this.dob_date.Text;
            string phone = this.phone_txt.Text;
            string address = this.address_txt.Text;

            // form validation
            if (string.IsNullOrEmpty(cid))
            { MessageBox.Show("~ please select a record to edit", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(opip))
            { MessageBox.Show("~ please provide patient OP/IP no", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(thegender))
            { MessageBox.Show("~ please provide gender", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("~ please provide first name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(surname))
            { MessageBox.Show("~ please provide surname", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(dob))
            { MessageBox.Show("~ please provide date of birth", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(phone))
            { MessageBox.Show("~ please provide phone no", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(address))
            { MessageBox.Show("~ please provide residential address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // UPDATE apms.client SET `name`='max' WHERE `cid`='8';
            string Query = "update apms.client SET " +
            "`gender` = '" + thegender + "'," +
            "`name` = '" + name + "'," +
            "`surname` = '" + surname + "'," +
            "`dob` = '" + dob + "'," +
            "`phone` = '" + phone + "'," +
            "`address` = '" + address + "'," +
            "`opipno` = '" + opip + "'" +
            " where `cid` = '" + cid + "'; ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                MessageBox.Show("> Client Updated", "Edit Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            clear_btn.PerformClick();
            done_btn.Enabled = true;
            loadClientTable_btn.PerformClick();
            clientGrid.Focus();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string cid = this.cid_txt.Text;
            
            // form validation
            if (string.IsNullOrEmpty(cid))
            { MessageBox.Show("~ please select a record to remove", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            DialogResult result = MessageBox.Show("Are you sure you wish to delete this record ?", "Delete Client",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                string Query = "delete from apms.client where cid = ' " + cid + " ' ; ";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    MessageBox.Show("> Client Deleted","Remove Status", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    while (myReader.Read())
                    { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                clear_btn.PerformClick();
                done_btn.Enabled = true;
                loadClientTable_btn.PerformClick();
                clientGrid.Focus();
            }
        }

        private void done_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = true;
            clientDetails_grp.Enabled = false;
            done_btn.Enabled = false;
            query_grp.Visible = false;
            clientGrid.Visible = false;
            
            clear_btn.PerformClick();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = true;
            clientDetails_grp.Enabled = false;
            query_grp.Visible = false;
            clientGrid.Visible = false;

            clear_btn.PerformClick();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            cid_txt.Clear(); opipno_txt.Clear();
            male_radio.Checked = false; female_radio.Checked = false;
            name_txt.Clear(); surname_txt.Clear();
            //picker.Value = picker.Value.Date;
            //dateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dob_date.Value = new DateTime(1970,01,01); //(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            phone_txt.Clear(); address_txt.Clear(); 
        }

        private void loadClientTable_btn_Click(object sender, EventArgs e)
        {
            clientGrid.Visible = true;

            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            //string Query = " select * from `apms`.`client` ; ";
            string Query = " select  cid as 'ID', opipno as 'OP_IP NO', Gender, Name, Surname, dob as 'DoB', Phone, Address as 'Residence' from `apms`.`client` ; ";

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
                clientGrid.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clientGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.clientGrid.Rows[e.RowIndex];

                cid_txt.Text = row.Cells["ID"].Value.ToString();
                opipno_txt.Text = row.Cells["OP_IP NO"].Value.ToString();

                string agender = row.Cells["Gender"].Value.ToString();
                if (agender == "Male")
                {   male_radio.Checked = true;}
                if (agender == "Female")
                { female_radio.Checked = true; }

                name_txt.Text = row.Cells["Name"].Value.ToString();
                surname_txt.Text = row.Cells["Surname"].Value.ToString();
                dob_date.Text = row.Cells["DoB"].Value.ToString();
                phone_txt.Text = row.Cells["Phone"].Value.ToString();
                address_txt.Text = row.Cells["Residence"].Value.ToString();
            }
        }

        /// <summary>
        /// ////////////////////////////// DISPENSE TAB ////////////////////////////////////////////
        /// </summary>

        private void selectPatient_btn_Click(object sender, EventArgs e)
        {
            patientDetails_grp.Visible = true;
            patientDetails_grp.Enabled = true;
            selectPatient_btn.Visible = false;
            cancelDispense_btn.Visible = true;
        }

        private void fillClientSurnameCombo()
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";
            string Query = " select * from apms.client ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sfname = myReader.GetString("surname");
                    surname_cmb.Items.Add(sfname); surname_cmb2.Items.Add(sfname);      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void psurname_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            surnameReveal_grp.Visible = true;
            addPrescription_btn.Visible = true;
            
            string constring = "datasource=localhost; port=3306; username=root; password=5011";
            string Query = " select * from `apms`.`client` where surname = '" + surname_cmb.Text + " ' ; ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    surname_cmb.Text = myReader.GetString("surname");
                    opip_lbl.Text = myReader.GetString("opipno");
                    name_lbl.Text = myReader.GetString("name");
                    phone_lbl.Text = myReader.GetString("phone");
                    residence_lbl.Text = myReader.GetString("address");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearEntries()
        {
            surname_cmb.SelectedIndex = -1;
            surnameReveal_grp.Visible = false;
            opip_lbl.Text = "";
            name_lbl.Text = "";
            phone_lbl.Text = "";
            residence_lbl.Text = "";
            dosage_list.Items.Clear();
        }

        private void cancelDispense_btn_Click(object sender, EventArgs e)
        {
            exitSession_btn.Visible = false;
            cancelDispense_btn.Visible = false;
            selectPatient_btn.Visible = true;
            addPrescription_btn.Visible = false;
            addPrescription_btn.Enabled = true;
            saveClientRecord.Enabled = true;
            saveClientRecord.Visible = false;
            removeLabel_btn.Visible = false;
            printLabel_btn.Visible = false;
            checkoutDispense_btn.Enabled = true;
            checkoutDispense_btn.Visible = false;

            patientDetails_grp.Visible = false;
            surnameReveal_grp.Visible = false;
            stockTable_grp.Visible = false;
            stockGrid.Enabled = true;
            drugsDispensed_grp.Visible = false;

            clearEntries(); 
            selectPatient_btn.Focus();
        }

        private void updateStockLevels(string Query, int units, string thepid)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read()) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            loadProductTable();
        }

        private void addPrescription_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(surname_cmb.Text))
            { MessageBox.Show("~ please provide patient selection", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            addPrescription_btn.Enabled = false;

            // show client prescibing doctor form
            ClientPresDoctor cpd = new ClientPresDoctor();
            cpd.DocNameUpdated += new ClientPresDoctor.DocNameUpdateHandler(DocNameForm_ButtonClicked);
            cpd.ShowDialog();
        }
        
        private void DocNameForm_ButtonClicked(object sender, DocNameUpdateEventArgs e)
        {
            thePrescribingDoc = e.getPrescibingDoc;
            
            /*if (thePrescribingDoc != "PRESdoc")
            {

            }
            else 
            {
                MessageBox.Show("Sorry, Doctor Name Input Error!");
            }*/

            string tapbs = e.getAddPresBtnStatus;
            if (tapbs == "enableAddPresButton") // cancel was pressed
            {
                addPrescription_btn.Enabled = true; //MessageBox.Show(tapbs);
                surname_cmb.Focus();
            }
            else
            {
                patientDetails_grp.Enabled = false;
                stockTable_grp.Visible = true;
                drugsDispensed_grp.Visible = true;

                loadProductTable();  //MessageBox.Show(thePrescribingDoc);
            }
            
        }

        private void loadProductTable()
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            //string Query = " select * from `apms`.`client` ; ";
            string Query = " select stockid as 'ID', Name as 'Drug Name', expiry as 'Expiry Date', Quantity from `apms`.`stock` ; ";

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
                stockGrid.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stockGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                removeLabel_btn.Visible = true;
                checkoutDispense_btn.Visible = true;

                DataGridViewRow row = this.stockGrid.Rows[e.RowIndex];

                String pid = row.Cells["ID"].Value.ToString();
                String productName = row.Cells["Drug Name"].Value.ToString();
                //String batch = row.Cells["Batch"].Value.ToString();
                //prodName_batchNO = productName + "[Rx:" + batch + "]";

                String quantity = row.Cells["Quantity"].Value.ToString();

                // show client dosage dialog form
                ClientDosage cd = new ClientDosage(pid,productName,quantity);
                cd.DispenseUpdated += new ClientDosage.DispenseUpdateHandler(DispenseForm_ButtonClicked);
                cd.ShowDialog();
            }
        }

        private void DispenseForm_ButtonClicked(object sender, DispenseUpdateEventArgs e)
        {
            loadProductTable();

            int daunits = e.getDaUnits;
            int daunitsout = e.getDaUnitsOut;
            string thepid = e.getPid;
            string thedosage = e.getDosage;
            string thedrug = e.getTheDrugDispensed;

            string dispenseQuery = "update apms.stock SET " +
            "`quantity` = '" + daunits + "'" +
            " where `stockid` = '" + thepid + "'; ";

            updateStockLevels(dispenseQuery,daunits,thepid);

            // font for list box -- ensure all paddigns are well aligned
            dosage_list.Font = new Font(FontFamily.GenericMonospace, dosage_list.Font.Size);
            string pharmDosage = thedrug.PadRight(30) + thedosage;
            dosage_list.Items.Add(pharmDosage);

            int remainingUnits = daunits - daunitsout;
            string dispenseRecord = thepid + "*" + thedrug + "*" + daunits + "*" + daunitsout + "*" + remainingUnits + "*" + dateclock_txt.Text;
            dispenseRecord_list.Items.Add(dispenseRecord); // Dispense List -- Captures ALL History

            runStockControlCard(thepid,thedrug,daunits,daunitsout);

            loadProductTable();
        }

        private void removeLabel_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dosage_list.Items.Count <= 0) // No drug labels loaded for printing or print removal
                {
                    MessageBox.Show("~ Sorry, there are no labels to remove!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int iSelect = dosage_list.SelectedIndex;

                dispenseRecord_list.SetSelected(iSelect, true);
                string cloneSelected = dispenseRecord_list.GetItemText(dispenseRecord_list.SelectedItem);

                string[] strArr2 = null; // char[] splitchar = { ' ' }; //strArr2 = dispenser.Split(splitchar);
                strArr2 = cloneSelected.Split('*');

                string drugID, drugName = "";
                int daunits, daunitsout = 0;

                drugID = strArr2[0];
                drugName = strArr2[1];
                daunits = Int32.Parse(strArr2[2]);
                daunitsout = Int32.Parse(strArr2[3]);

                int originalUnits = daunits + daunitsout;
                //MessageBox.Show(drugID + "," + drugName + "," + daunits + "," + daunitsout);

                string removalReturnQuery = "update apms.stock SET " +
                "`quantity` = '" + originalUnits + "'" +
                " where `stockid` = '" + drugID + "'; ";

                updateStockLevels(removalReturnQuery, originalUnits, drugID);
                dosage_list.Items.RemoveAt(iSelect);
                dispenseRecord_list.Items.RemoveAt(iSelect);

                loadProductTable();

                /* IF REMOVAL/DELETE HAPPENS -- RETURNS
                 *     string dispenseQuery = "update apms.stockcard SET " +
                "`units` = '" + daunits + "'" +
                " where `pid` = '" + thepid + "'; ";
                 */
            }
            catch (Exception)
            {
                return;
            }
        }

        private void printLabel_btn_Click(object sender, EventArgs e)
        {
            // print select validation
            string label = "labelEMPTY";
            label = dosage_list.GetItemText(dosage_list.SelectedItem);

            if (string.IsNullOrEmpty(label))
            {
                MessageBox.Show("~ Please select a label to print!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dosage_list.Items.Count <= 0 ) // No drug labels loaded for printing
            {
                MessageBox.Show("~ Sorry, there are no labels to print!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }
            else // List box contains some items -- proceed to print
            {

                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new PrintPageEventHandler(createPrescription); //add an event handler that will do the printing

                //on a till you will not want to ask the user where to print but this is fine for the test envoironment
                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDocument.Print();
                    MessageBox.Show("Label Print Successful!", "Print Status", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                    /*DialogResult dialog = MessageBox.Show("Do you have further labels to print ?", "Print Status",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Yes)
                    {
                        dosage_list.Focus(); //this.Show();
                    }
                    else if (dialog == DialogResult.No)
                    {
                        //cancelDispense_btn.PerformClick();
     
                    }*/
                }
            }
        }

        void createPrescription(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string cpSurname = surname_cmb.Text;
            string cpName = name_lbl.Text;
            string cpFullName = cpSurname + " " + cpName;

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 20;

            String dash =  "-----------------------------------------------------------------";
            //String stars = "*****************************************************************";
            String blank = "                                                                 ";

            SolidBrush sBrush = new SolidBrush(Color.Black);

            graphic.DrawString(dash, font, sBrush, startX, startY);

            int iSelect = -7;
           
            iSelect = dosage_list.SelectedIndex;

            if (iSelect == -7)
            {
               // MessageBox()
            }
            string item = dosage_list.GetItemText(dosage_list.SelectedItem);
            //foreach (string item in product_list.Items) // loops through list - prints all labels at once
            {   
                // CLIENT NAME
                graphic.DrawString(cpFullName.ToUpper(), new Font("Courier New", 18), sBrush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;

                // STOCK NAME    
                string top = "[Drug Name]".PadRight(30) + "[Instructions]";
                graphic.DrawString(top, font, sBrush, startX, startY + offset);
                offset = offset + (int)fontHeight; //make the spacing consistent

                //create the string to print on the reciept
                string productDescription = item.PadRight(30);
                //string dosageDescription = "2x3";
                string productLine = productDescription;// +dosageDescription;

                graphic.DrawString(productLine, font, sBrush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;

                // EMPLOYEE
                graphic.DrawString("Prescribed by: " + thePrescribingDoc, font, sBrush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
                String doctorName = getDocName();
                //String doctorName = "Dr. mimi";
                graphic.DrawString("Pharmacist: " + doctorName, font, sBrush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
                
                // DATE
                graphic.DrawString("Timestamp: " + dateclock_txt.Text, font, sBrush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;

                graphic.DrawString(">>> MALINDI SUB-COUNTY HOSPITAL <<<", font, sBrush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;

                graphic.DrawString(dash, font, sBrush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
            }

            offset += 20;

            graphic.DrawString(blank, font, sBrush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;

            dosage_list.Items.RemoveAt(iSelect);
            dispenseRecord_list.Items.RemoveAt(iSelect);
        }

        private void runStockControlCard(string daPid, string daDrug, int daunits, int daunitsout)
        {
            DateTime dateTime = DateTime.Now;
            string sqlDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss"); 
            //sqlDate = sqlDate.Substring(0, 9); // 13-OCT-15 // daDate.Split(' '); 
            int originalUnits = daunits + daunitsout;
            stockControlCard_list.Items.Add(daPid + "*"+ sqlDate + "*" + daDrug + "*" + originalUnits + "*" + daunitsout + "*" + daunits);
            
            saveStockControlCard(daPid,daDrug,sqlDate,originalUnits,daunitsout,daunits);
            loadProductTable();
        }

        private void saveStockControlCard(string stockid, string drugName, string date, int originalUnits, int issues, int balances)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            // form validation
            //if (string.IsNullOrEmpty(opip))
            //{ MessageBox.Show("~ please provide patient OP/IP no", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string refno = ""; string receipts = "";
            string Query = "insert into apms.stockcard (`stockid`,`drugname`,`date`,`refNO`,`receipts`,`issues`,`balances`) values('"
            + stockid + "', '" + drugName + "', '" + date + "', '" + refno + "', '" + receipts + "', '" + issues + "', '" + balances + "'); ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                //MessageBox.Show("> Stock Control Entry Captured", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// ////////////////////////////// CLIENT HISTORY TAB ////////////////////////////////////////////
        /// 
        private void saveClientRecord_Click(object sender, EventArgs e)
        {
            saveClientRecord.Enabled = false;

            string name = name_lbl.Text;
            string surname = surname_cmb.Text;    
            fullnameRec = name + " " + surname;

            opipRec = opip_lbl.Text;
            string presDocRec = thePrescribingDoc;
            string pharmRec = getDocName();
            string dateRec = getSqlDate();
            string clientDrugRec = ""; //= "THEREC";
            string doctorsRec = "Prescriber: " + presDocRec + "\n" + "Pharmacist: " + pharmRec;

            int itemCount = dosage_list.Items.Count; //.GetItemText(dosage_list.SelectedItem);
            foreach (string item in dosage_list.Items) // loops through list - prints all labels at once
            {
                clientDrugRec += item +"\n";
            }
            clientDrugRec.Trim();

            // log client drug history
            string Query = "insert into apms.clienthistory (`date`,`opipno`,`name`,`surname`,`fullname`,`drugrecord`,`doctors`) values('"
            + dateRec + "', '" + opipRec + "', '" + name + "', '" + surname + "', '" + fullnameRec + "', '" + clientDrugRec + "', '" + doctorsRec + "'); ";
            
            queryDB(Query, "clientRecordSave()");
            if (queryValue == 0)
            { MessageBox.Show("~ Query Failure clientRecordSave() :(", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else {
                MessageBox.Show("> Patient Record Logged", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                queryValue = 0;
            }
        }

        private void loadClientHistoryTable_btn_Click(object sender, EventArgs e)
        {
            clientHistoryGrid.Visible = true;

            string Query = " select Date, opipno as 'OP/IP NO', fullname as 'Patient Name', drugrecord as 'Drug History', doctors as 'In-charge' from `apms`.`clienthistory` where surname = '" + surname_cmb2.Text + "' ;";
            loadTable(Query, clientHistoryGrid);
        }

        private void surname_cmb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";
            string Query = " select * from `apms`.`client` where surname = '" + surname_cmb2.Text + " ' ; ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    opip_lbl2.Text = myReader.GetString("opipno");
                    name_lbl2.Text = myReader.GetString("name");
                    phone_lbl2.Text = myReader.GetString("phone");
                    residence_lbl2.Text = myReader.GetString("address");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkoutDispense_btn_Click(object sender, EventArgs e)
        {
            if (dosage_list.Items.Count <= 0) // No drug labels loaded for printing or print removal
            {
                MessageBox.Show("~ Unnaceptable command, no labels cued in dispense list!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                checkoutDispense_btn.Enabled = false;
                removeLabel_btn.Visible = false;
                saveClientRecord.Visible = true;
                printLabel_btn.Visible = true;
                exitSession_btn.Visible = true;
                stockGrid.Enabled = false;
            }
        }

        private void exitSession_btn_Click(object sender, EventArgs e)
        {
            exitSession_btn.Visible = false;
            cancelDispense_btn.Visible = false;
            selectPatient_btn.Visible = true;
            addPrescription_btn.Visible = false;
            addPrescription_btn.Enabled = true;
            saveClientRecord.Enabled = true;
            saveClientRecord.Visible = false;
            removeLabel_btn.Visible = false;
            printLabel_btn.Visible = false;
            checkoutDispense_btn.Enabled = true;
            checkoutDispense_btn.Visible = false;

            patientDetails_grp.Visible = false;
            surnameReveal_grp.Visible = false;
            stockTable_grp.Visible = false;
            stockGrid.Enabled = true;
            drugsDispensed_grp.Visible = false;

            clearEntries(); 
            selectPatient_btn.Focus();
        }
    }
}