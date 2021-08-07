using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace AccountSecure.App
{
    public partial class MasterForm : Form
    {
        private int childFormNumber = 0;
        public static FrmTransaction processFrm = null;
        //public static FrmSync frmSync = null;

        public static MasterForm masterfrm = null;

        public MasterForm()
        {
            InitializeComponent();
            masterfrm = this;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            Form childForm = new Form();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: Add code here to open the file.
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: Add code here to save the current contents of the form to a file.
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }


        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            masterfrm = this;
            treeView1.Nodes[0].ExpandAll();
        }

        private void ProcessToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            //if (processFrm == null)
            {
                processFrm = new FrmTransaction();
                toolStripProgressBar1.Visible = true;
                toolStripProgressBar1.Value = 3;
                toolStripStatusLabel1.Text = "Transaction Windows form Loading...";
                processFrm.MdiParent = this;
                processFrm.Show();
                toolStripStatusLabel1.Text = "Transaction Windows Loaded";
                toolStripProgressBar1.Visible = false;
                processFrm.ShowInTaskbar = true;
                treeView1.Nodes[0].Nodes.Add("process", "Transaction Windows");
                treeView1.Nodes[0].ExpandAll();
            }
            
        }

        private void NewCustomerMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomer frm = new FrmCustomer();
            //if (MasterForm.processFrm != null)
            //    frm.ShowDialog(new frmItemProcess());
            //else
            //{
            //    frm.Show(this);
            //}
            frm.MdiParent = this;
            frm.Show();
            
            treeView1.Nodes[0].Nodes.Add("cust", "Manage Customer");
            treeView1.Nodes[0].ExpandAll();
            
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure close this application?", "Account Secure - TransEmulator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                //System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode tn = treeView1.GetNodeAt(e.X, e.Y);
            //treeView1.SelectedNode = tn;
        } 
        
        private void appConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig frmconfig = new FrmConfig();
            frmconfig.ShowDialog();
        }

        private void MSDTCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("dcomcnfg.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void commandPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("cmd.exe", @"/C dcomcnfg");
            System.Diagnostics.Process.Start("cmd.exe");
        }

        private void pingServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = ConfigurationManager.AppSettings["ServerIP"].ToString();
                string arg = string.Format("/C ping {0} /t", ip);
                System.Diagnostics.Process.Start("cmd.exe", @arg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
           
           
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes.Add("user", "Users");
            treeView1.Nodes[0].ExpandAll();
            FrmUser frmUser = new FrmUser();
            frmUser.Show(this);
            
        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes.Add("viewUser", "View Users");
            treeView1.Nodes[0].ExpandAll();
            FrmViewUser frmViewUser = new FrmViewUser();
            frmViewUser.MdiParent = this;
            frmViewUser.Show();
        }

        private void viewCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes.Add("viewCust", "View Customers");
            treeView1.Nodes[0].ExpandAll();
            FrmViewCustomers frmViewCust = new FrmViewCustomers();
            //FrmItem frmItem = new FrmItem();
            //frmItem.MdiParent = this;
            frmViewCust.Show(this);
           
        }

        private void viewTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes.Add("viewTrans", "View Transactions");
            treeView1.Nodes[0].ExpandAll();
            FrmViewTransaction frmViewTrans = new FrmViewTransaction();
            //FrmItem frmItem = new FrmItem();
            //frmItem.MdiParent = this;
            frmViewTrans.Show(this);
        }

        private void viewGeneralLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes.Add("viewGL", "General Ledger");
            treeView1.Nodes[0].ExpandAll();
            FrmGLedger frmViewTrans = new FrmGLedger();
            //FrmItem frmItem = new FrmItem();
            //frmItem.MdiParent = this;
            frmViewTrans.Show(this);
        }    
    }
}
