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
            this.lbStaffName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbBMS = new System.Windows.Forms.Label();
            this.guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(this.components);
            this.panelLeftBarMain = new System.Windows.Forms.Panel();
            this.lbFeedbackMain = new System.Windows.Forms.Label();
            this.lbClientServicesMain = new System.Windows.Forms.Label();
            this.btnCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.btnFeedbackMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnHelpMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnLoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnAccount = new Guna.UI2.WinForms.Guna2Button();
            this.btnTransaction = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettingMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnStaffAvatarMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnNotifyMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinimizeMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaximizeMain = new Guna.UI2.WinForms.Guna2Button();
            this.btnCloseMain = new Guna.UI2.WinForms.Guna2Button();
            this.imgLogoMain = new System.Windows.Forms.PictureBox();
            this.panelTitleBarMain.SuspendLayout();
            this.panelLeftBarMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitleBarMain
            // 
            this.panelTitleBarMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.panelTitleBarMain.Controls.Add(this.btnSettingMain);
            this.panelTitleBarMain.Controls.Add(this.btnStaffAvatarMain);
            this.panelTitleBarMain.Controls.Add(this.btnNotifyMain);
            this.panelTitleBarMain.Controls.Add(this.lbStaffName);
            this.panelTitleBarMain.Controls.Add(this.btnMinimizeMain);
            this.panelTitleBarMain.Controls.Add(this.btnMaximizeMain);
            this.panelTitleBarMain.Controls.Add(this.btnCloseMain);
            this.panelTitleBarMain.Controls.Add(this.label1);
            this.panelTitleBarMain.Controls.Add(this.lbBMS);
            this.panelTitleBarMain.Controls.Add(this.imgLogoMain);
            this.panelTitleBarMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBarMain.ForeColor = System.Drawing.Color.White;
            this.panelTitleBarMain.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBarMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitleBarMain.Name = "panelTitleBarMain";
            this.panelTitleBarMain.Size = new System.Drawing.Size(1200, 60);
            this.panelTitleBarMain.TabIndex = 0;
            this.panelTitleBarMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBarMain_MouseDown);
            // 
            // lbStaffName
            // 
            this.lbStaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStaffName.AutoSize = true;
            this.lbStaffName.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStaffName.ForeColor = System.Drawing.Color.White;
            this.lbStaffName.Location = new System.Drawing.Point(958, 20);
            this.lbStaffName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStaffName.Name = "lbStaffName";
            this.lbStaffName.Size = new System.Drawing.Size(88, 14);
            this.lbStaffName.TabIndex = 2;
            this.lbStaffName.Text = "Nguyen Anh Vy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Utcbank";
            // 
            // lbBMS
            // 
            this.lbBMS.AutoSize = true;
            this.lbBMS.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBMS.ForeColor = System.Drawing.Color.White;
            this.lbBMS.Location = new System.Drawing.Point(56, 26);
            this.lbBMS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBMS.Name = "lbBMS";
            this.lbBMS.Size = new System.Drawing.Size(90, 22);
            this.lbBMS.TabIndex = 1;
            this.lbBMS.Text = "WorkPlace";
            // 
            // guna2ResizeForm1
            // 
            this.guna2ResizeForm1.TargetForm = this;
            // 
            // panelLeftBarMain
            // 
            this.panelLeftBarMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.panelLeftBarMain.Controls.Add(this.lbFeedbackMain);
            this.panelLeftBarMain.Controls.Add(this.btnCustomer);
            this.panelLeftBarMain.Controls.Add(this.btnFeedbackMain);
            this.panelLeftBarMain.Controls.Add(this.btnHelpMain);
            this.panelLeftBarMain.Controls.Add(this.btnLoan);
            this.panelLeftBarMain.Controls.Add(this.btnAccount);
            this.panelLeftBarMain.Controls.Add(this.btnTransaction);
            this.panelLeftBarMain.Controls.Add(this.lbClientServicesMain);
            this.panelLeftBarMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftBarMain.Location = new System.Drawing.Point(0, 60);
            this.panelLeftBarMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeftBarMain.Name = "panelLeftBarMain";
            this.panelLeftBarMain.Size = new System.Drawing.Size(200, 640);
            this.panelLeftBarMain.TabIndex = 1;
            // 
            // lbFeedbackMain
            // 
            this.lbFeedbackMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFeedbackMain.AutoSize = true;
            this.lbFeedbackMain.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFeedbackMain.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbFeedbackMain.Location = new System.Drawing.Point(58, 597);
            this.lbFeedbackMain.Name = "lbFeedbackMain";
            this.lbFeedbackMain.Size = new System.Drawing.Size(62, 16);
            this.lbFeedbackMain.TabIndex = 2;
            this.lbFeedbackMain.Text = "Feedback";
            // 
            // lbClientServicesMain
            // 
            this.lbClientServicesMain.AutoSize = true;
            this.lbClientServicesMain.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientServicesMain.ForeColor = System.Drawing.Color.White;
            this.lbClientServicesMain.Location = new System.Drawing.Point(10, 15);
            this.lbClientServicesMain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbClientServicesMain.Name = "lbClientServicesMain";
            this.lbClientServicesMain.Size = new System.Drawing.Size(139, 23);
            this.lbClientServicesMain.TabIndex = 1;
            this.lbClientServicesMain.Text = "Client Services";
            // 
            // btnCustomer
            // 
            this.btnCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCustomer.BorderRadius = 7;
            this.btnCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnCustomer.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCustomer.Image = global::BankManagement.Properties.Resources.customer;
            this.btnCustomer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.ImageOffset = new System.Drawing.Point(0, 2);
            this.btnCustomer.ImageSize = new System.Drawing.Size(25, 25);
            this.btnCustomer.Location = new System.Drawing.Point(10, 62);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(180, 45);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.TextOffset = new System.Drawing.Point(0, -1);
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnFeedbackMain
            // 
            this.btnFeedbackMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFeedbackMain.BorderRadius = 8;
            this.btnFeedbackMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFeedbackMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFeedbackMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFeedbackMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFeedbackMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnFeedbackMain.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedbackMain.ForeColor = System.Drawing.Color.White;
            this.btnFeedbackMain.Image = global::BankManagement.Properties.Resources.img_btn_feedback;
            this.btnFeedbackMain.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnFeedbackMain.ImageSize = new System.Drawing.Size(27, 27);
            this.btnFeedbackMain.Location = new System.Drawing.Point(15, 586);
            this.btnFeedbackMain.Name = "btnFeedbackMain";
            this.btnFeedbackMain.Size = new System.Drawing.Size(41, 39);
            this.btnFeedbackMain.TabIndex = 2;
            // 
            // btnHelpMain
            // 
            this.btnHelpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelpMain.BorderRadius = 7;
            this.btnHelpMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHelpMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHelpMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHelpMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHelpMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(37)))));
            this.btnHelpMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHelpMain.ForeColor = System.Drawing.Color.White;
            this.btnHelpMain.Image = global::BankManagement.Properties.Resources.img_help1;
            this.btnHelpMain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHelpMain.ImageOffset = new System.Drawing.Point(-5, 0);
            this.btnHelpMain.Location = new System.Drawing.Point(157, 13);
            this.btnHelpMain.Name = "btnHelpMain";
            this.btnHelpMain.Size = new System.Drawing.Size(30, 30);
            this.btnHelpMain.TabIndex = 2;
            // 
            // btnLoan
            // 
            this.btnLoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoan.BorderRadius = 7;
            this.btnLoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnLoan.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoan.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLoan.Image = global::BankManagement.Properties.Resources.loan;
            this.btnLoan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLoan.ImageOffset = new System.Drawing.Point(3, 0);
            this.btnLoan.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLoan.Location = new System.Drawing.Point(10, 209);
            this.btnLoan.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLoan.Size = new System.Drawing.Size(180, 45);
            this.btnLoan.TabIndex = 0;
            this.btnLoan.Text = "Loan";
            this.btnLoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLoan.TextOffset = new System.Drawing.Point(5, -1);
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAccount.BorderRadius = 7;
            this.btnAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnAccount.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAccount.Image = global::BankManagement.Properties.Resources.account1;
            this.btnAccount.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAccount.ImageSize = new System.Drawing.Size(25, 25);
            this.btnAccount.Location = new System.Drawing.Point(10, 111);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(180, 45);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "Account";
            this.btnAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAccount.TextOffset = new System.Drawing.Point(2, -1);
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTransaction.BorderRadius = 7;
            this.btnTransaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTransaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTransaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTransaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTransaction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnTransaction.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTransaction.Image = global::BankManagement.Properties.Resources.transaction;
            this.btnTransaction.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTransaction.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnTransaction.ImageSize = new System.Drawing.Size(25, 25);
            this.btnTransaction.Location = new System.Drawing.Point(10, 160);
            this.btnTransaction.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(180, 45);
            this.btnTransaction.TabIndex = 0;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTransaction.TextOffset = new System.Drawing.Point(4, -1);
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnSettingMain
            // 
            this.btnSettingMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingMain.BackColor = System.Drawing.Color.Transparent;
            this.btnSettingMain.BorderRadius = 10;
            this.btnSettingMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettingMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettingMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettingMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettingMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnSettingMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettingMain.ForeColor = System.Drawing.Color.White;
            this.btnSettingMain.Image = global::BankManagement.Properties.Resources.setting;
            this.btnSettingMain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSettingMain.ImageOffset = new System.Drawing.Point(-4, 0);
            this.btnSettingMain.Location = new System.Drawing.Point(879, 11);
            this.btnSettingMain.Name = "btnSettingMain";
            this.btnSettingMain.Size = new System.Drawing.Size(32, 32);
            this.btnSettingMain.TabIndex = 2;
            // 
            // btnStaffAvatarMain
            // 
            this.btnStaffAvatarMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaffAvatarMain.BorderRadius = 10;
            this.btnStaffAvatarMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStaffAvatarMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStaffAvatarMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStaffAvatarMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStaffAvatarMain.FillColor = System.Drawing.Color.Transparent;
            this.btnStaffAvatarMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStaffAvatarMain.ForeColor = System.Drawing.Color.White;
            this.btnStaffAvatarMain.Image = global::BankManagement.Properties.Resources.staff_woman;
            this.btnStaffAvatarMain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStaffAvatarMain.ImageOffset = new System.Drawing.Point(-9, 0);
            this.btnStaffAvatarMain.ImageSize = new System.Drawing.Size(30, 30);
            this.btnStaffAvatarMain.Location = new System.Drawing.Point(922, 11);
            this.btnStaffAvatarMain.Name = "btnStaffAvatarMain";
            this.btnStaffAvatarMain.Size = new System.Drawing.Size(32, 32);
            this.btnStaffAvatarMain.TabIndex = 2;
            this.btnStaffAvatarMain.Click += new System.EventHandler(this.btnStaffAvatarMain_Click);
            // 
            // btnNotifyMain
            // 
            this.btnNotifyMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotifyMain.BackColor = System.Drawing.Color.Transparent;
            this.btnNotifyMain.BorderRadius = 10;
            this.btnNotifyMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNotifyMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNotifyMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNotifyMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNotifyMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNotifyMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNotifyMain.ForeColor = System.Drawing.Color.White;
            this.btnNotifyMain.Image = global::BankManagement.Properties.Resources.notification_bell;
            this.btnNotifyMain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNotifyMain.ImageOffset = new System.Drawing.Point(-4, 0);
            this.btnNotifyMain.Location = new System.Drawing.Point(836, 11);
            this.btnNotifyMain.Name = "btnNotifyMain";
            this.btnNotifyMain.Size = new System.Drawing.Size(32, 32);
            this.btnNotifyMain.TabIndex = 2;
            this.btnNotifyMain.Click += new System.EventHandler(this.btnNotifyMain_Click);
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
            this.btnMinimizeMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnMinimizeMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinimizeMain.ForeColor = System.Drawing.Color.White;
            this.btnMinimizeMain.Image = global::BankManagement.Properties.Resources.minimize;
            this.btnMinimizeMain.ImageSize = new System.Drawing.Size(12, 2);
            this.btnMinimizeMain.Location = new System.Drawing.Point(1075, 10);
            this.btnMinimizeMain.Name = "btnMinimizeMain";
            this.btnMinimizeMain.Size = new System.Drawing.Size(35, 35);
            this.btnMinimizeMain.TabIndex = 2;
            this.btnMinimizeMain.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximizeMain
            // 
            this.btnMaximizeMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizeMain.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeMain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMaximizeMain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMaximizeMain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaximizeMain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMaximizeMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnMaximizeMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMaximizeMain.ForeColor = System.Drawing.Color.White;
            this.btnMaximizeMain.Image = global::BankManagement.Properties.Resources.img_maximize;
            this.btnMaximizeMain.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMaximizeMain.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnMaximizeMain.ImageSize = new System.Drawing.Size(13, 10);
            this.btnMaximizeMain.Location = new System.Drawing.Point(1116, 10);
            this.btnMaximizeMain.Name = "btnMaximizeMain";
            this.btnMaximizeMain.Size = new System.Drawing.Size(35, 35);
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
            this.btnCloseMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnCloseMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCloseMain.ForeColor = System.Drawing.Color.White;
            this.btnCloseMain.Image = global::BankManagement.Properties.Resources.letter_x;
            this.btnCloseMain.ImageSize = new System.Drawing.Size(11, 11);
            this.btnCloseMain.Location = new System.Drawing.Point(1157, 10);
            this.btnCloseMain.Name = "btnCloseMain";
            this.btnCloseMain.Size = new System.Drawing.Size(35, 35);
            this.btnCloseMain.TabIndex = 2;
            this.btnCloseMain.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imgLogoMain
            // 
            this.imgLogoMain.Image = global::BankManagement.Properties.Resources.logo;
            this.imgLogoMain.Location = new System.Drawing.Point(13, 9);
            this.imgLogoMain.Margin = new System.Windows.Forms.Padding(2);
            this.imgLogoMain.Name = "imgLogoMain";
            this.imgLogoMain.Size = new System.Drawing.Size(40, 40);
            this.imgLogoMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogoMain.TabIndex = 0;
            this.imgLogoMain.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelLeftBarMain);
            this.Controls.Add(this.panelTitleBarMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.LocationChanged += new System.EventHandler(this.Main_LocationChanged);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.panelTitleBarMain.ResumeLayout(false);
            this.panelTitleBarMain.PerformLayout();
            this.panelLeftBarMain.ResumeLayout(false);
            this.panelLeftBarMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoMain)).EndInit();
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
		private Guna.UI2.WinForms.Guna2Button btnCloseMain;
		private Guna.UI2.WinForms.Guna2Button btnMaximizeMain;
		private Guna.UI2.WinForms.Guna2Button btnMinimizeMain;
        private Guna.UI2.WinForms.Guna2Button btnStaffAvatarMain;
        private Guna.UI2.WinForms.Guna2Button btnNotifyMain;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnSettingMain;
        private System.Windows.Forms.Label lbClientServicesMain;
        private Guna.UI2.WinForms.Guna2Button btnHelpMain;
        private Guna.UI2.WinForms.Guna2Button btnFeedbackMain;
        private System.Windows.Forms.Label lbFeedbackMain;
    }
}