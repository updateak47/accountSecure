using AccountSecure.Interface;
using Biometric.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;



namespace AccountSecure.App
{
    public partial class FrmCustomer : Form
    {
        CustomerDetails customer = new CustomerDetails();
        IBioDevice device;
        IEnumerable<CustomerDetails> currCustomer;
        int _custId = 0;
        public FrmCustomer()
        {
            InitializeComponent();

        }
        public FrmCustomer(string title, object cust)
            : this()
        {
            if (title.ToLower() == "edit")
            {
                this.Text = "Edit Customer";
                btnCreate.Text = "&Update";
                currCustomer = (IEnumerable<CustomerDetails>)cust;
                CustomerDetails _cust = currCustomer.ToList()[0];
                _custId = _cust.CustId;
                FixCustomer(_cust);
            }
        }
        void device_OnErrorMessage(object sender, Biometric.Tasks.MessageEventArgs e)
        {
            label7.Text = "Scanner stopped";
            string msg = e.exception == null ? e.message : e.exception.Message;
            MessageBox.Show(msg);

        }

        void device_OnDetected(object sender, Biometric.Tasks.BioEventArgs e)
        {
            //Image image = BioImage.ResizeImage(e.CapturedImage, 240, 220);
            //if (image != null)
            {
                if (e.BiometricType == Biometric.Tasks.BiometricTypeMode.Finger)
                {
                    pixFinger.Image = BioImage.Resize(e.CapturedImage, 240, 220); 
                }
                else
                {
                    pixFacial.Image = BioImage.Resize(e.CapturedImage, pixFacial.Width, pixFacial.Height); 
                }
            }
        }
        private new bool Validate()
        {
            if (string.IsNullOrEmpty(txtfname.Text))
            {
                MessageBox.Show("First name cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtfname.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbSex.Text))
            {
                MessageBox.Show("Sex is required.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSex.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtHome.Text))
            {
                MessageBox.Show("Home Address is required.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHome.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Phone no is required.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhone.Focus();
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
                        accepted = UpdateCustomer(_custId);
                    else
                        accepted = AddCustomer();
                    if (!accepted)
                    {
                        throw new Exception("Not successfully added/updated");
                    }
                    MessageBox.Show("Customer successfully added/updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void FixCustomer(CustomerDetails _cust)
        {
            txtfname.Text = _cust.Fullname;
            cmbSex.Text = _cust.Sex;
            dateTimePicker1.Value = _cust.Dateofbirth;
            txtHome.Text = _cust.HomeAddress;
            txtOffice.Text = _cust.OfficeAddress;
            txtPhone.Text = _cust.PhoneNo;
            txtEmail.Text = _cust.Email;
            cmbAccountType.Text = _cust.AccType;
        }
        private bool AddCustomer()
        {
            //set the proper
            CustomerDetails customer = new CustomerDetails
            {
                Fullname = txtfname.Text,
                Sex = cmbSex.Text,
                Dateofbirth = DateTime.Parse(dateTimePicker1.Text),
                HomeAddress = txtHome.Text,
                OfficeAddress = txtOffice.Text,
                PhoneNo = txtPhone.Text,
                Email = txtEmail.Text,
                FacialImage = pixFacial.Image,
                FingerPrintImage = pixFinger.Image,
                AcctTypeId = cmbAccountType.Items.IndexOf(cmbAccountType.Text)
            };
            bool added = customer.Add();
            return added;
        }
        private bool UpdateCustomer(int custId)
        {
            //set the proper
            CustomerDetails customer = new CustomerDetails
            {
                CustId = custId,
                Fullname = txtfname.Text,
                Sex = cmbSex.Text,
                Dateofbirth = DateTime.Parse(dateTimePicker1.Text),
                HomeAddress = txtHome.Text,
                OfficeAddress = txtOffice.Text,
                PhoneNo = txtPhone.Text,
                Email = txtEmail.Text,
                AcctTypeId = cmbAccountType.Items.IndexOf(cmbAccountType.Text)
            };
            bool updated = customer.Update();
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
            device.Stop();
            if (this.ParentForm != null)
            {
                treeView1 = (TreeView)this.ParentForm.Controls["treeView1"];
            }
            else
            {
                treeView1 = (TreeView)MasterForm.masterfrm.Controls["treeView1"];
            }
            treeView1.Nodes[0].Nodes.RemoveByKey("cust");
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabCustInfo.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabCustInfo.SelectedIndex = 0;
        }

        private void btnStart_fin_Click(object sender, EventArgs e)
        {
            device = BiometricDeviceFactory.CreateDeviceInstance(BiometricDevices.FINGERPRINT);
            device.OnDetected += device_OnDetected;
            device.OnErrorMessage += device_OnErrorMessage;
            label7.Text = "Scanner started";
            device.Start();
            //device.Stop();
        }

        private void btnStart_fac_Click(object sender, EventArgs e)
        {
            device = BiometricDeviceFactory.CreateDeviceInstance(BiometricDevices.CAMERA);
            device.OnDetected += device_OnDetected;
            device.OnErrorMessage += device_OnErrorMessage;
            device.Start();
        }

        private void btnCapture_fin_Click(object sender, EventArgs e)
        {
            device.Stop();
        }

        private void btnStop_fin_Click(object sender, EventArgs e)
        {
            device.Stop();
            label7.Text = "Scanner stopped";
        }

        private void btnStop_cam_Click(object sender, EventArgs e)
        {
            device.Stop();
        }
    }
}
