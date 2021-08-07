using AccountSecure.Entity;
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
    public partial class FrmGLedger : Form
    {
        public FrmGLedger()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                IEnumerable<GLedger> transList;
                Transaction transGL = new Transaction { AcctNo = txtParam.Text.Trim() };
                if (rdAcct.Checked)
                {
                    transGL = new Transaction { AcctNo = txtParam.Text.Trim() };
                    transList = transGL.SelectGLedgerByAcctNo();
                }
                else
                {
                    transGL = new Transaction { TransRefNo = txtParam.Text.Trim() };
                    transList = transGL.SelectGLedgerByRef();
                }
                if (transList == null || transList.Count() == 0)
                    throw new Exception("No record found.");
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataMember = "GLedger";
                dataGridView1.DataSource = transList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " It could be a wrong selection of the option buttons.", "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmGLedger_FormClosing(object sender, FormClosingEventArgs e)
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
            treeView1.Nodes[0].Nodes.RemoveByKey("viewGL");
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                IEnumerable<GLedger> transList;
                Transaction transGL = new Transaction { AcctNo = txtParam.Text.Trim() };
                transList = transGL.SelectAllGLedger();

                if (transList == null || transList.Count() == 0)
                    throw new Exception("No record found.");
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataMember = "GLedger";
                dataGridView1.DataSource = transList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " It could be a wrong selection of the option buttons.", "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
