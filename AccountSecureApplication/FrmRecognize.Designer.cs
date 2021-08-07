namespace AccountSecure.App
{
    partial class FrmRecognize
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
            this.btnStart_fin = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnStop_fin = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picCapturedFace = new System.Windows.Forms.PictureBox();
            this.picSavedFace = new System.Windows.Forms.PictureBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCapturedFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSavedFace)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart_fin
            // 
            this.btnStart_fin.Location = new System.Drawing.Point(39, 440);
            this.btnStart_fin.Name = "btnStart_fin";
            this.btnStart_fin.Size = new System.Drawing.Size(155, 47);
            this.btnStart_fin.TabIndex = 12;
            this.btnStart_fin.Text = "Start Camera";
            this.btnStart_fin.UseVisualStyleBackColor = true;
            this.btnStart_fin.Click += new System.EventHandler(this.btnStart_fin_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnVerify.Location = new System.Drawing.Point(416, 440);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(333, 47);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnStop_fin
            // 
            this.btnStop_fin.Location = new System.Drawing.Point(225, 440);
            this.btnStop_fin.Name = "btnStop_fin";
            this.btnStop_fin.Size = new System.Drawing.Size(150, 47);
            this.btnStop_fin.TabIndex = 4;
            this.btnStop_fin.Text = "Capture";
            this.btnStop_fin.UseVisualStyleBackColor = true;
            this.btnStop_fin.Click += new System.EventHandler(this.btnStop_fin_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picSavedFace);
            this.groupBox3.Controls.Add(this.picCapturedFace);
            this.groupBox3.Controls.Add(this.btnStop_fin);
            this.groupBox3.Controls.Add(this.btnVerify);
            this.groupBox3.Controls.Add(this.btnStart_fin);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(781, 517);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Face Recognition ";
            // 
            // picCapturedFace
            // 
            this.picCapturedFace.Location = new System.Drawing.Point(39, 35);
            this.picCapturedFace.Name = "picCapturedFace";
            this.picCapturedFace.Size = new System.Drawing.Size(336, 350);
            this.picCapturedFace.TabIndex = 13;
            this.picCapturedFace.TabStop = false;
            // 
            // picSavedFace
            // 
            this.picSavedFace.Location = new System.Drawing.Point(416, 35);
            this.picSavedFace.Name = "picSavedFace";
            this.picSavedFace.Size = new System.Drawing.Size(333, 350);
            this.picSavedFace.TabIndex = 14;
            this.picSavedFace.TabStop = false;
            // 
            // FrmRecognize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 551);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "FrmRecognize";
            this.Text = "Verify Customer Biometrics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVerify_FormClosing);
            this.Load += new System.EventHandler(this.FrmRecognize_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCapturedFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSavedFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart_fin;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnStop_fin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox picSavedFace;
        private System.Windows.Forms.PictureBox picCapturedFace;
    }
}