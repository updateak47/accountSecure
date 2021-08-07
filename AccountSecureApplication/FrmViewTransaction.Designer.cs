namespace AccountSecure.App
{
    partial class FrmViewTransaction
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
            this.TransRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdRef = new System.Windows.Forms.RadioButton();
            this.rdAcct = new System.Windows.Forms.RadioButton();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
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
            this.TransRefNo,
            this.TransDesc,
            this.Amount,
            this.TransDate,
            this.ValueDate,
            this.Narration});
            this.dataGridView1.Location = new System.Drawing.Point(22, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1373, 651);
            this.dataGridView1.TabIndex = 1;
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
            // rdRef
            // 
            this.rdRef.AutoSize = true;
            this.rdRef.CausesValidation = false;
            this.rdRef.Location = new System.Drawing.Point(648, 29);
            this.rdRef.Name = "rdRef";
            this.rdRef.Size = new System.Drawing.Size(152, 21);
            this.rdRef.TabIndex = 11;
            this.rdRef.Text = "Transaction Ref No";
            this.rdRef.UseVisualStyleBackColor = true;
            // 
            // rdAcct
            // 
            this.rdAcct.AutoSize = true;
            this.rdAcct.CausesValidation = false;
            this.rdAcct.Checked = true;
            this.rdAcct.Location = new System.Drawing.Point(516, 29);
            this.rdAcct.Name = "rdAcct";
            this.rdAcct.Size = new System.Drawing.Size(102, 21);
            this.rdAcct.TabIndex = 10;
            this.rdAcct.TabStop = true;
            this.rdAcct.Text = "Account No";
            this.rdAcct.UseVisualStyleBackColor = true;
            // 
            // txtParam
            // 
            this.txtParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParam.Location = new System.Drawing.Point(154, 28);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(334, 23);
            this.txtParam.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Parameter";
            // 
            // btnSearch
            // 
            this.btnSearch.CausesValidation = false;
            this.btnSearch.Location = new System.Drawing.Point(921, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(166, 26);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(1113, 27);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(104, 26);
            this.btnAll.TabIndex = 12;
            this.btnAll.Text = "Show All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // FrmViewTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 745);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.rdRef);
            this.Controls.Add(this.rdAcct);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "FrmViewTransaction";
            this.Text = "Transaction List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewTransaction_FormClosing);
            this.Load += new System.EventHandler(this.FrmViewTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narration;
        private System.Windows.Forms.RadioButton rdRef;
        private System.Windows.Forms.RadioButton rdAcct;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAll;
    }
}