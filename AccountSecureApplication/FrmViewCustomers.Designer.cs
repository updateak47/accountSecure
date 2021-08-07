namespace AccountSecure.App
{
    partial class FrmViewCustomers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CustI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcctNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcctTypeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dateofbirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Photo = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustI,
            this.AcctNo,
            this.FullName,
            this.AcctTypeDesc,
            this.Sex,
            this.Dateofbirth,
            this.PhoneNo,
            this.Email,
            this.HomeAddress,
            this.Photo});
            this.dataGridView1.Location = new System.Drawing.Point(15, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 70;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(1489, 653);
            this.dataGridView1.TabIndex = 0;
            // 
            // CustI
            // 
            this.CustI.DataPropertyName = "CustId";
            this.CustI.HeaderText = "CustId";
            this.CustI.Name = "CustI";
            this.CustI.Width = 40;
            // 
            // AcctNo
            // 
            this.AcctNo.DataPropertyName = "AcctNo";
            this.AcctNo.HeaderText = "AcctNo";
            this.AcctNo.Name = "AcctNo";
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.Width = 180;
            // 
            // AcctTypeDesc
            // 
            this.AcctTypeDesc.DataPropertyName = "AccType";
            this.AcctTypeDesc.HeaderText = "AcctType";
            this.AcctTypeDesc.Name = "AcctTypeDesc";
            this.AcctTypeDesc.Width = 70;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            this.Sex.HeaderText = "Sex";
            this.Sex.Name = "Sex";
            this.Sex.Width = 40;
            // 
            // Dateofbirth
            // 
            this.Dateofbirth.DataPropertyName = "Dateofbirth";
            this.Dateofbirth.HeaderText = "Dateofbirth";
            this.Dateofbirth.Name = "Dateofbirth";
            // 
            // PhoneNo
            // 
            this.PhoneNo.DataPropertyName = "PhoneNo";
            this.PhoneNo.HeaderText = "PhoneNo";
            this.PhoneNo.Name = "PhoneNo";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // HomeAddress
            // 
            this.HomeAddress.DataPropertyName = "HomeAddress";
            this.HomeAddress.HeaderText = "HomeAddress";
            this.HomeAddress.Name = "HomeAddress";
            this.HomeAddress.Width = 250;
            // 
            // Photo
            // 
            this.Photo.DataPropertyName = "FacialImage";
            this.Photo.HeaderText = "Photo";
            this.Photo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Photo.Name = "Photo";
            this.Photo.Width = 80;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(17, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(179, 40);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(233, 12);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(203, 40);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "&All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(1294, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(210, 40);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FrmViewCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 737);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmViewCustomers";
            this.Text = "Customer List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewCustomers_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustI;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcctNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcctTypeDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dateofbirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeAddress;
        private System.Windows.Forms.DataGridViewImageColumn Photo;
    }
}