using Biometric.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AccountSecure.Interface;
using AccountSecure.Entity;
using System.Linq;


namespace AccountSecure.App
{
    public partial class FrmUser : Form
    {
        Users user = new Users();
        IEnumerable<AppUser> currUser;
        int _userId = 0;
        public FrmUser()
        {
            InitializeComponent();
        }
        public FrmUser(string title, object user)
            : this()
        {
         
            if (title.ToLower() == "edit")
            {
                this.Text = "Edit User";
                btnCreate.Text = "&Update";
                currUser = (IEnumerable<AppUser>)user;
                AppUser _user = currUser.ToList()[0];
                _userId = _user.UserId;
                FixCustomer(_user);
            }
        }
        private void FixCustomer(AppUser _user)
        {
            txtUsername.Text = _user.Username;
            cmbSex.Text = _user.Sex;
            txtDept.Text = _user.Department;
            txtFirstname.Text = _user.Firstname;
            txtMidname.Text = _user.Lastname;
            txtSurname.Text = _user.Surname;
            txtPassword.Text = _user.Password;
            txtCnfPswd.Text = _user.Password;  
        }
        private new bool Validate()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Username cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbSex.Text))
            {
                MessageBox.Show("Sex is required.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSex.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password is required.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtCnfPswd.Text) || !txtCnfPswd.Text.Equals(txtPassword.Text))
            {
                MessageBox.Show("Confirm password does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCnfPswd.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                MessageBox.Show("Firstname is required.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFirstname.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSurname.Text))
            {
                MessageBox.Show("Surname is required.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSurname.Focus();
                return false;
            }

            else return true;


        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    bool accepted;
                    if (btnCreate.Text.ToLower().Contains("update"))
                        accepted = UpdateUser(_userId);
                    else
                        accepted = AddUser();
                    if (!accepted)
                    {
                        throw new Exception("Not successfully created/updated");
                    }
                    MessageBox.Show("Customer successfully created/updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MasterForm.processFrm != null)
                    {
                        this.Close();
                        //MasterForm.processFrm.CallBack(id.ToString());
                        Form frmMdi = MasterForm.processFrm.MdiParent;
                        MasterForm.processFrm.Close();
                        MasterForm.processFrm = new FrmTransaction();
                        MasterForm.processFrm.MdiParent = frmMdi;
                        MasterForm.processFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AddUser()
        {
            Users user = new Users
            {
                Firstname = txtFirstname.Text,
                Surname = txtSurname.Text,
                Lastname = txtMidname.Text,
                Password = txtPassword.Text,
                Sex = cmbSex.Text,
                Department = txtDept.Text,
                Username = txtUsername.Text
            };
            bool added = user.Add();
            return added;
        }
        private bool UpdateUser(int userId)
        {
            Users user = new Users
            {
                UserId = userId,
                Firstname = txtFirstname.Text,
                Surname = txtSurname.Text,
                Lastname = txtMidname.Text,
                Password = txtPassword.Text,
                Sex = cmbSex.Text,
                Department = txtDept.Text,
                Username = txtUsername.Text
            };
            bool updated = user.Update();
            return updated;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'serviceDescDataSet.tblServices' table. You can move, or remove it, as needed.
            //this.tblServicesTableAdapter.Fill(this.serviceDescDataSet.stpServicesSelectAll);

        }

        private void FrmCustomer_FormClosing(object sender, FormClosingEventArgs e)
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
            treeView1.Nodes[0].Nodes.RemoveByKey("user");
        }
    }
}
