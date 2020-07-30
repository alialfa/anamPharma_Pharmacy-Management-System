using MetroFramework.Forms;
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

namespace Anam_Pharma
{
    public partial class Stock : MetroForm
    {
        // Declarations
        string thelabel;
        int queryValue = 0;
        int currentQuantity = 0;

        public Stock()
        {
            InitializeComponent();
            fillstockNameCombo(); 
            fillclassNameCombo();
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

        private void loadTable(String Query, DataGridView theDGV)
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

                if ( (QueryTrace == "nameclassSave()") || (QueryTrace == "classSave()") || 
                     (QueryTrace == "stockUpdate()") || (QueryTrace == "stockCardUpdate()") 
                   ) { queryValue = 7; }

                while (myReader.Read()) 
                {
                    if (QueryTrace == "fillstockNameCombo()")
                    {
                        string stockname = myReader.GetString("name");
                        stockname_cmb.Items.Add(stockname);
                        stockname_cmb2.Items.Add(stockname);
                        queryValue = 7; 
                    }
                    if(QueryTrace == "fillclassNameCombo()")
                    {
                        string stockclass = myReader.GetString("stockclass");
                        stockclass_cmb.Items.Add(stockclass);
                        queryValue = 7; 
                    }
                    if (QueryTrace == "readStockDB()")
                    {
                        stockid_txt.Text = myReader.GetString("stockid");
                        stockclass_txt.Text = myReader.GetString("stockclass");
                        string cq = myReader.GetString("quantity");
                        currentQuantity = Int32.Parse(cq);
                        queryValue = 7;
                    }
                    if (QueryTrace == "getNameClass()")
                    {
                        stockclass_txt.Text = myReader.GetString("nameclass");
                        queryValue = 7;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// ////////////////////////////// PRODUCT ADMIN TAB ////////////////////////////////////////////
        /// 

        private void clear_btn_Click(object sender, EventArgs e)
        {
            stockid_txt.Clear();  
            unitsize_txt.Clear(); supplier_txt.Clear(); //price_txt.Clear(); batch_txt.Clear();
            expiry_date.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = false;
            details_grp.Enabled = true;
            query_grp.Visible = true;
            save_btn.Enabled = true;
            update_btn.Enabled = false;
            delete_btn.Enabled = false;
            expiry_date.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            loadStockTable_btn.PerformClick();
            stockGrid.Focus();

            actions_grp.Enabled = false;
            details_grp.Enabled = true;
            query_grp.Visible = true;
            save_btn.Enabled = false;
            update_btn.Enabled = true;
            delete_btn.Enabled = false;
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            loadStockTable_btn.PerformClick();
            stockGrid.Focus();

            actions_grp.Enabled = false;
            details_grp.Enabled = false;
            query_grp.Visible = true;
            save_btn.Enabled = false;
            update_btn.Enabled = false;
            delete_btn.Enabled = true;
        }


        private void save_btn_Click(object sender, EventArgs e)
        {
            string name = this.stockname_cmb.Text;
            string unitsize = this.unitsize_txt.Text;
            string quantity = this.quantity_txt.Text;
            string supplier = this.supplier_txt.Text;
            string expiry = this.expiry_date.Text;
            string refno = this.refno_txt.Text;

            // form validation
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("~ please provide stock name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(unitsize))
            { MessageBox.Show("~ ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(quantity))
            { MessageBox.Show("~ please provide quantity", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(supplier))
            { MessageBox.Show("~ please provide supplier name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(expiry))
            { MessageBox.Show("~ please provide expiry date", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(refno))
            { MessageBox.Show("~ please provide reference no (S-11 / Delievery Note)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int tester = 0;
            if (!Int32.TryParse(unitsize_txt.Text, out tester))
            { MessageBox.Show("~ unit size must be an integer", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); unitsize_txt.Focus(); return; }
            if (!Int32.TryParse(quantity_txt.Text, out tester))
            { MessageBox.Show("~ quantity must be an integer", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); quantity_txt.Focus(); return; }            

            int quantityIn = Int32.Parse(quantity); // quantity incoming receipt

            string Query = "";

            // get current stock qunatity
            Query = "select * from apms.stock where name = '" + name +"';";
            queryDB(Query, "readStockDB()");
            if (queryValue == 0)
            { MessageBox.Show("~ Query Failure readStockDB() :(", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else { queryValue = 0; }

            currentQuantity += quantityIn; // increment the stock quanitity

            Query = "update apms.stock SET " +
            "`name` = '" + name + "'," +
            "`stockclass` = '" + stockclass_txt.Text + "'," +
            "`unitsize` = '" + unitsize + "'," +
            "`quantity` = '" + currentQuantity + "'," +
            "`supplier` = '" + supplier + "'," +
            "`expiry` = '" + expiry + "'," +
            "`refno` = '" + refno + "' " +
            " where `name` = '" + name + "' ; ";

            queryDB(Query, "stockUpdate()");
            if (queryValue == 7)
            { MessageBox.Show("> Stock Captured", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information); queryValue = 0; }
            else
            { MessageBox.Show("~ Query Failure stockUpdate() :(", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            DateTime dateTime = DateTime.Now;
            string sqlDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            int balances = currentQuantity; string issues = "";

            // log stock card control
            Query = "insert into apms.stockcard (`stockid`,`drugname`,`date`,`refNO`,`receipts`,`issues`,`balances`) values('"
            + stockid_txt.Text + "', '" + name + "', '" + sqlDate + "', '" + refno + "', '" + quantityIn + "', '" + issues + "', '" + balances + "'); ";
            queryDB(Query,"stockCardUpdate()");
            if (queryValue == 0)
            { MessageBox.Show("~ Query Failure stockCardUpdate() :(", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else { queryValue = 0; }

            clear_btn.PerformClick();
            done_btn.Enabled = true;
            loadStockTable_btn.PerformClick();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string pid = this.stockid_txt.Text;
            string cpu = this.unitsize_txt.Text;
            string name = this.stockname_cmb.Text;
            string quantity = this.supplier_txt.Text;
            string expiry = this.expiry_date.Text;
           
            // UPDATE apms.product SET `name`='max' WHERE `pid`='8';
            string Query = "update apms.product SET " +
            "`name` = '" + name + "'," +
            "`cpu` = '" + cpu + "'," +
            "`quantity` = '" + quantity + "'," +
            //"`price` = '" + price + "'," +
            //"`batch` = '" + batch + "'," +
            "`expiry` = '" + expiry + "' " +
            " where `pid` = '" + pid + "'; ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                MessageBox.Show("> Product Updated", "Edit Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            clear_btn.PerformClick();
            done_btn.Enabled = true;
            loadStockTable_btn.PerformClick();
            stockGrid.Focus();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            string pid = this.stockid_txt.Text;

            string Query = "delete from apms.product where pid = ' " + pid + " ' ; ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                MessageBox.Show("> Product Deleted", "Remove Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            clear_btn.PerformClick();
            done_btn.Enabled = true;
            loadStockTable_btn.PerformClick(); 
            stockGrid.Focus();
        }

        private void done_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = true;
            details_grp.Enabled = false;
            done_btn.Enabled = false;
            query_grp.Visible = false;
            stockGrid.Visible = false;

            clear_btn.PerformClick();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = true;
            details_grp.Enabled = false;
            query_grp.Visible = false;
            stockGrid.Visible = false;

            clear_btn.PerformClick();
        }
        
        private void loadStockTable_btn_Click(object sender, EventArgs e)
        {
            stockGrid.Visible = true;
            string Query = " select stockid as 'Stock ID', Name, stockclass as 'Class', UnitSize as 'Unit Size', Quantity, Supplier, expiry as 'Expiry Date' from `apms`.`stock` ; ";
            loadTable(Query,stockGrid);
        }

        private void stockGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                details_grp.Enabled = true;

                DataGridViewRow row = this.stockGrid.Rows[e.RowIndex];

                stockid_txt.Text = row.Cells["Stock ID"].Value.ToString();
                stockname_cmb.Text = row.Cells["name"].Value.ToString();
                unitsize_txt.Text = row.Cells["unit size"].Value.ToString();
                quantity_txt.Text = row.Cells["quantity"].Value.ToString();
                supplier_txt.Text = row.Cells["supplier"].Value.ToString();
                expiry_date.Text = row.Cells["Expiry Date"].Value.ToString();
            }
        }

        /// ////////////////////////////// PRODUCT DEFINITION TAB ////////////////////////////////////////////

        private void pdClearEntries()
        {
            pnid_txt.Text = ""; stockname_txt.Text = "";
            pcid_txt.Text = ""; thestockclass_txt.Text = "";
            //pnaming_radio.Checked = false; pcategories_radio.Checked = false;
        }

        private void pdNewDef_btn_Click(object sender, EventArgs e)
        {
            pdNewDef_btn.Visible = false;
            pdCloseDef_btn.Visible = true;

            classSelect_grp.Visible = true;

            pdNew_btn.Enabled = true;
            pdEdit_btn.Enabled = true;
            pdRemove_btn.Enabled = true;

            pdClearEntries();
        }

        private void naming_radio_CheckedChanged(object sender, EventArgs e)
        {
            thelabel = "naming";
            checkActiveClass();
            pdClearEntries();
        }

        private void classification_radio_CheckedChanged(object sender, EventArgs e)
        {
            thelabel = "classification";
            checkActiveClass();
            pdClearEntries();
        }

        private void checkActiveClass() 
        {
            if (thelabel == "naming") // stock names
            {
                actions_grp2.Visible = true;

                stocknaming_grp.Visible = true;
                pnTables_grp.Visible = true;
                
                stockclass_grp.Visible = false;
                pcTables_grp.Visible = false;

                pdCancel_btn.PerformClick();
                
            }
            if (thelabel == "classification") // stock class
            {
                actions_grp2.Visible = true;
                
                stockclass_grp.Visible = true;
                pcTables_grp.Visible = true;
                
                stocknaming_grp.Visible = false;
                pnTables_grp.Visible = false;

                pdCancel_btn.PerformClick();
            }
        }

        private void pdNew_btn_Click(object sender, EventArgs e)
        {
            actions_grp2.Enabled = false;           
            query_grp2.Visible = true;
            pdSave_btn.Enabled = true;
            pdUpdate_btn.Enabled = false;
            pdDelete_btn.Enabled = false;

            if (thelabel == "naming")
            {
                stocknaming_grp.Enabled = true;
                stockname_txt.Focus();
                this.ActiveControl = stockname_txt;
            }
            if (thelabel == "classification")
            {
                stockclass_grp.Enabled = true;
                thestockclass_txt.Focus();
                this.ActiveControl = thestockclass_txt;
            }
        }

        private void pdEdit_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = false;
            query_grp2.Visible = true;
            pdSave_btn.Enabled = false;
            pdUpdate_btn.Enabled = true;
            pdDelete_btn.Enabled = false;
          
            pdClearEntries();

            if (thelabel == "naming")
            {
                loadStockNamesTable_btn.PerformClick();
                stockNamesGrid.Focus();
                stocknaming_grp.Enabled = true;
            }
            if (thelabel == "classification")
            {
                loadStockClassTable_btn.PerformClick();
                stockClassGrid.Focus();
                stockclass_grp.Enabled = true;
            }
        }

        private void pdRemove_btn_Click(object sender, EventArgs e)
        {
            actions_grp.Enabled = false;
            query_grp2.Visible = true;
            pdSave_btn.Enabled = false;
            pdUpdate_btn.Enabled = false;
            pdDelete_btn.Enabled = true;
           
            pdClearEntries();

            if (thelabel == "naming")
            {
                loadStockNamesTable_btn.PerformClick();
                stockNamesGrid.Focus();
                stocknaming_grp.Enabled = true;
            }
            if (thelabel == "classification")
            {
                loadStockClassTable_btn.PerformClick();
                stockClassGrid.Focus();
                stockclass_grp.Enabled = true;
            }
        }
        
        private void pdDone_btn_Click(object sender, EventArgs e)
        {
            actions_grp2.Enabled = true;
            stocknaming_grp.Enabled = false;
            stockclass_grp.Enabled = false;
            pdDone_btn.Enabled = false;
            query_grp2.Visible = false;
            //productTable_grp.Visible = false;
            //pnTables_grp.Visible = false;
            //pcTables_grp.Visible = false;
            
            pdClearEntries();
         }

        private void pdCancel_btn_Click(object sender, EventArgs e)
        {
            actions_grp2.Enabled = true;
            stocknaming_grp.Enabled = false;
            stockclass_grp.Enabled = false;
            query_grp2.Visible = false;
            //productTable_grp.Visible = false;
            //pnTables_grp.Visible = false;
            //pcTables_grp.Visible = false;                   

            pdClearEntries();
        }

        private void pdCloseDef_btn_Click(object sender, EventArgs e)
        {
            pdCloseDef_btn.Visible = false;
            pdNewDef_btn.Visible = true;
            
            classSelect_grp.Visible = false;
            naming_radio.Checked = false;
            classification_radio.Checked = false;

            stocknaming_grp.Visible = false;
            stocknaming_grp.Enabled = false;
            //productTable_grp.Visible = false;
            pnTables_grp.Visible = false;
            pcTables_grp.Visible = false;
            stockclass_grp.Visible = false;
            stockclass_grp.Enabled = false;
   
            actions_grp2.Visible = false;
            query_grp2.Visible = false;
            
            pdClearEntries();
        }

        private void pdSave_btn_Click(object sender, EventArgs e)
        {
            if (thelabel == "naming")
            {
                string stockname = this.stockname_txt.Text;
                string nameclass = this.stockclass_cmb.Text;

                // form validation
                if (string.IsNullOrEmpty(stockname))
                { MessageBox.Show("~ please provide stock name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (string.IsNullOrEmpty(nameclass))
                { MessageBox.Show("~ please provide stock class", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                /*
                string Query = "insert into apms.stock_names (`name`,`nameclass`) values('"
                    + stockname + "', '" + nameclass +"'); ";
                */ 
                string Query = "insert into apms.stock (`name`,`stockclass`,`unitsize`,`quantity`,`supplier`,`expiry`,`refno`) values('"
                    + stockname + "', '" + nameclass + "', '" + 0 + "', '" + 0 + "', '' , '0001-01-01', ''); ";

                queryDB(Query, "nameclassSave()");
                if (queryValue == 7)
                {   
                    MessageBox.Show("> Stock Name & Class Captured", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    loadStockNamesTable_btn.PerformClick();
                    stockname_cmb.Items.Add(stockname); stockname_cmb2.Items.Add(stockname);
                    stockname_txt.Focus();
                    queryValue = 0;
                }
                else
                { MessageBox.Show("~ Query Failure :(", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }                
            }

            if (thelabel == "classification")
            {
                string stockclass = this.thestockclass_txt.Text;

                // form validation
                if (string.IsNullOrEmpty(stockclass))
                { MessageBox.Show("~ please provide product category", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                string Query = "insert into apms.stock_class (`stockclass`) values('" + stockclass + "'); ";
               
                queryDB(Query, "classSave()");
                if (queryValue == 7)
                {
                    MessageBox.Show("> Stock Category Captured", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadStockClassTable_btn.PerformClick();
                    stockclass_cmb.Items.Add(stockclass);
                    thestockclass_txt.Focus();
                }
                else
                { MessageBox.Show("~ Query Failure :(", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }                            
            }

            pdDone_btn.Enabled = true;
            pdClearEntries();
        }

        private void pdUpdate_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            if (thelabel == "naming")
            {
                string pnname = this.stockname_txt.Text;
                string pnid = this.pnid_txt.Text;

                // form validation
                if (string.IsNullOrEmpty(pnname))
                { MessageBox.Show("~ please provide product name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                // UPDATE apms.stock SET `name`='max' WHERE `pid`='8';
                string Query = "update apms.stock_names SET " +
                "`pnname` = ' " + pnname + " ' " +
                " where `pnid` = '" + pnid + "'; ";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    MessageBox.Show("> Product Name Updated", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    while (myReader.Read())
                    { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                loadStockNamesTable_btn.PerformClick();
                stockNamesGrid.Focus();
            }

            if (thelabel == "classification")
            {
                string pcname = this.thestockclass_txt.Text;
                string pcid = this.pcid_txt.Text;

                // form validation
                if (string.IsNullOrEmpty(pcname))
                { MessageBox.Show("~ please provide product category name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                // UPDATE apms.product SET `name`='max' WHERE `pid`='8';
                string Query = "update apms.stock_class SET " +
                "`pcname` = ' " + pcname + " ' " +
                " where `pcid` = '" + pcid + "'; ";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    MessageBox.Show("> Product Category Name Updated", "New Record Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    while (myReader.Read())
                    { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                loadStockClassTable_btn.PerformClick();
                stockClassGrid.Focus();
            }
            
            pdDone_btn.Enabled = true;
            pdClearEntries();

        }

        private void pdDelete_btn_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=5011";

            if (thelabel == "naming")
            {
                string pnid = this.pnid_txt.Text;

                string Query = "delete from apms.stock_names where pnid = ' " + pnid + " ' ; ";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    MessageBox.Show("> Product Name Deleted", "Remove Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read())
                    { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                loadStockNamesTable_btn.PerformClick();
                stockNamesGrid.Focus();
            }

            if (thelabel == "classification")
            {
                string pcid = this.pcid_txt.Text;

                string Query = "delete from apms.stock_class where pcid = ' " + pcid + " ' ; ";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    MessageBox.Show("> Product Category Name Deleted", "Remove Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (myReader.Read())
                    { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                stockClassGrid.Focus();
                loadStockClassTable_btn.PerformClick();
            }

            pdDone_btn.Enabled = true;
            pdClearEntries();
        }

        private void loadStockNamesTable_btn_Click(object sender, EventArgs e)
        {
            string Query = " select nameid as 'Name ID', name as 'Stock Name', nameclass as 'Class' from `apms`.`stock_names` ; ";
            loadTable(Query, stockNamesGrid);
        }

        private void stockNamesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.stockNamesGrid.Rows[e.RowIndex];

                pnid_txt.Text = row.Cells["Name ID"].Value.ToString();
                stockname_txt.Text = row.Cells["Stock Name"].Value.ToString();
                stockclass_cmb.Text = row.Cells["Class"].Value.ToString();
            }
        }

        private void fillstockNameCombo()
        {
            string Query = "select * from apms.stock ; ";

            queryDB(Query, "fillstockNameCombo()");
            if (queryValue == 0)
            { MessageBox.Show("~ Query Failure fillstockNameCombo() :(", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        }

        private void loadStockClassTable_btn_Click(object sender, EventArgs e)
        {
            string Query = " select classid as 'Class ID', stockclass as 'Class' from `apms`.`stock_class` ; ";
            loadTable(Query, stockClassGrid);
        }

        private void stockClassGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.stockClassGrid.Rows[e.RowIndex];

                pcid_txt.Text = row.Cells["Class ID"].Value.ToString();
                thestockclass_txt.Text = row.Cells["Class"].Value.ToString();
            }
        }

        private void fillclassNameCombo()
        {
            string Query = " select * from apms.stock_class ";
            queryDB(Query, "fillclassNameCombo()");
            if (queryValue == 0)
            { MessageBox.Show("~ Query Failure fillclassNameCombo() :(", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        }

        private void loadStockGrid_btn_Click(object sender, EventArgs e)
        {
            stockCardGrid.Visible = true;
            
            string Query = " select Date, RefNO, Receipts, Issues, Balances from `apms`.`stockcard` where drugname = '" + stockname_cmb2.Text + "' ;";
            loadTable(Query, stockCardGrid);
        }
    }
}

