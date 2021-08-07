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
    public partial class FrmViewCustomers : Form
    {
        int custId = 0;
        string accountNo = "";
        public FrmViewCustomers()
        {
            InitializeComponent();
        }
        private void LoadCustomer(int custid)
        {
            try
            {
                dataGridView1.DataSource = null;
                //Load image 
                CustomerDetails custDetail = new CustomerDetails { CustId = custid };
                IEnumerable<CustomerDetails> custList;
                if (custid > 0)
                    custList = custDetail.SelectByID();
                else custList = custDetail.SelectAll();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataMember = "CustomerDetails";
                dataGridView1.DataSource = custList;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FrmQuery frmquery = new FrmQuery();
                if (frmquery.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    accountNo = frmquery.AccountNo;
                    string name = frmquery.CustName;
                    string phone = frmquery.PhoneNo;
                    //get customer detail
                    Customers myCust = new CustomerDetails
                    {
                        AcctNo = accountNo,
                        Fullname = name,
                        PhoneNo = phone
                    }.Search();
                    if (myCust != null)
                    {
                        custId = myCust.CustId;
                        accountNo = myCust.AcctNo;
                        LoadCustomer(custId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadCustomer(0);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                int custid = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                CustomerDetails custDetail = new CustomerDetails { CustId = custid };
                IEnumerable<CustomerDetails> custList = custDetail.SelectByID();
                FrmCustomer frmCust = new FrmCustomer("Edit", custList);
                frmCust.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmViewCustomers_FormClosing(object sender, FormClosingEventArgs e)
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
            treeView1.Nodes[0].Nodes.RemoveByKey("viewCust");
        }
    }
}
