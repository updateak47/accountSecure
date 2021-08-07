namespace AccountSecure.App
{
    partial class FrmConfig
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFill = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmboxMode = new System.Windows.Forms.ComboBox();
            this.cboPreview = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(382, 297);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtServerIP);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cmbOption);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmbFill);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmboxMode);
            this.tabPage1.Controls.Add(this.cboPreview);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(437, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbOption
            // 
            this.cmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Items.AddRange(new object[] {
            "MSDTC",
            "Normal"});
            this.cmbOption.Location = new System.Drawing.Point(176, 27);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(121, 21);
            this.cmbOption.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Process Option:";
            // 
            // cmbFill
            // 
            this.cmbFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFill.FormattingEnabled = true;
            this.cmbFill.Items.AddRange(new object[] {
            "true",
            "false"});
            this.cmbFill.Location = new System.Drawing.Point(175, 150);
            this.cmbFill.Name = "cmbFill";
            this.cmbFill.Size = new System.Drawing.Size(121, 21);
            this.cmbFill.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Paint Print Out:";
            // 
            // cmboxMode
            // 
            this.cmboxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxMode.FormattingEnabled = true;
            this.cmboxMode.Items.AddRange(new object[] {
            "Live1",
            "Live2"});
            this.cmboxMode.Location = new System.Drawing.Point(175, 68);
            this.cmboxMode.Name = "cmboxMode";
            this.cmboxMode.Size = new System.Drawing.Size(121, 21);
            this.cmboxMode.TabIndex = 17;
            // 
            // cboPreview
            // 
            this.cboPreview.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreview.FormattingEnabled = true;
            this.cboPreview.Items.AddRange(new object[] {
            "true",
            "false"});
            this.cboPreview.Location = new System.Drawing.Point(175, 109);
            this.cboPreview.Name = "cboPreview";
            this.cboPreview.Size = new System.Drawing.Size(121, 21);
            this.cboPreview.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enable Print Preview:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(445, 255);
            this.tabControl1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Server IP:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(175, 190);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(154, 20);
            this.txtServerIP.TabIndex = 25;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 345);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmConfig";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cboPreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ComboBox cmboxMode;
        private System.Windows.Forms.ComboBox cmbFill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label5;
    }
}

