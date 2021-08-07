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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        public bool Login { get; set; }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;

            user = user.Login();
            if (user != null && user.UserId > 0)
            {
                AcctLogin.UserId = user.UserId.ToString();
                AcctLogin.Username = user.Username;
                AcctLogin.Name = user.Fullname;
                AcctLogin.Department = user.Department;
                Login = true;
            }
            else Login = false;
        }
    }
}
