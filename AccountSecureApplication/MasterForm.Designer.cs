namespace AccountSecure.App
{
    partial class MasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Navigation History");
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.NewCustomerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.commandPromptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MSDTCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.appConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cleaningOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewGeneralLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitterPanelRight = new NJFLib.Controls.CollapsibleSplitter();
            this.splitterTreeView = new NJFLib.Controls.CollapsibleSplitter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitterBottom = new NJFLib.Controls.CollapsibleSplitter();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 732);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1371, 26);
            this.statusStrip.TabIndex = 2;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 21);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 20);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.cleaningOrderToolStripMenuItem,
            this.toolStripMenuItem9,
            this.toolStripMenuItem16});
            this.menuStrip1.Location = new System.Drawing.Point(264, 0);
            this.menuStrip1.MdiWindowListItem = this.toolStripMenuItem9;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 28);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "MenuStrip";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageUserMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem2,
            this.toolStripSeparator9,
            this.toolStripMenuItem5,
            this.toolStripSeparator3,
            this.toolStripMenuItem4,
            this.toolStripSeparator4,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 24);
            this.toolStripMenuItem1.Text = "&Menu";
            // 
            // manageUserMenuItem
            // 
            this.manageUserMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.viewUsersToolStripMenuItem});
            this.manageUserMenuItem.Name = "manageUserMenuItem";
            this.manageUserMenuItem.Size = new System.Drawing.Size(219, 26);
            this.manageUserMenuItem.Text = "Manage &Users ";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.addUserToolStripMenuItem.Text = "Add Users";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // viewUsersToolStripMenuItem
            // 
            this.viewUsersToolStripMenuItem.Name = "viewUsersToolStripMenuItem";
            this.viewUsersToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.viewUsersToolStripMenuItem.Text = "View Users";
            this.viewUsersToolStripMenuItem.Click += new System.EventHandler(this.viewUsersToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewCustomerMenuItem,
            this.viewCustomersToolStripMenuItem});
            this.toolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(219, 26);
            this.toolStripMenuItem2.Text = "Manage &Customers";
            // 
            // NewCustomerMenuItem
            // 
            this.NewCustomerMenuItem.Name = "NewCustomerMenuItem";
            this.NewCustomerMenuItem.Size = new System.Drawing.Size(197, 26);
            this.NewCustomerMenuItem.Text = "Add Customer ";
            this.NewCustomerMenuItem.Click += new System.EventHandler(this.NewCustomerMenuItem_Click);
            // 
            // viewCustomersToolStripMenuItem
            // 
            this.viewCustomersToolStripMenuItem.Name = "viewCustomersToolStripMenuItem";
            this.viewCustomersToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.viewCustomersToolStripMenuItem.Text = "View Customers";
            this.viewCustomersToolStripMenuItem.Click += new System.EventHandler(this.viewCustomersToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(216, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandPromptToolStripMenuItem,
            this.MSDTCToolStripMenuItem,
            this.pingServerToolStripMenuItem});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(219, 26);
            this.toolStripMenuItem5.Text = "Diagnostics";
            // 
            // commandPromptToolStripMenuItem
            // 
            this.commandPromptToolStripMenuItem.Name = "commandPromptToolStripMenuItem";
            this.commandPromptToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.commandPromptToolStripMenuItem.Text = "Command Prompt";
            this.commandPromptToolStripMenuItem.Click += new System.EventHandler(this.commandPromptToolStripMenuItem_Click);
            // 
            // MSDTCToolStripMenuItem
            // 
            this.MSDTCToolStripMenuItem.Name = "MSDTCToolStripMenuItem";
            this.MSDTCToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.MSDTCToolStripMenuItem.Text = "MSDTC";
            this.MSDTCToolStripMenuItem.Click += new System.EventHandler(this.MSDTCToolStripMenuItem_Click);
            // 
            // pingServerToolStripMenuItem
            // 
            this.pingServerToolStripMenuItem.Name = "pingServerToolStripMenuItem";
            this.pingServerToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.pingServerToolStripMenuItem.Text = "Ping Server";
            this.pingServerToolStripMenuItem.Click += new System.EventHandler(this.pingServerToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(216, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appConfigToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(219, 26);
            this.toolStripMenuItem4.Text = "Settings";
            // 
            // appConfigToolStripMenuItem
            // 
            this.appConfigToolStripMenuItem.Name = "appConfigToolStripMenuItem";
            this.appConfigToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.appConfigToolStripMenuItem.Text = "Application Configuration";
            this.appConfigToolStripMenuItem.Click += new System.EventHandler(this.appConfigToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(216, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(219, 26);
            this.toolStripMenuItem3.Text = "E&xit";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // cleaningOrderToolStripMenuItem
            // 
            this.cleaningOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProcessToolStripMenuItem,
            this.viewTransactionToolStripMenuItem,
            this.viewGeneralLedgerToolStripMenuItem});
            this.cleaningOrderToolStripMenuItem.Name = "cleaningOrderToolStripMenuItem";
            this.cleaningOrderToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.cleaningOrderToolStripMenuItem.Text = "&Transaction";
            // 
            // ProcessToolStripMenuItem
            // 
            this.ProcessToolStripMenuItem.Name = "ProcessToolStripMenuItem";
            this.ProcessToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.ProcessToolStripMenuItem.Text = "Perform Transaction";
            this.ProcessToolStripMenuItem.Click += new System.EventHandler(this.ProcessToolStripMenuItem_Click);
            // 
            // viewTransactionToolStripMenuItem
            // 
            this.viewTransactionToolStripMenuItem.Name = "viewTransactionToolStripMenuItem";
            this.viewTransactionToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.viewTransactionToolStripMenuItem.Text = "View Transaction";
            this.viewTransactionToolStripMenuItem.Click += new System.EventHandler(this.viewTransactionToolStripMenuItem_Click);
            // 
            // viewGeneralLedgerToolStripMenuItem
            // 
            this.viewGeneralLedgerToolStripMenuItem.Name = "viewGeneralLedgerToolStripMenuItem";
            this.viewGeneralLedgerToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.viewGeneralLedgerToolStripMenuItem.Text = "View General Ledger";
            this.viewGeneralLedgerToolStripMenuItem.Click += new System.EventHandler(this.viewGeneralLedgerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15});
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(84, 24);
            this.toolStripMenuItem9.Text = "&Windows";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(190, 26);
            this.toolStripMenuItem10.Text = "&New Window";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(190, 26);
            this.toolStripMenuItem11.Text = "&Cascade";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(190, 26);
            this.toolStripMenuItem12.Text = "Tile &Vertical";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(190, 26);
            this.toolStripMenuItem13.Text = "Tile &Horizontal";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(190, 26);
            this.toolStripMenuItem14.Text = "C&lose All";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(190, 26);
            this.toolStripMenuItem15.Text = "&Arrange Icons";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator10,
            this.toolStripMenuItem18});
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItem16.Text = "&Help";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(143, 6);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(146, 26);
            this.toolStripMenuItem18.Text = "&About ...";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "object.jpg");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "db_icon2.ico");
            this.imageList2.Images.SetKeyName(12, "db_Table.bmp");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // splitterPanelRight
            // 
            this.splitterPanelRight.AnimationDelay = 20;
            this.splitterPanelRight.AnimationStep = 20;
            this.splitterPanelRight.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.splitterPanelRight.ControlToHide = null;
            this.splitterPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterPanelRight.ExpandParentForm = true;
            this.splitterPanelRight.Location = new System.Drawing.Point(1368, 0);
            this.splitterPanelRight.Margin = new System.Windows.Forms.Padding(4);
            this.splitterPanelRight.Name = "splitterPanelRight";
            this.splitterPanelRight.TabIndex = 42;
            this.splitterPanelRight.TabStop = false;
            this.splitterPanelRight.UseAnimations = false;
            this.splitterPanelRight.VisualStyle = NJFLib.Controls.VisualStyles.DoubleDots;
            // 
            // splitterTreeView
            // 
            this.splitterTreeView.AnimationDelay = 20;
            this.splitterTreeView.AnimationStep = 20;
            this.splitterTreeView.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.splitterTreeView.ControlToHide = this.treeView1;
            this.splitterTreeView.ExpandParentForm = false;
            this.splitterTreeView.Location = new System.Drawing.Point(256, 0);
            this.splitterTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.splitterTreeView.Name = "splitterTreeView";
            this.splitterTreeView.TabIndex = 41;
            this.splitterTreeView.TabStop = false;
            this.splitterTreeView.UseAnimations = false;
            this.splitterTreeView.VisualStyle = NJFLib.Controls.VisualStyles.XP;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ImageIndex = 2;
            this.treeView1.ImageList = this.imageList2;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.Name = "Node0";
            treeNode1.Text = "Navigation History";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 2;
            this.treeView1.Size = new System.Drawing.Size(256, 729);
            this.treeView1.TabIndex = 40;
            // 
            // splitterBottom
            // 
            this.splitterBottom.AnimationDelay = 20;
            this.splitterBottom.AnimationStep = 20;
            this.splitterBottom.BorderStyle3D = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.splitterBottom.ControlToHide = null;
            this.splitterBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterBottom.ExpandParentForm = true;
            this.splitterBottom.Location = new System.Drawing.Point(0, 729);
            this.splitterBottom.Margin = new System.Windows.Forms.Padding(4);
            this.splitterBottom.Name = "splitterBottom";
            this.splitterBottom.TabIndex = 39;
            this.splitterBottom.TabStop = false;
            this.splitterBottom.UseAnimations = true;
            this.splitterBottom.VisualStyle = NJFLib.Controls.VisualStyles.Lines;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 758);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitterPanelRight);
            this.Controls.Add(this.splitterTreeView);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.splitterBottom);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Secure - TransEmulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterForm_FormClosing);
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem NewCustomerMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private NJFLib.Controls.CollapsibleSplitter splitterPanelRight;
        private NJFLib.Controls.CollapsibleSplitter splitterTreeView;
        private System.Windows.Forms.TreeView treeView1;
        private NJFLib.Controls.CollapsibleSplitter splitterBottom;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem viewCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleaningOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem appConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem commandPromptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MSDTCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem pingServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewGeneralLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUserMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem viewTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUsersToolStripMenuItem;
    }
}



