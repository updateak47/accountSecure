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
    public partial class FrmTransaction : Form
    {
        int custId = 0;
        string accountNo = "";
        byte[] fingerPrint = null;
        Image facialImage = null;
        public FrmTransaction()
        {
            InitializeComponent();
            //cmbType.DataSource = TransTypeDataSource
            BindComboBox();
        }
        bool Isdecimal(string text)
        {
            try
            {
                decimal.Parse(text);
                return true;
            }
            catch (Exception) { return false; }
        }
        new bool Validate()
        {
            if (string.IsNullOrEmpty(txtAmount.Text) || !Isdecimal(txtAmount.Text))
            {
                txtAmount.Focus();
                return false;
            }
            else if (txtAccountTo.Enabled && string.IsNullOrEmpty(txtAccountTo.Text))
            {
                txtAccountTo.Focus();
                return false;
            }
            else return true;
        }
        private void BindComboBox()
        {
            try
            {
                TransactionTypeDefault transType = new TransactionTypeDefault();
                IEnumerable<TransactionType> _transTypelist = transType.SelectAll();

                cmbType.DisplayMember = "TransDesc";
                cmbType.ValueMember = "TransTypeId";
                cmbType.DataSource = _transTypelist;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                        lblName.Text = myCust.Fullname;
                        lblAccount.Text = myCust.AcctNo;
                        label1.Text = "AcctNo:";
                        //load balance from GL
                        txtBalance.Text = string.Format("{0:N2}", Transaction.GetGLBal(myCust.AcctNo));

                        accountNo = myCust.AcctNo;
                        //Load image 
                        CustomerDetails custDetail = new CustomerDetails
                        {
                            CustId = custId
                        }.SelectFingerAndFacial();

                        Image custImage = AccountSecure.Interface.ImageConverter.ToImage(custDetail.FacialBytes, 0, custDetail.FacialBytes.Length);
                        pixFacial.Image = facialImage = custImage.Resize(pixFacial.Width, pixFacial.Height);

                        fingerPrint = custDetail.FingerPrintBytes;

                        //load last 10 transactions

                        LastTenTransactions(myCust.AcctNo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LastTenTransactions(string acctNo)
        {
            dataGridView1.DataSource = null;
            IEnumerable<TransactionDetail> transList = new Transaction { AcctNo = acctNo }.SelectLastTen();
            dataGridView1.AutoGenerateColumns = false;

            //dataGridView1.DataMember = "TransactionDetail";
            dataGridView1.DataSource = transList;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.Text == "TRANSFER")
            {
                txtAccountTo.Enabled = true;
            }
            else txtAccountTo.Enabled = false;
        }
        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            lblAccount.Text = lblName.Text = label1.Text = lblReport.Text = "";
        }
        private void btnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                lblReport.Text = "";
                if (!Validate()) throw new Exception("Enter value.");
                if (decimal.Parse(txtAmount.Text) > decimal.Parse(txtBalance.Text) && cmbType.Text.ToLower() == "withdraw")
                {
                    throw new Exception("You have insufficient fund.");
                }
                string message = ""; bool fg_verified = true; //bool fc_verified = true;

                if (cmbType.Text.ToLower() != "deposit")
                {
                    fg_verified = false;
                    if (fingerPrint != null && facialImage != null)
                    {
                        FrmVerify frmVerify = new FrmVerify(custId, accountNo, fingerPrint);
                        if (frmVerify.ShowDialog() == DialogResult.OK)
                        {
                            fg_verified = frmVerify.Verified;
                            message = frmVerify.ErrorMessage;
                        }
                        frmVerify = null;
                    }
                    else throw new Exception("Customer Fingerprint could not be loaded.");
                }
                if (fg_verified)
                {
                    //validate the facial image 
                    if (cmbType.Text.ToLower() != "deposit")
                    {
                        ////FrmRecognize frmRecognize = new FrmRecognize(custId, accountNo, facialImage);
                        //FrmRecognizer frmRecognize = new FrmRecognizer(custId, accountNo, facialImage);
                        //if (frmRecognize.ShowDialog() == DialogResult.OK)
                        //{
                        //    fg_verified = frmRecognize.Verified;
                        //    message = frmRecognize.ErrorMessage;
                        //}

                        fg_verified = true;
                    }
                    int transTypeId = int.Parse(cmbType.SelectedValue.ToString());
                    if (fg_verified)
                    {
                        //post to transaction journal
                        Transaction trans = new Transaction
                        {
                            AcctNo = accountNo,
                            Amount = decimal.Parse(txtAmount.Text),
                            Narration = txtNarration.Text,
                            TransTypeId = transTypeId,
                            TransRefNo = string.Format("{0}{1:D4}{2:D2}", DateTime.Now.Ticks, custId, transTypeId),
                            TransDate = DateTime.Now,
                            ValueDate = DateTime.Now,
                            UserId = int.Parse(AcctLogin.UserId)
                        };
                        bool added = trans.AddTransaction();
                        //post to GLedger
                        if (added)
                        {
                            TransactionMode mode = new TransMode().Get(cmbType.Text);
                            trans.PostTransactionToGL(mode);

                            //change the accountNo to CASH ACCOUNT 
                            trans.AcctNo = BankAccountNumbers.CASH_ACOUNT;
                            mode = new TransMode().Reverse(mode);
                            added = trans.PostTransactionToGL(mode);
                            if (added)
                            {
                                MessageBox.Show("Successfully committed.", "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else { throw new Exception("Not successfully committed"); }
                    }
                    else
                    {
                        lblReport.Text = message;
                        throw new Exception(string.Format("FacialRecognitionError: {0}", message));
                    }
                }
                else
                {
                    lblReport.Text = message;
                    throw new Exception(string.Format("FingerPrintVerificationError: {0}", message));
                }
                LastTenTransactions(accountNo);
                //load balance from GL
                txtBalance.Text = string.Format("{0:N2}", Transaction.GetGLBal(accountNo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Account Secure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmTransaction_FormClosing(object sender, FormClosingEventArgs e)
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
            treeView1.Nodes[0].Nodes.RemoveByKey("process");
        }
    }
}
