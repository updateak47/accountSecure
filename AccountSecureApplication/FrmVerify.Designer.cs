namespace AccountSecure.App
{
    partial class FrmVerify
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pixFinger = new System.Windows.Forms.PictureBox();
            this.btnStop_fin = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnStart_fin = new System.Windows.Forms.Button();
            this.lblStarted = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixFinger)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pixFinger);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(396, 375);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FingerPrint Capture";
            // 
            // pixFinger
            // 
            this.pixFinger.Location = new System.Drawing.Point(59, 60);
            this.pixFinger.Name = "pixFinger";
            this.pixFinger.Size = new System.Drawing.Size(273, 259);
            this.pixFinger.TabIndex = 2;
            this.pixFinger.TabStop = false;
            // 
            // btnStop_fin
            // 
            this.btnStop_fin.Location = new System.Drawing.Point(218, 433);
            this.btnStop_fin.Name = "btnStop_fin";
            this.btnStop_fin.Size = new System.Drawing.Size(190, 54);
            this.btnStop_fin.TabIndex = 4;
            this.btnStop_fin.Text = "Stop";
            this.btnStop_fin.UseVisualStyleBackColor = true;
            this.btnStop_fin.Click += new System.EventHandler(this.btnStop_fin_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnVerify.Location = new System.Drawing.Point(12, 504);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(396, 59);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnStart_fin
            // 
            this.btnStart_fin.Location = new System.Drawing.Point(12, 433);
            this.btnStart_fin.Name = "btnStart_fin";
            this.btnStart_fin.Size = new System.Drawing.Size(181, 54);
            this.btnStart_fin.TabIndex = 12;
            this.btnStart_fin.Text = "Start Scanner";
            this.btnStart_fin.UseVisualStyleBackColor = true;
            this.btnStart_fin.Click += new System.EventHandler(this.btnStart_fin_Click);
            // 
            // lblStarted
            // 
            this.lblStarted.AutoSize = true;
            this.lblStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStarted.ForeColor = System.Drawing.Color.Green;
            this.lblStarted.Location = new System.Drawing.Point(121, 13);
            this.lblStarted.Name = "lblStarted";
            this.lblStarted.Size = new System.Drawing.Size(0, 18);
            this.lblStarted.TabIndex = 13;
            // 
            // FrmVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(431, 575);
            this.Controls.Add(this.lblStarted);
            this.Controls.Add(this.btnStop_fin);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnStart_fin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "FrmVerify";
            this.Text = "Verify Customer Biometrics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVerify_FormClosing);
            this.Load += new System.EventHandler(this.FrmVerify_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pixFinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStop_fin;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnStart_fin;
        private System.Windows.Forms.PictureBox pixFinger;
        private System.Windows.Forms.Label lblStarted;
    }
}