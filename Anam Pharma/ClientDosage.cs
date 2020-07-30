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

namespace Anam_Pharma
{
    public partial class ClientDosage : MetroForm
    {
        // delegate
        public delegate void DispenseUpdateHandler(object sender, DispenseUpdateEventArgs e);
        
        // even of delegate type
        public event DispenseUpdateHandler DispenseUpdated;

        string pid, unitsAvail = "";
        string theDrugDispensed = "";

        public ClientDosage(String thepid,String theProductName, String theUnits)
        {
            InitializeComponent();

            theDrugDispensed = theProductName;
            prodName_lbl.Text = theProductName; // display product's name
            units_lbl.Text = theUnits; // display product's available units
            unitsAvail = theUnits;

            pid = thepid; // active product ID based on table click
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // this button click event handler will raise the event which can then intercepted by any
        // listeners // read the textboxes and set the variables
        private void done_btn_Click(object sender, EventArgs e)
        {
            string uUnitsOut = unitsOUT_txt.Text; 
            string dDosage = dosage_txt.Text;
            
            // form validation
            // if empty >
            if (string.IsNullOrEmpty(uUnitsOut))
            { MessageBox.Show("~ please enter units to dispense", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); unitsOUT_txt.Focus(); return; }
            if (string.IsNullOrEmpty(dDosage))
            { MessageBox.Show("~ please enter dosage instructions", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); dosage_txt.Focus(); return; }
            
            // if non-integer >
            int tester;
            if (!Int32.TryParse(unitsOUT_txt.Text, out tester))
            {
                { MessageBox.Show("~ units dispense entry must be an integer", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); unitsOUT_txt.Focus(); return; }
            }

            // if illogical
            int unitsOut = Int32.Parse(uUnitsOut);
            if (unitsOut < 1)
            { MessageBox.Show("~ units dispense entry is illogical", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); unitsOUT_txt.Focus(); return; }

            // theunits = STOCK_AVAIL - STOCK_OUT
            int theunits = Int32.Parse(unitsAvail) - unitsOut;

            if (theunits >= 0) // products still in-stock
            {

                DialogResult result = MessageBox.Show("Dispense this product?","Dispense Confirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    // instance the event args and pass it each value
                    DispenseUpdateEventArgs args = new DispenseUpdateEventArgs(pid, dDosage, theunits, unitsOut, theDrugDispensed);

                    // raise the event with the updated arguments
                    DispenseUpdated(this, args);
                    this.Dispose();
                }
            }
            else // products will be out of stock
            {
                MessageBox.Show("> Sorry, dispense limit exceeded. Re-stock or Try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }

    public class DispenseUpdateEventArgs : System.EventArgs
    {
        private int daunits, daUnitsOut;
        private string dosage, pid, daDrug;

        public DispenseUpdateEventArgs(string pPid, string dDosage, int theunits, int unitsOut, string theDrugDispensed)
        {
            this.dosage = dDosage;
            this.pid = pPid;
            this.daunits = theunits;
            this.daUnitsOut = unitsOut;
            this.daDrug = theDrugDispensed;
        }

        public int getDaUnits
        {
            get { return daunits; }
        }

        public int getDaUnitsOut
        {
            get { return daUnitsOut; }
        }

        public string getPid
        {
            get { return pid; }
        }

        public string getDosage
        {
            get { return dosage; }
        }

        public string getTheDrugDispensed
        {
            get { return daDrug ; }
        }
    }

}
