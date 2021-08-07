using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountSecure.App
{
    public partial class FrmQuery : Form
    {
        public FrmQuery()
        {
            InitializeComponent();
        }
        
        private void FrmQuery_Load(object sender, EventArgs e)
        {
           
        }
        public string AccountNo
        {
            get { return txtAcctNo.Text; }
            set { txtAcctNo.Text = value; }
        }
        public string CustName
        {
            get { return txtCustName.Text; }
            set { txtCustName.Text = value; }
        }
        public string PhoneNo
        {
            get { return txtPhoneNo.Text; }
            set { txtPhoneNo.Text = value; }
        }
    }
}
