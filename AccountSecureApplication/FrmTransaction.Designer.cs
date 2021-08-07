namespace AccountSecure.App
{
    partial class FrmTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReport = new System.Windows.Forms.Label();
            this.pixFacial = new System.Windows.Forms.PictureBox();
            this.btnCommit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccountTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.TransTypeDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TransRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAccount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixFacial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransTypeDataSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(21, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 31);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Customer Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblReport);
            this.panel1.Controls.Add(this.pixFacial);
            this.panel1.Controls.Add(this.btnCommit);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtNarration);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAccountTo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtBalance);
            this.panel1.Location = new System.Drawing.Point(21, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 322);
            this.panel1.TabIndex = 1;
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.ForeColor = System.Drawing.Color.Red;
            this.lblReport.Location = new System.Drawing.Point(336, 12);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(53, 20);
            this.lblReport.TabIndex = 14;
            this.lblReport.Text = "label7";
            // 
            // pixFacial
            // 
            this.pixFacial.Location = new System.Drawing.Point(772, 28);
            this.pixFacial.Name = "pixFacial";
            this.pixFacial.Size = new System.Drawing.Size(273, 259);
            this.pixFacial.TabIndex = 13;
            this.pixFacial.TabStop = false;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(359, 265);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(238, 41);
            this.btnCommit.TabIndex = 12;
            this.btnCommit.Text = "Commit Transaction";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Narration";
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(193, 164);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(530, 88);
            this.txtNarration.TabIndex = 10;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(193, 127);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(256, 23);
            this.txtAmount.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Amount ";
            // 
            // txtAccountTo
            // 
            this.txtAccountTo.Enabled = false;
            this.txtAccountTo.Location = new System.Drawing.Point(474, 82);
            this.txtAccountTo.Name = "txtAccountTo";
            this.txtAccountTo.Size = new System.Drawing.Size(249, 23);
            this.txtAccountTo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 6;
            this.label4.Tag = "0";
            this.label4.Text = "Account To";
            // 
            // cmbType
            // 
            this.cmbType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.TransTypeDataSource, "TransTypeId", true));
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(193, 82);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(180, 25);
            this.cmbType.TabIndex = 5;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TransTypeDataSource
            // 
            this.TransTypeDataSource.DataSource = typeof(AccountSecure.Interface.TransactionTypeDefault);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Transaction Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Previous Balance";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(193, 46);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(272, 23);
            this.txtBalance.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(218, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(21, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1074, 316);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Last 10 Transactions";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransRefNo,
            this.TransDesc,
            this.Amount,
            this.TransDate,
            this.ValueDate,
            this.Narration});
            this.dataGridView1.Location = new System.Drawing.Point(19, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1030, 264);
            this.dataGridView1.TabIndex = 0;
            // 
            // TransRefNo
            // 
            this.TransRefNo.DataPropertyName = "TransRefNo";
            this.TransRefNo.HeaderText = "TransRefNo";
            this.TransRefNo.Name = "TransRefNo";
            this.TransRefNo.Width = 150;
            // 
            // TransDesc
            // 
            this.TransDesc.DataPropertyName = "TransDesc";
            this.TransDesc.HeaderText = "TransDesc";
            this.TransDesc.Name = "TransDesc";
            this.TransDesc.Width = 150;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 120;
            // 
            // TransDate
            // 
            this.TransDate.DataPropertyName = "TransDate";
            this.TransDate.HeaderText = "TransDate";
            this.TransDate.Name = "TransDate";
            // 
            // ValueDate
            // 
            this.ValueDate.DataPropertyName = "ValueDate";
            this.ValueDate.HeaderText = "ValueDate";
            this.ValueDate.Name = "ValueDate";
            this.ValueDate.Width = 120;
            // 
            // Narration
            // 
            this.Narration.DataPropertyName = "Narration";
            this.Narration.HeaderText = "Narration";
            this.Narration.Name = "Narration";
            this.Narration.Width = 350;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(899, 27);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(46, 17);
            this.lblAccount.TabIndex = 3;
            this.lblAccount.Text = "label7";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(829, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "AcctNo:";
            // 
            // FrmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1136, 720);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTransaction";
            this.Text = "Transaction Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTransaction_FormClosing);
            this.Load += new System.EventHandler(this.FrmTransaction_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixFacial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransTypeDataSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccountTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pixFacial;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource TransTypeDataSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narration;
    }
}