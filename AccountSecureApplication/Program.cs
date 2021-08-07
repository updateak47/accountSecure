using AccountSecure.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountSecureApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //string no = string.Format("{0}{1:D4}{2:D2}", DateTime.Now.Ticks, 1, 1);
                AccountSecure.Interface.Database.Set();
                //Render MasterForm as the starting Window Form.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Login Window 
                FrmLogin frmlogin = new FrmLogin();
                if (frmlogin.ShowDialog() == DialogResult.OK)
                {
                    if (frmlogin.Login)
                    {
                        Application.Run(new MasterForm());
                    }
                    else
                    {
                        throw new Exception("Username or password is invalid. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
    }
}
