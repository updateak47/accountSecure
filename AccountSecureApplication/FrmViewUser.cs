using AccountSecure.Entity;
using AccountSecure.Interface;
using System;
using System. Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountSecure.App
{
    public partial class FrmViewUser : Form
    {
        public FrmViewUser()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Users user = new Users
            {
                Username = txtUsername.Text.Trim()
            };
            LoadUser(user.SelectUser());
        }
        private void LoadUser(IEnumerable<AppUser> users)
        {
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataMember = "AppUser";
            dataGridView1.DataSource = users;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = new Users
                {
                    Username = txtUsername.Text.Trim()
                };
                LoadUser(user.SelectAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                string userid = (dataGridView1.Rows[i].Cells[1].Value.ToString());
                Users userDetail = new Users { Username = userid };
                IEnumerable<AppUser> userList = userDetail.SelectUser();
                FrmUser frmUser = new FrmUser("Edit", userList);
                frmUser.MdiParent = MasterForm.masterfrm;
                frmUser.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmViewUser_FormClosing(object sender, FormClosingEventArgs e)
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
            treeView1.Nodes[0].Nodes.RemoveByKey("viewUser");
        }
    }
}
