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
    public partial class ClientPresDoctor : MetroForm
    {
        // delegate
        public delegate void DocNameUpdateHandler(object sender, DocNameUpdateEventArgs e);
        
        // even of delegate type
        public event DocNameUpdateHandler DocNameUpdated;

        public ClientPresDoctor()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            DocNameUpdateEventArgs args = new DocNameUpdateEventArgs("enableAddPresButton");
            DocNameUpdated(this, args);
            this.Dispose();
        }

        // this button click event handler will raise the event which can then intercepted by any
        // listeners // read the textboxes and set the variables
        private void done_btn_Click(object sender, EventArgs e)
        {
            string presDoc = presDocName_txt.Text; 
            
            // form validation
            // if empty >
            if (string.IsNullOrEmpty(presDoc))
            { MessageBox.Show("~ please provide name of doctor that issued this prescription", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); presDocName_txt.Focus(); return; }
         
            DialogResult result = MessageBox.Show("Proceed to Add Drugs?","Doctor Name Entry",
            MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
               // instance the event args and pass it each value
                DocNameUpdateEventArgs args = new DocNameUpdateEventArgs(presDoc);

               // raise the event with the updated arguments
               DocNameUpdated(this, args);
               this.Dispose();
            }
        }
    }

    public class DocNameUpdateEventArgs : System.EventArgs
    {
        private string thePresDoc;
        private string theAddPresBtnStatus;

        public DocNameUpdateEventArgs(string assigner)
        {
            this.thePresDoc = assigner;
            this.theAddPresBtnStatus = assigner;
        }
       
        public string getPrescibingDoc
        {
            get { return thePresDoc; }
        }

        public string getAddPresBtnStatus
        {
            get { return theAddPresBtnStatus; }
        }
    }
}