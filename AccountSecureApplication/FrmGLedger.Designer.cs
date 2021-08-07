namespace AccountSecure.App
{
    partial class FrmGLedger
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PostRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcctNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.rdAcct = new System.Windows.Forms.RadioButton();
            this.rdRef = new System.Windows.Forms.RadioButton();
            this.btnAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PostRef,
            this.Credit,
            this.Debit,
            this.Balance,
            this.AcctNo,
            this.TransDate,
            this.ValueDate,
            this.PostDate});
            this.dataGridView1.Location = new System.Drawing.Point(22, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1411, 651);
            this.dataGridView1.TabIndex = 1;
            // 
            // PostRef
            // 
            this.PostRef.DataPropertyName = "PostRef";
            this.PostRef.HeaderText = "PostRefNo";
            this.PostRef.Name = "PostRef";
            this.PostRef.Width = 200;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.Width = 120;
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "Debit";
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            this.Debit.Width = 120;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.Width = 120;
            // 
            // AcctNo
            // 
            this.AcctNo.DataPropertyName = "AcctNo";
            this.AcctNo.HeaderText = "AcctNo";
            this.AcctNo.Name = "AcctNo";
            this.AcctNo.Width = 120;
            // 
            // TransDate
            // 
            this.TransDate.DataPropertyName = "TransDate";
            this.TransDate.HeaderText = "TransDate";
            this.TransDate.Name = "TransDate";
            this.TransDate.Width = 120;
            // 
            // ValueDate
            // 
            this.ValueDate.DataPropertyName = "ValueDate";
            this.ValueDate.HeaderText = "ValueDate";
            this.ValueDate.Name = "ValueDate";
            this.ValueDate.Width = 120;
            // 
            // PostDate
            // 
            this.PostDate.DataPropertyName = "PostDate";
            this.PostDate.HeaderText = "PostDate";
            this.PostDate.Name = "PostDate";
            this.PostDate.Width = 120;
            // 
            // btnSearch
            // 
            this.btnSearch.CausesValidation = false;
            this.btnSearch.Location = new System.Drawing.Point(848, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(166, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parameter";
            // 
            // txtParam
            // 
            this.txtParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParam.Location = new System.Drawing.Point(184, 34);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(334, 23);
            this.txtParam.TabIndex = 4;
            // 
            // rdAcct
            // 
            this.rdAcct.AutoSize = true;
            this.rdAcct.CausesValidation = false;
            this.rdAcct.Checked = true;
            this.rdAcct.Location = new System.Drawing.Point(546, 35);
            this.rdAcct.Name = "rdAcct";
            this.rdAcct.Size = new System.Drawing.Size(102, 21);
            this.rdAcct.TabIndex = 5;
            this.rdAcct.TabStop = true;
            this.rdAcct.Text = "Account No";
            this.rdAcct.UseVisualStyleBackColor = true;
            // 
            // rdRef
            // 
            this.rdRef.AutoSize = true;
            this.rdRef.CausesValidation = false;
            this.rdRef.Location = new System.Drawing.Point(678, 35);
            this.rdRef.Name = "rdRef";
            this.rdRef.Size = new System.Drawing.Size(152, 21);
            this.rdRef.TabIndex = 6;
            this.rdRef.Text = "Transaction Ref No";
            this.rdRef.UseVisualStyleBackColor = true;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(1046, 32);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(158, 26);
            this.btnAll.TabIndex = 7;
            this.btnAll.Text = "Show All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // FrmGLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 745);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.rdRef);
            this.Controls.Add(this.rdAcct);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "FrmGLedger";
            this.Text = "General Ledger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGLedger_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.RadioButton rdAcct;
        private System.Windows.Forms.RadioButton rdRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcctNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostDate;
        private System.Windows.Forms.Button btnAll;
    }
}