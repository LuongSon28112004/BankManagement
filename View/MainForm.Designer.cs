namespace BankManagement
{
    partial class MainForm
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
            this.panelTitleBarMain = new System.Windows.Forms.Panel();
            this.btnNotifyMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnStaffAvatarMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinimizeMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaximizeMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnCloseMain = new Guna.UI2.WinForms.Guna2Button();
            this.lbStaffName = new System.Windows.Forms.Label();
            this.lbBMS = new System.Windows.Forms.Label();
            this.imgLogoMain = new System.Windows.Forms.PictureBox();
            this.guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(this.components);
            this.panelLeftBarMain = new System.Windows.Forms.Panel();
            this.lbLine = new System.Windows.Forms.Label();
            this.btnSetting = new Guna.UI2.WinForms.Guna2Button();
            this.btnLoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnTransaction = new Guna.UI2.WinForms.Guna2Button();
            this.btnAccount = new Guna.UI2.WinForms.Guna2Button();
            this.btnCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.panelTitleBarMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoMain)).BeginInit();
            this.panelLeftBarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBarMain
            // 
            this.panelTitleBarMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.panelTitleBarMain.Controls.Add(this.btnNotifyMain);
            this.panelTitleBarMain.Controls.Add(this.btnStaffAvatarMain);
            this.panelTitleBarMain.Controls.Add(this.btnMinimizeMain);
            this.panelTitleBarMain.Controls.Add(this.btnMaximizeMain);
            this.panelTitleBarMain.Controls.Add(this.btnCloseMain);
            this.panelTitleBarMain.Controls.Add(this.lbStaffName);
            this.panelTitleBarMain.Controls.Add(this.lbBMS);
            this.panelTitleBarMain.Controls.Add(this.imgLogoMain);
            this.panelTitleBarMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBarMain.ForeColor = System.Drawing.Color.White;
            this.panelTitleBarMain.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBarMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitleBarMain.Name = "panelTitleBarMain";
            this.panelTitleBarMain.Size = new System.Drawing.Size(1200, 47);
            this.panelTitleBarMain.TabIndex = 0;
            this.panelTitleBarMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBarMain_MouseDown);
            // 
            // btnNotifyMain
            // 
            this.btnNotifyMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotifyMain.BorderRadius = 13;
            this.btnNotifyMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNotifyMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNotifyMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNotifyMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNotifyMain.FillColor = System.Drawing.Color.Transparent;
            this.btnNotifyMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNotifyMain.ForeColor = System.Drawing.Color.White;
            this.btnNotifyMain.Image = global::BankManagement.Properties.Resources.bell_icon;
            this.btnNotifyMain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNotifyMain.ImageOffset = new System.Drawing.Point(-7, 0);
            this.btnNotifyMain.ImageSize = new System.Drawing.Size(23, 23);
            this.btnNotifyMain.Location = new System.Drawing.Point(1032, 10);
            this.btnNotifyMain.Name = "btnNotifyMain";
            this.btnNotifyMain.Size = new System.Drawing.Size(29, 29);
            this.btnNotifyMain.TabIndex = 2;
            // 
            // btnStaffAvatarMain
            // 
            this.btnStaffAvatarMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaffAvatarMain.BorderRadius = 22;
            this.btnStaffAvatarMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStaffAvatarMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStaffAvatarMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStaffAvatarMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStaffAvatarMain.FillColor = System.Drawing.Color.Transparent;
            this.btnStaffAvatarMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStaffAvatarMain.ForeColor = System.Drawing.Color.White;
            this.btnStaffAvatarMain.Image = global::BankManagement.Properties.Resources.staff_woman;
            this.btnStaffAvatarMain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStaffAvatarMain.ImageOffset = new System.Drawing.Point(-7, 0);
            this.btnStaffAvatarMain.ImageSize = new System.Drawing.Size(39, 38);
            this.btnStaffAvatarMain.Location = new System.Drawing.Point(849, 1);
            this.btnStaffAvatarMain.Name = "btnStaffAvatarMain";
            this.btnStaffAvatarMain.Size = new System.Drawing.Size(45, 45);
            this.btnStaffAvatarMain.TabIndex = 2;
            this.btnStaffAvatarMain.Click += new System.EventHandler(this.btnStaffAvatarMain_Click);
            // 
            // btnMinimizeMain
            // 
            this.btnMinimizeMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizeMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimizeMain.BorderColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimizeMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimizeMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinimizeMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinimizeMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.btnMinimizeMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinimizeMain.ForeColor = System.Drawing.Color.White;
            this.btnMinimizeMain.Image = global::BankManagement.Properties.Resources.minimize;
            this.btnMinimizeMain.ImageSize = new System.Drawing.Size(14, 3);
            this.btnMinimizeMain.Location = new System.Drawing.Point(1065, 3);
            this.btnMinimizeMain.Name = "btnMinimizeMain";
            this.btnMinimizeMain.Size = new System.Drawing.Size(40, 40);
            this.btnMinimizeMain.TabIndex = 2;
            this.btnMinimizeMain.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximizeMain
            // 
            this.btnMaximizeMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizeMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMaximizeMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMaximizeMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaximizeMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMaximizeMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.btnMaximizeMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMaximizeMain.ForeColor = System.Drawing.Color.White;
            this.btnMaximizeMain.Image = global::BankManagement.Properties.Resources.maximize;
            this.btnMaximizeMain.ImageSize = new System.Drawing.Size(12, 12);
            this.btnMaximizeMain.Location = new System.Drawing.Point(1111, 3);
            this.btnMaximizeMain.Name = "btnMaximizeMain";
            this.btnMaximizeMain.Size = new System.Drawing.Size(40, 40);
            this.btnMaximizeMain.TabIndex = 2;
            this.btnMaximizeMain.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnCloseMain
            // 
            this.btnCloseMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCloseMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCloseMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.btnCloseMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCloseMain.ForeColor = System.Drawing.Color.White;
            this.btnCloseMain.Image = global::BankManagement.Properties.Resources.close;
            this.btnCloseMain.ImageSize = new System.Drawing.Size(12, 12);
            this.btnCloseMain.Location = new System.Drawing.Point(1157, 3);
            this.btnCloseMain.Name = "btnCloseMain";
            this.btnCloseMain.Size = new System.Drawing.Size(40, 40);
            this.btnCloseMain.TabIndex = 2;
            this.btnCloseMain.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbStaffName
            // 
            this.lbStaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStaffName.AutoSize = true;
            this.lbStaffName.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStaffName.ForeColor = System.Drawing.Color.White;
            this.lbStaffName.Location = new System.Drawing.Point(896, 16);
            this.lbStaffName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStaffName.Name = "lbStaffName";
            this.lbStaffName.Size = new System.Drawing.Size(105, 17);
            this.lbStaffName.TabIndex = 2;
            this.lbStaffName.Text = "Nguyen Anh Vy";
            // 
            // lbBMS
            // 
            this.lbBMS.AutoSize = true;
            this.lbBMS.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBMS.ForeColor = System.Drawing.Color.White;
            this.lbBMS.Location = new System.Drawing.Point(53, 14);
            this.lbBMS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBMS.Name = "lbBMS";
            this.lbBMS.Size = new System.Drawing.Size(201, 19);
            this.lbBMS.TabIndex = 1;
            this.lbBMS.Text = "Bank Management System";
            // 
            // imgLogoMain
            // 
            this.imgLogoMain.Image = global::BankManagement.Properties.Resources.logo;
            this.imgLogoMain.Location = new System.Drawing.Point(13, 6);
            this.imgLogoMain.Margin = new System.Windows.Forms.Padding(2);
            this.imgLogoMain.Name = "imgLogoMain";
            this.imgLogoMain.Size = new System.Drawing.Size(38, 41);
            this.imgLogoMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogoMain.TabIndex = 0;
            this.imgLogoMain.TabStop = false;
            // 
            // guna2ResizeForm1
            // 
            this.guna2ResizeForm1.TargetForm = this;
            // 
            // panelLeftBarMain
            // 
            this.panelLeftBarMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.panelLeftBarMain.Controls.Add(this.lbLine);
            this.panelLeftBarMain.Controls.Add(this.btnSetting);
            this.panelLeftBarMain.Controls.Add(this.btnLoan);
            this.panelLeftBarMain.Controls.Add(this.btnTransaction);
            this.panelLeftBarMain.Controls.Add(this.btnAccount);
            this.panelLeftBarMain.Controls.Add(this.btnCustomer);
            this.panelLeftBarMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftBarMain.Location = new System.Drawing.Point(0, 47);
            this.panelLeftBarMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeftBarMain.Name = "panelLeftBarMain";
            this.panelLeftBarMain.Size = new System.Drawing.Size(155, 653);
            this.panelLeftBarMain.TabIndex = 1;
            // 
            // lbLine
            // 
            this.lbLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLine.Font = new System.Drawing.Font("Bodoni MT Condensed", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLine.ForeColor = System.Drawing.Color.Gray;
            this.lbLine.Location = new System.Drawing.Point(31, 553);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(100, 13);
            this.lbLine.TabIndex = 2;
            this.lbLine.Text = "___________________________";
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSetting.BorderRadius = 18;
            this.btnSetting.CustomBorderColor = System.Drawing.Color.Gainsboro;
            this.btnSetting.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSetting.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSetting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSetting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSetting.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.btnSetting.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Image = global::BankManagement.Properties.Resources.setting;
            this.btnSetting.ImageSize = new System.Drawing.Size(29, 29);
            this.btnSetting.Location = new System.Drawing.Point(22, 579);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(110, 50);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "Setting";
            this.btnSetting.TextOffset = new System.Drawing.Point(3, -1);
            this.btnSetting.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnLoan
            // 
            this.btnLoan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoan.BorderRadius = 15;
            this.btnLoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnLoan.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoan.ForeColor = System.Drawing.Color.White;
            this.btnLoan.Image = global::BankManagement.Properties.Resources.loan;
            this.btnLoan.ImageOffset = new System.Drawing.Point(-2, -1);
            this.btnLoan.ImageSize = new System.Drawing.Size(33, 33);
            this.btnLoan.Location = new System.Drawing.Point(9, 250);
            this.btnLoan.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(135, 48);
            this.btnLoan.TabIndex = 0;
            this.btnLoan.Text = "Loan";
            this.btnLoan.TextOffset = new System.Drawing.Point(0, -2);
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTransaction.BorderRadius = 15;
            this.btnTransaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTransaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTransaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTransaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTransaction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnTransaction.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.Color.White;
            this.btnTransaction.Image = global::BankManagement.Properties.Resources.transaction;
            this.btnTransaction.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnTransaction.ImageSize = new System.Drawing.Size(30, 30);
            this.btnTransaction.Location = new System.Drawing.Point(9, 177);
            this.btnTransaction.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(135, 48);
            this.btnTransaction.TabIndex = 0;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.TextOffset = new System.Drawing.Point(0, -2);
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAccount.BorderRadius = 15;
            this.btnAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnAccount.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.White;
            this.btnAccount.Image = global::BankManagement.Properties.Resources.account1;
            this.btnAccount.ImageOffset = new System.Drawing.Point(-2, 0);
            this.btnAccount.ImageSize = new System.Drawing.Size(32, 32);
            this.btnAccount.Location = new System.Drawing.Point(9, 103);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(135, 48);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "Account";
            this.btnAccount.TextOffset = new System.Drawing.Point(0, -2);
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCustomer.BorderRadius = 15;
            this.btnCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnCustomer.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Image = global::BankManagement.Properties.Resources.customer;
            this.btnCustomer.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCustomer.Location = new System.Drawing.Point(9, 29);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(135, 48);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.TextOffset = new System.Drawing.Point(0, -2);
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelLeftBarMain);
            this.Controls.Add(this.panelTitleBarMain);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.LocationChanged += new System.EventHandler(this.Main_LocationChanged);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.panelTitleBarMain.ResumeLayout(false);
            this.panelTitleBarMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoMain)).EndInit();
            this.panelLeftBarMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBarMain;
        private System.Windows.Forms.PictureBox imgLogoMain;
        private System.Windows.Forms.Label lbBMS;
        private Guna.UI2.WinForms.Guna2ResizeForm guna2ResizeForm1;
        private System.Windows.Forms.Panel panelLeftBarMain;
        private System.Windows.Forms.Label lbStaffName;
        private Guna.UI2.WinForms.Guna2Button btnCustomer;
        private Guna.UI2.WinForms.Guna2Button btnAccount;
        private Guna.UI2.WinForms.Guna2Button btnTransaction;
        private Guna.UI2.WinForms.Guna2Button btnLoan;
        private Guna.UI2.WinForms.Guna2Button btnSetting;
		private Guna.UI2.WinForms.Guna2Button btnCloseMain;
		private Guna.UI2.WinForms.Guna2Button btnMaximizeMain;
		private Guna.UI2.WinForms.Guna2Button btnMinimizeMain;
        private Guna.UI2.WinForms.Guna2Button btnStaffAvatarMain;
        private Guna.UI2.WinForms.Guna2Button btnNotifyMain;
		private System.Windows.Forms.Label lbLine;
		private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
	}
}