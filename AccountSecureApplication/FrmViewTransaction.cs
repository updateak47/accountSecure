using AccountSecure.Interface;
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
    public partial class FrmViewTransaction : Form
    {
        public FrmViewTransaction()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                IEnumerable<TransactionDetail> transList;
                Transaction trans;
                if (rdAcct.Checked)
                {
                    trans = new Transaction { AcctNo = txtParam.Text.Trim() };
                    transList = trans.SelectTransactionsByAcctNo();
                }
                else
                {
                    trans = new Transaction { TransRefNo = txtParam.Text.Trim() };
                    transList = trans.SelectTransactionByRefNum();
                }
                if (transList == null || transList.Count() == 0)
                    throw new Exception("No record found.");
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataMember = "TransactionDetail";
                dataGridView1.DataSource = transList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " It could be a wrong selection of the option buttons.", "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmViewTransaction_Load(object sender, EventArgs e)
        {

        }

        private void FrmViewTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            TreeView treeView1 = null;
            if (this.ParentForm != null)
            {
                treeView1 = (TreeView)this.ParentForm.Controls["treeView1"];
            }
            else
            {
                treeView1 = (TreeView)MasterForm.masterfrm.Controls["treeView1"];
            }
            treeView1.Nodes[0].Nodes.RemoveByKey("viewTrans");
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                IEnumerable<TransactionDetail> transList;
                Transaction trans = new Transaction { AcctNo = txtParam.Text.Trim() };
                transList = trans.SelectAllTransactions();

                if (transList == null || transList.Count() == 0)
                    throw new Exception("No record found.");
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataMember = "TransactionDetail";
                dataGridView1.DataSource = transList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " It could be a wrong selection of the option buttons.", "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
