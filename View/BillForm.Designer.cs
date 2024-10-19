namespace BankManagement.View
{
    partial class BillForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillForm));
            this.panelTitleBarBillForm = new System.Windows.Forms.Panel();
            this.btnCloseBillForm = new Guna.UI2.WinForms.Guna2Button();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lbUtcbankBillForm = new System.Windows.Forms.Label();
            this.txtGiaoDichThanhCongBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbNganHangBillForm = new System.Windows.Forms.Label();
            this.lbTuTaiKhoanBillForm = new System.Windows.Forms.Label();
            this.lbSoTienBillForm = new System.Windows.Forms.Label();
            this.lbPhiGiaoDichBillForm = new System.Windows.Forms.Label();
            this.lbNoiDungBillForm = new System.Windows.Forms.Label();
            this.lbDenTaiKhoanBillForm = new System.Windows.Forms.Label();
            this.txtAccountNumberSendBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCustomerNameSendBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMienPhiBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtContentBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAmountBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAccountNumberReceiveBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCustomerNameReceiveBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTimeBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTransactionCodeBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnExportPdfBillForm = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogoBillForm = new Guna.UI2.WinForms.Guna2Button();
            this.imgBackGroundBillForm = new System.Windows.Forms.PictureBox();
            this.lbExportPDFBillForm = new System.Windows.Forms.Label();
            this.txtNganHangBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDauTuBillForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelTitleBarBillForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackGroundBillForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitleBarBillForm
            // 
            this.panelTitleBarBillForm.Controls.Add(this.btnCloseBillForm);
            this.panelTitleBarBillForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBarBillForm.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBarBillForm.Name = "panelTitleBarBillForm";
            this.panelTitleBarBillForm.Size = new System.Drawing.Size(470, 43);
            this.panelTitleBarBillForm.TabIndex = 0;
            this.panelTitleBarBillForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBarBillForm_MouseDown);
            // 
            // btnCloseBillForm
            // 
            this.btnCloseBillForm.BorderRadius = 7;
            this.btnCloseBillForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseBillForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCloseBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCloseBillForm.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseBillForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCloseBillForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseBillForm.Image = global::BankManagement.Properties.Resources.letter_x;
            this.btnCloseBillForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCloseBillForm.ImageOffset = new System.Drawing.Point(-2, 0);
            this.btnCloseBillForm.ImageSize = new System.Drawing.Size(14, 14);
            this.btnCloseBillForm.Location = new System.Drawing.Point(435, 4);
            this.btnCloseBillForm.Name = "btnCloseBillForm";
            this.btnCloseBillForm.Size = new System.Drawing.Size(30, 30);
            this.btnCloseBillForm.TabIndex = 0;
            this.btnCloseBillForm.Click += new System.EventHandler(this.btnCloseBillForm_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lbUtcbankBillForm
            // 
            this.lbUtcbankBillForm.AutoSize = true;
            this.lbUtcbankBillForm.BackColor = System.Drawing.Color.White;
            this.lbUtcbankBillForm.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUtcbankBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(29)))), ((int)(((byte)(5)))));
            this.lbUtcbankBillForm.Location = new System.Drawing.Point(94, 85);
            this.lbUtcbankBillForm.Name = "lbUtcbankBillForm";
            this.lbUtcbankBillForm.Size = new System.Drawing.Size(100, 25);
            this.lbUtcbankBillForm.TabIndex = 3;
            this.lbUtcbankBillForm.Text = "Utcbank";
            // 
            // txtGiaoDichThanhCongBillForm
            // 
            this.txtGiaoDichThanhCongBillForm.BackColor = System.Drawing.Color.White;
            this.txtGiaoDichThanhCongBillForm.BorderRadius = 10;
            this.txtGiaoDichThanhCongBillForm.BorderThickness = 0;
            this.txtGiaoDichThanhCongBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGiaoDichThanhCongBillForm.DefaultText = "  Giao dịch thành công!";
            this.txtGiaoDichThanhCongBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGiaoDichThanhCongBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGiaoDichThanhCongBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGiaoDichThanhCongBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGiaoDichThanhCongBillForm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(171)))));
            this.txtGiaoDichThanhCongBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGiaoDichThanhCongBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaoDichThanhCongBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(29)))), ((int)(((byte)(5)))));
            this.txtGiaoDichThanhCongBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGiaoDichThanhCongBillForm.Location = new System.Drawing.Point(56, 148);
            this.txtGiaoDichThanhCongBillForm.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiaoDichThanhCongBillForm.Name = "txtGiaoDichThanhCongBillForm";
            this.txtGiaoDichThanhCongBillForm.PasswordChar = '\0';
            this.txtGiaoDichThanhCongBillForm.PlaceholderText = "";
            this.txtGiaoDichThanhCongBillForm.ReadOnly = true;
            this.txtGiaoDichThanhCongBillForm.SelectedText = "";
            this.txtGiaoDichThanhCongBillForm.Size = new System.Drawing.Size(360, 40);
            this.txtGiaoDichThanhCongBillForm.TabIndex = 5;
            this.txtGiaoDichThanhCongBillForm.TextOffset = new System.Drawing.Point(0, -2);
            // 
            // lbNganHangBillForm
            // 
            this.lbNganHangBillForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNganHangBillForm.AutoSize = true;
            this.lbNganHangBillForm.BackColor = System.Drawing.Color.White;
            this.lbNganHangBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNganHangBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbNganHangBillForm.Location = new System.Drawing.Point(45, 305);
            this.lbNganHangBillForm.Name = "lbNganHangBillForm";
            this.lbNganHangBillForm.Size = new System.Drawing.Size(79, 18);
            this.lbNganHangBillForm.TabIndex = 4;
            this.lbNganHangBillForm.Text = "Ngân hàng";
            // 
            // lbTuTaiKhoanBillForm
            // 
            this.lbTuTaiKhoanBillForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTuTaiKhoanBillForm.AutoSize = true;
            this.lbTuTaiKhoanBillForm.BackColor = System.Drawing.Color.White;
            this.lbTuTaiKhoanBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTuTaiKhoanBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbTuTaiKhoanBillForm.Location = new System.Drawing.Point(45, 235);
            this.lbTuTaiKhoanBillForm.Name = "lbTuTaiKhoanBillForm";
            this.lbTuTaiKhoanBillForm.Size = new System.Drawing.Size(88, 18);
            this.lbTuTaiKhoanBillForm.TabIndex = 4;
            this.lbTuTaiKhoanBillForm.Text = "Từ tài khoản";
            // 
            // lbSoTienBillForm
            // 
            this.lbSoTienBillForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSoTienBillForm.AutoSize = true;
            this.lbSoTienBillForm.BackColor = System.Drawing.Color.White;
            this.lbSoTienBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoTienBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbSoTienBillForm.Location = new System.Drawing.Point(45, 375);
            this.lbSoTienBillForm.Name = "lbSoTienBillForm";
            this.lbSoTienBillForm.Size = new System.Drawing.Size(54, 18);
            this.lbSoTienBillForm.TabIndex = 4;
            this.lbSoTienBillForm.Text = "Số tiền";
            // 
            // lbPhiGiaoDichBillForm
            // 
            this.lbPhiGiaoDichBillForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPhiGiaoDichBillForm.AutoSize = true;
            this.lbPhiGiaoDichBillForm.BackColor = System.Drawing.Color.White;
            this.lbPhiGiaoDichBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhiGiaoDichBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbPhiGiaoDichBillForm.Location = new System.Drawing.Point(45, 430);
            this.lbPhiGiaoDichBillForm.Name = "lbPhiGiaoDichBillForm";
            this.lbPhiGiaoDichBillForm.Size = new System.Drawing.Size(92, 18);
            this.lbPhiGiaoDichBillForm.TabIndex = 4;
            this.lbPhiGiaoDichBillForm.Text = "Phí giao dịch";
            // 
            // lbNoiDungBillForm
            // 
            this.lbNoiDungBillForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNoiDungBillForm.AutoSize = true;
            this.lbNoiDungBillForm.BackColor = System.Drawing.Color.White;
            this.lbNoiDungBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoiDungBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbNoiDungBillForm.Location = new System.Drawing.Point(45, 490);
            this.lbNoiDungBillForm.Name = "lbNoiDungBillForm";
            this.lbNoiDungBillForm.Size = new System.Drawing.Size(67, 18);
            this.lbNoiDungBillForm.TabIndex = 4;
            this.lbNoiDungBillForm.Text = "Nội dung";
            // 
            // lbDenTaiKhoanBillForm
            // 
            this.lbDenTaiKhoanBillForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDenTaiKhoanBillForm.AutoSize = true;
            this.lbDenTaiKhoanBillForm.BackColor = System.Drawing.Color.White;
            this.lbDenTaiKhoanBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDenTaiKhoanBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbDenTaiKhoanBillForm.Location = new System.Drawing.Point(45, 575);
            this.lbDenTaiKhoanBillForm.Name = "lbDenTaiKhoanBillForm";
            this.lbDenTaiKhoanBillForm.Size = new System.Drawing.Size(99, 18);
            this.lbDenTaiKhoanBillForm.TabIndex = 4;
            this.lbDenTaiKhoanBillForm.Text = "Đến tài khoản";
            // 
            // txtAccountNumberSendBillForm
            // 
            this.txtAccountNumberSendBillForm.BorderThickness = 0;
            this.txtAccountNumberSendBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAccountNumberSendBillForm.DefaultText = "1017766701";
            this.txtAccountNumberSendBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAccountNumberSendBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAccountNumberSendBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAccountNumberSendBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAccountNumberSendBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAccountNumberSendBillForm.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumberSendBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(29)))), ((int)(((byte)(5)))));
            this.txtAccountNumberSendBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAccountNumberSendBillForm.Location = new System.Drawing.Point(310, 235);
            this.txtAccountNumberSendBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccountNumberSendBillForm.Name = "txtAccountNumberSendBillForm";
            this.txtAccountNumberSendBillForm.PasswordChar = '\0';
            this.txtAccountNumberSendBillForm.PlaceholderText = "";
            this.txtAccountNumberSendBillForm.ReadOnly = true;
            this.txtAccountNumberSendBillForm.SelectedText = "";
            this.txtAccountNumberSendBillForm.Size = new System.Drawing.Size(112, 26);
            this.txtAccountNumberSendBillForm.TabIndex = 6;
            this.txtAccountNumberSendBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAccountNumberSendBillForm.WordWrap = false;
            // 
            // txtCustomerNameSendBillForm
            // 
            this.txtCustomerNameSendBillForm.BorderThickness = 0;
            this.txtCustomerNameSendBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerNameSendBillForm.DefaultText = "DINH NGOC THE";
            this.txtCustomerNameSendBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerNameSendBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerNameSendBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerNameSendBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerNameSendBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerNameSendBillForm.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerNameSendBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(29)))), ((int)(((byte)(5)))));
            this.txtCustomerNameSendBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerNameSendBillForm.Location = new System.Drawing.Point(197, 260);
            this.txtCustomerNameSendBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerNameSendBillForm.Name = "txtCustomerNameSendBillForm";
            this.txtCustomerNameSendBillForm.PasswordChar = '\0';
            this.txtCustomerNameSendBillForm.PlaceholderText = "";
            this.txtCustomerNameSendBillForm.ReadOnly = true;
            this.txtCustomerNameSendBillForm.SelectedText = "";
            this.txtCustomerNameSendBillForm.Size = new System.Drawing.Size(225, 26);
            this.txtCustomerNameSendBillForm.TabIndex = 6;
            this.txtCustomerNameSendBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCustomerNameSendBillForm.WordWrap = false;
            // 
            // txtMienPhiBillForm
            // 
            this.txtMienPhiBillForm.BorderThickness = 0;
            this.txtMienPhiBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMienPhiBillForm.DefaultText = "Miễn phí";
            this.txtMienPhiBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMienPhiBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMienPhiBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMienPhiBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMienPhiBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMienPhiBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMienPhiBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtMienPhiBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMienPhiBillForm.Location = new System.Drawing.Point(340, 430);
            this.txtMienPhiBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMienPhiBillForm.Name = "txtMienPhiBillForm";
            this.txtMienPhiBillForm.PasswordChar = '\0';
            this.txtMienPhiBillForm.PlaceholderText = "";
            this.txtMienPhiBillForm.ReadOnly = true;
            this.txtMienPhiBillForm.SelectedText = "";
            this.txtMienPhiBillForm.Size = new System.Drawing.Size(82, 25);
            this.txtMienPhiBillForm.TabIndex = 6;
            this.txtMienPhiBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMienPhiBillForm.WordWrap = false;
            // 
            // txtContentBillForm
            // 
            this.txtContentBillForm.BorderThickness = 0;
            this.txtContentBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContentBillForm.DefaultText = "DINH NGOC THE chuyen tien den NGUYEN TRAN HIEU";
            this.txtContentBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContentBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContentBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContentBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContentBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContentBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContentBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtContentBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContentBillForm.Location = new System.Drawing.Point(144, 480);
            this.txtContentBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContentBillForm.Multiline = true;
            this.txtContentBillForm.Name = "txtContentBillForm";
            this.txtContentBillForm.PasswordChar = '\0';
            this.txtContentBillForm.PlaceholderText = "";
            this.txtContentBillForm.ReadOnly = true;
            this.txtContentBillForm.SelectedText = "";
            this.txtContentBillForm.Size = new System.Drawing.Size(278, 78);
            this.txtContentBillForm.TabIndex = 6;
            this.txtContentBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtContentBillForm.WordWrap = false;
            // 
            // txtAmountBillForm
            // 
            this.txtAmountBillForm.BorderThickness = 0;
            this.txtAmountBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmountBillForm.DefaultText = "150,000 VNĐ";
            this.txtAmountBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAmountBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAmountBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmountBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmountBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmountBillForm.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(29)))), ((int)(((byte)(5)))));
            this.txtAmountBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmountBillForm.Location = new System.Drawing.Point(197, 375);
            this.txtAmountBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmountBillForm.Name = "txtAmountBillForm";
            this.txtAmountBillForm.PasswordChar = '\0';
            this.txtAmountBillForm.PlaceholderText = "";
            this.txtAmountBillForm.ReadOnly = true;
            this.txtAmountBillForm.SelectedText = "";
            this.txtAmountBillForm.Size = new System.Drawing.Size(225, 26);
            this.txtAmountBillForm.TabIndex = 6;
            this.txtAmountBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountBillForm.WordWrap = false;
            // 
            // txtAccountNumberReceiveBillForm
            // 
            this.txtAccountNumberReceiveBillForm.BorderThickness = 0;
            this.txtAccountNumberReceiveBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAccountNumberReceiveBillForm.DefaultText = "1017766701";
            this.txtAccountNumberReceiveBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAccountNumberReceiveBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAccountNumberReceiveBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAccountNumberReceiveBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAccountNumberReceiveBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAccountNumberReceiveBillForm.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumberReceiveBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(29)))), ((int)(((byte)(5)))));
            this.txtAccountNumberReceiveBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAccountNumberReceiveBillForm.Location = new System.Drawing.Point(310, 575);
            this.txtAccountNumberReceiveBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccountNumberReceiveBillForm.Name = "txtAccountNumberReceiveBillForm";
            this.txtAccountNumberReceiveBillForm.PasswordChar = '\0';
            this.txtAccountNumberReceiveBillForm.PlaceholderText = "";
            this.txtAccountNumberReceiveBillForm.ReadOnly = true;
            this.txtAccountNumberReceiveBillForm.SelectedText = "";
            this.txtAccountNumberReceiveBillForm.Size = new System.Drawing.Size(112, 26);
            this.txtAccountNumberReceiveBillForm.TabIndex = 6;
            this.txtAccountNumberReceiveBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAccountNumberReceiveBillForm.WordWrap = false;
            // 
            // txtCustomerNameReceiveBillForm
            // 
            this.txtCustomerNameReceiveBillForm.BorderThickness = 0;
            this.txtCustomerNameReceiveBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerNameReceiveBillForm.DefaultText = "DINH NGOC THE";
            this.txtCustomerNameReceiveBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerNameReceiveBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerNameReceiveBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerNameReceiveBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerNameReceiveBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerNameReceiveBillForm.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerNameReceiveBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(29)))), ((int)(((byte)(5)))));
            this.txtCustomerNameReceiveBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerNameReceiveBillForm.Location = new System.Drawing.Point(197, 600);
            this.txtCustomerNameReceiveBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerNameReceiveBillForm.Name = "txtCustomerNameReceiveBillForm";
            this.txtCustomerNameReceiveBillForm.PasswordChar = '\0';
            this.txtCustomerNameReceiveBillForm.PlaceholderText = "";
            this.txtCustomerNameReceiveBillForm.ReadOnly = true;
            this.txtCustomerNameReceiveBillForm.SelectedText = "";
            this.txtCustomerNameReceiveBillForm.Size = new System.Drawing.Size(225, 26);
            this.txtCustomerNameReceiveBillForm.TabIndex = 6;
            this.txtCustomerNameReceiveBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCustomerNameReceiveBillForm.WordWrap = false;
            // 
            // txtTimeBillForm
            // 
            this.txtTimeBillForm.BorderThickness = 0;
            this.txtTimeBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimeBillForm.DefaultText = "19/10/2024     16:12";
            this.txtTimeBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimeBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimeBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimeBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimeBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimeBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeBillForm.ForeColor = System.Drawing.Color.Gray;
            this.txtTimeBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimeBillForm.Location = new System.Drawing.Point(236, 76);
            this.txtTimeBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimeBillForm.Name = "txtTimeBillForm";
            this.txtTimeBillForm.PasswordChar = '\0';
            this.txtTimeBillForm.PlaceholderText = "";
            this.txtTimeBillForm.ReadOnly = true;
            this.txtTimeBillForm.SelectedText = "";
            this.txtTimeBillForm.Size = new System.Drawing.Size(186, 25);
            this.txtTimeBillForm.TabIndex = 6;
            this.txtTimeBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimeBillForm.WordWrap = false;
            // 
            // txtTransactionCodeBillForm
            // 
            this.txtTransactionCodeBillForm.BorderThickness = 0;
            this.txtTransactionCodeBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTransactionCodeBillForm.DefaultText = "15HK1L456IC0";
            this.txtTransactionCodeBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTransactionCodeBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTransactionCodeBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTransactionCodeBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTransactionCodeBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTransactionCodeBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionCodeBillForm.ForeColor = System.Drawing.Color.Gray;
            this.txtTransactionCodeBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTransactionCodeBillForm.Location = new System.Drawing.Point(236, 100);
            this.txtTransactionCodeBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTransactionCodeBillForm.Name = "txtTransactionCodeBillForm";
            this.txtTransactionCodeBillForm.PasswordChar = '\0';
            this.txtTransactionCodeBillForm.PlaceholderText = "";
            this.txtTransactionCodeBillForm.ReadOnly = true;
            this.txtTransactionCodeBillForm.SelectedText = "";
            this.txtTransactionCodeBillForm.Size = new System.Drawing.Size(186, 25);
            this.txtTransactionCodeBillForm.TabIndex = 6;
            this.txtTransactionCodeBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransactionCodeBillForm.WordWrap = false;
            // 
            // btnExportPdfBillForm
            // 
            this.btnExportPdfBillForm.BackColor = System.Drawing.Color.White;
            this.btnExportPdfBillForm.BorderRadius = 10;
            this.btnExportPdfBillForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportPdfBillForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportPdfBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportPdfBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportPdfBillForm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnExportPdfBillForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportPdfBillForm.ForeColor = System.Drawing.Color.White;
            this.btnExportPdfBillForm.Image = global::BankManagement.Properties.Resources.img_export_pdf;
            this.btnExportPdfBillForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExportPdfBillForm.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnExportPdfBillForm.ImageSize = new System.Drawing.Size(25, 25);
            this.btnExportPdfBillForm.Location = new System.Drawing.Point(48, 658);
            this.btnExportPdfBillForm.Name = "btnExportPdfBillForm";
            this.btnExportPdfBillForm.Size = new System.Drawing.Size(35, 37);
            this.btnExportPdfBillForm.TabIndex = 7;
            this.btnExportPdfBillForm.Click += new System.EventHandler(this.btnExportPdfBillForm_Click);
            // 
            // btnLogoBillForm
            // 
            this.btnLogoBillForm.BackColor = System.Drawing.Color.White;
            this.btnLogoBillForm.BorderRadius = 20;
            this.btnLogoBillForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogoBillForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogoBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogoBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogoBillForm.FillColor = System.Drawing.Color.Brown;
            this.btnLogoBillForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogoBillForm.ForeColor = System.Drawing.Color.White;
            this.btnLogoBillForm.Image = global::BankManagement.Properties.Resources.logo;
            this.btnLogoBillForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogoBillForm.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnLogoBillForm.ImageSize = new System.Drawing.Size(35, 35);
            this.btnLogoBillForm.Location = new System.Drawing.Point(53, 76);
            this.btnLogoBillForm.Name = "btnLogoBillForm";
            this.btnLogoBillForm.Size = new System.Drawing.Size(43, 43);
            this.btnLogoBillForm.TabIndex = 2;
            // 
            // imgBackGroundBillForm
            // 
            this.imgBackGroundBillForm.Image = global::BankManagement.Properties.Resources.img_background_bill;
            this.imgBackGroundBillForm.Location = new System.Drawing.Point(27, 48);
            this.imgBackGroundBillForm.Name = "imgBackGroundBillForm";
            this.imgBackGroundBillForm.Size = new System.Drawing.Size(417, 676);
            this.imgBackGroundBillForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBackGroundBillForm.TabIndex = 1;
            this.imgBackGroundBillForm.TabStop = false;
            // 
            // lbExportPDFBillForm
            // 
            this.lbExportPDFBillForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbExportPDFBillForm.AutoSize = true;
            this.lbExportPDFBillForm.BackColor = System.Drawing.Color.White;
            this.lbExportPDFBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExportPDFBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbExportPDFBillForm.Location = new System.Drawing.Point(84, 669);
            this.lbExportPDFBillForm.Name = "lbExportPDFBillForm";
            this.lbExportPDFBillForm.Size = new System.Drawing.Size(87, 16);
            this.lbExportPDFBillForm.TabIndex = 4;
            this.lbExportPDFBillForm.Text = "Export to PDF";
            // 
            // txtNganHangBillForm
            // 
            this.txtNganHangBillForm.BorderThickness = 0;
            this.txtNganHangBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNganHangBillForm.DefaultText = "Ngân hàng Thương mại và";
            this.txtNganHangBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNganHangBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNganHangBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNganHangBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNganHangBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNganHangBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNganHangBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtNganHangBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNganHangBillForm.Location = new System.Drawing.Point(228, 305);
            this.txtNganHangBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNganHangBillForm.Name = "txtNganHangBillForm";
            this.txtNganHangBillForm.PasswordChar = '\0';
            this.txtNganHangBillForm.PlaceholderText = "";
            this.txtNganHangBillForm.ReadOnly = true;
            this.txtNganHangBillForm.SelectedText = "";
            this.txtNganHangBillForm.Size = new System.Drawing.Size(194, 25);
            this.txtNganHangBillForm.TabIndex = 6;
            this.txtNganHangBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNganHangBillForm.WordWrap = false;
            // 
            // txtDauTuBillForm
            // 
            this.txtDauTuBillForm.BorderThickness = 0;
            this.txtDauTuBillForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDauTuBillForm.DefaultText = "Đầu tư Utcbank";
            this.txtDauTuBillForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDauTuBillForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDauTuBillForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDauTuBillForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDauTuBillForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDauTuBillForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDauTuBillForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtDauTuBillForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDauTuBillForm.Location = new System.Drawing.Point(283, 330);
            this.txtDauTuBillForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDauTuBillForm.Name = "txtDauTuBillForm";
            this.txtDauTuBillForm.PasswordChar = '\0';
            this.txtDauTuBillForm.PlaceholderText = "";
            this.txtDauTuBillForm.ReadOnly = true;
            this.txtDauTuBillForm.SelectedText = "";
            this.txtDauTuBillForm.Size = new System.Drawing.Size(139, 25);
            this.txtDauTuBillForm.TabIndex = 6;
            this.txtDauTuBillForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDauTuBillForm.WordWrap = false;
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(470, 750);
            this.Controls.Add(this.btnExportPdfBillForm);
            this.Controls.Add(this.txtContentBillForm);
            this.Controls.Add(this.txtNganHangBillForm);
            this.Controls.Add(this.txtDauTuBillForm);
            this.Controls.Add(this.txtMienPhiBillForm);
            this.Controls.Add(this.txtCustomerNameReceiveBillForm);
            this.Controls.Add(this.txtCustomerNameSendBillForm);
            this.Controls.Add(this.txtAccountNumberReceiveBillForm);
            this.Controls.Add(this.txtAmountBillForm);
            this.Controls.Add(this.txtTransactionCodeBillForm);
            this.Controls.Add(this.txtTimeBillForm);
            this.Controls.Add(this.txtAccountNumberSendBillForm);
            this.Controls.Add(this.txtGiaoDichThanhCongBillForm);
            this.Controls.Add(this.lbNoiDungBillForm);
            this.Controls.Add(this.lbPhiGiaoDichBillForm);
            this.Controls.Add(this.lbSoTienBillForm);
            this.Controls.Add(this.lbExportPDFBillForm);
            this.Controls.Add(this.lbDenTaiKhoanBillForm);
            this.Controls.Add(this.lbTuTaiKhoanBillForm);
            this.Controls.Add(this.lbNganHangBillForm);
            this.Controls.Add(this.btnLogoBillForm);
            this.Controls.Add(this.lbUtcbankBillForm);
            this.Controls.Add(this.imgBackGroundBillForm);
            this.Controls.Add(this.panelTitleBarBillForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BillForm";
            this.Load += new System.EventHandler(this.BillForm_Load);
            this.panelTitleBarBillForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgBackGroundBillForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBarBillForm;
        private System.Windows.Forms.PictureBox imgBackGroundBillForm;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button btnLogoBillForm;
        private System.Windows.Forms.Label lbUtcbankBillForm;
        private Guna.UI2.WinForms.Guna2Button btnCloseBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtGiaoDichThanhCongBillForm;
        private System.Windows.Forms.Label lbNganHangBillForm;
        private System.Windows.Forms.Label lbTuTaiKhoanBillForm;
        private System.Windows.Forms.Label lbNoiDungBillForm;
        private System.Windows.Forms.Label lbPhiGiaoDichBillForm;
        private System.Windows.Forms.Label lbSoTienBillForm;
        private System.Windows.Forms.Label lbDenTaiKhoanBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerNameSendBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtAccountNumberSendBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtContentBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtMienPhiBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerNameReceiveBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtAccountNumberReceiveBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtAmountBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtTimeBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtTransactionCodeBillForm;
        private Guna.UI2.WinForms.Guna2Button btnExportPdfBillForm;
        private System.Windows.Forms.Label lbExportPDFBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtNganHangBillForm;
        private Guna.UI2.WinForms.Guna2TextBox txtDauTuBillForm;
    }
}