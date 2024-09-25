namespace BankManagement
{
    partial class InfoStaffForm
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
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.btnLogOutInfoStaffForm = new Guna.UI2.WinForms.Guna2Button();
			this.lbJobPositionInfoStaffForm = new System.Windows.Forms.Label();
			this.lbBranchInfoStaffForm = new System.Windows.Forms.Label();
			this.lbUserNameInfoStaffForm = new System.Windows.Forms.Label();
			this.lbStaffNameInfoStaffForm = new System.Windows.Forms.Label();
			this.imgStaffAvatarInfoStaffForm = new System.Windows.Forms.PictureBox();
			this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgStaffAvatarInfoStaffForm)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
			this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
			this.guna2Panel1.BorderRadius = 21;
			this.guna2Panel1.Controls.Add(this.btnLogOutInfoStaffForm);
			this.guna2Panel1.Controls.Add(this.lbJobPositionInfoStaffForm);
			this.guna2Panel1.Controls.Add(this.lbBranchInfoStaffForm);
			this.guna2Panel1.Controls.Add(this.lbUserNameInfoStaffForm);
			this.guna2Panel1.Controls.Add(this.lbStaffNameInfoStaffForm);
			this.guna2Panel1.Controls.Add(this.imgStaffAvatarInfoStaffForm);
			this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
			this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
			this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(210, 223);
			this.guna2Panel1.TabIndex = 0;
			// 
			// btnLogOutInfoStaffForm
			// 
			this.btnLogOutInfoStaffForm.BorderRadius = 12;
			this.btnLogOutInfoStaffForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnLogOutInfoStaffForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnLogOutInfoStaffForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnLogOutInfoStaffForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnLogOutInfoStaffForm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
			this.btnLogOutInfoStaffForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLogOutInfoStaffForm.ForeColor = System.Drawing.Color.White;
			this.btnLogOutInfoStaffForm.Image = global::BankManagement.Properties.Resources.logout;
			this.btnLogOutInfoStaffForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.btnLogOutInfoStaffForm.ImageOffset = new System.Drawing.Point(38, 1);
			this.btnLogOutInfoStaffForm.ImageSize = new System.Drawing.Size(18, 18);
			this.btnLogOutInfoStaffForm.Location = new System.Drawing.Point(21, 152);
			this.btnLogOutInfoStaffForm.Margin = new System.Windows.Forms.Padding(2);
			this.btnLogOutInfoStaffForm.Name = "btnLogOutInfoStaffForm";
			this.btnLogOutInfoStaffForm.Size = new System.Drawing.Size(172, 44);
			this.btnLogOutInfoStaffForm.TabIndex = 4;
			this.btnLogOutInfoStaffForm.Text = "Log out";
			this.btnLogOutInfoStaffForm.TextOffset = new System.Drawing.Point(-15, -1);
			this.btnLogOutInfoStaffForm.Click += new System.EventHandler(this.btnLogOutInfoStaffForm_Click);
			// 
			// lbJobPositionInfoStaffForm
			// 
			this.lbJobPositionInfoStaffForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbJobPositionInfoStaffForm.AutoSize = true;
			this.lbJobPositionInfoStaffForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobPositionInfoStaffForm.Location = new System.Drawing.Point(28, 113);
			this.lbJobPositionInfoStaffForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbJobPositionInfoStaffForm.Name = "lbJobPositionInfoStaffForm";
			this.lbJobPositionInfoStaffForm.Size = new System.Drawing.Size(112, 14);
			this.lbJobPositionInfoStaffForm.TabIndex = 3;
			this.lbJobPositionInfoStaffForm.Text = "Vị trí: Giao dịch viên";
			// 
			// lbBranchInfoStaffForm
			// 
			this.lbBranchInfoStaffForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbBranchInfoStaffForm.AutoSize = true;
			this.lbBranchInfoStaffForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbBranchInfoStaffForm.Location = new System.Drawing.Point(28, 86);
			this.lbBranchInfoStaffForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbBranchInfoStaffForm.Name = "lbBranchInfoStaffForm";
			this.lbBranchInfoStaffForm.Size = new System.Drawing.Size(160, 14);
			this.lbBranchInfoStaffForm.TabIndex = 3;
			this.lbBranchInfoStaffForm.Text = "Chi nhánh: Cầu Giấy - Hà Nội";
			// 
			// lbUserNameInfoStaffForm
			// 
			this.lbUserNameInfoStaffForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbUserNameInfoStaffForm.AutoSize = true;
			this.lbUserNameInfoStaffForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbUserNameInfoStaffForm.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.lbUserNameInfoStaffForm.Location = new System.Drawing.Point(72, 47);
			this.lbUserNameInfoStaffForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbUserNameInfoStaffForm.Name = "lbUserNameInfoStaffForm";
			this.lbUserNameInfoStaffForm.Size = new System.Drawing.Size(64, 12);
			this.lbUserNameInfoStaffForm.TabIndex = 2;
			this.lbUserNameInfoStaffForm.Text = "anhvy@.work";
			// 
			// lbStaffNameInfoStaffForm
			// 
			this.lbStaffNameInfoStaffForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbStaffNameInfoStaffForm.AutoSize = true;
			this.lbStaffNameInfoStaffForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbStaffNameInfoStaffForm.Location = new System.Drawing.Point(70, 25);
			this.lbStaffNameInfoStaffForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbStaffNameInfoStaffForm.Name = "lbStaffNameInfoStaffForm";
			this.lbStaffNameInfoStaffForm.Size = new System.Drawing.Size(108, 18);
			this.lbStaffNameInfoStaffForm.TabIndex = 1;
			this.lbStaffNameInfoStaffForm.Text = "Nguyen Anh Vy";
			// 
			// imgStaffAvatarInfoStaffForm
			// 
			this.imgStaffAvatarInfoStaffForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imgStaffAvatarInfoStaffForm.Image = global::BankManagement.Properties.Resources.staff_woman;
			this.imgStaffAvatarInfoStaffForm.Location = new System.Drawing.Point(14, 15);
			this.imgStaffAvatarInfoStaffForm.Margin = new System.Windows.Forms.Padding(2);
			this.imgStaffAvatarInfoStaffForm.Name = "imgStaffAvatarInfoStaffForm";
			this.imgStaffAvatarInfoStaffForm.Size = new System.Drawing.Size(56, 49);
			this.imgStaffAvatarInfoStaffForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgStaffAvatarInfoStaffForm.TabIndex = 0;
			this.imgStaffAvatarInfoStaffForm.TabStop = false;
			// 
			// guna2BorderlessForm1
			// 
			this.guna2BorderlessForm1.BorderRadius = 27;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockForm = false;
			this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.Transparent;
			this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
			this.guna2BorderlessForm1.HasFormShadow = false;
			this.guna2BorderlessForm1.ResizeForm = false;
			this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Transparent;
			this.guna2BorderlessForm1.TransparentWhileDrag = true;
			// 
			// InfoStaffForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(211, 224);
			this.Controls.Add(this.guna2Panel1);
			this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "InfoStaffForm";
			this.Text = "InfoStaff";
			this.Load += new System.EventHandler(this.InfoStaff_Load);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgStaffAvatarInfoStaffForm)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lbBranchInfoStaffForm;
        private System.Windows.Forms.Label lbUserNameInfoStaffForm;
        private System.Windows.Forms.Label lbStaffNameInfoStaffForm;
        private System.Windows.Forms.PictureBox imgStaffAvatarInfoStaffForm;
        private System.Windows.Forms.Label lbJobPositionInfoStaffForm;
        private Guna.UI2.WinForms.Guna2Button btnLogOutInfoStaffForm;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}