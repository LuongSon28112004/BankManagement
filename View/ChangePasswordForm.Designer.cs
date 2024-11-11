namespace BankManagement.View
{
    partial class ChangePasswordForm
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
            this.txtCurrentPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbReType = new System.Windows.Forms.Label();
            this.txtReType = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lbChangePassword = new System.Windows.Forms.Label();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.lbCurrentPassword = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lbWarning = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.BorderRadius = 9;
            this.txtCurrentPassword.BorderThickness = 0;
            this.txtCurrentPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentPassword.DefaultText = "";
            this.txtCurrentPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCurrentPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCurrentPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.txtCurrentPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCurrentPassword.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPassword.ForeColor = System.Drawing.Color.White;
            this.txtCurrentPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCurrentPassword.Location = new System.Drawing.Point(44, 72);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '\0';
            this.txtCurrentPassword.PlaceholderText = "";
            this.txtCurrentPassword.SelectedText = "";
            this.txtCurrentPassword.Size = new System.Drawing.Size(290, 38);
            this.txtCurrentPassword.TabIndex = 0;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderRadius = 9;
            this.txtNewPassword.BorderThickness = 0;
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.txtNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPassword.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.ForeColor = System.Drawing.Color.White;
            this.txtNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPassword.Location = new System.Drawing.Point(44, 144);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '\0';
            this.txtNewPassword.PlaceholderText = "";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(290, 38);
            this.txtNewPassword.TabIndex = 1;
            // 
            // lbReType
            // 
            this.lbReType.AutoSize = true;
            this.lbReType.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReType.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbReType.Location = new System.Drawing.Point(44, 194);
            this.lbReType.Name = "lbReType";
            this.lbReType.Size = new System.Drawing.Size(163, 18);
            this.lbReType.TabIndex = 0;
            this.lbReType.Text = "Re-type new password";
            // 
            // txtReType
            // 
            this.txtReType.BorderRadius = 9;
            this.txtReType.BorderThickness = 0;
            this.txtReType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReType.DefaultText = "";
            this.txtReType.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtReType.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtReType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReType.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.txtReType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReType.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReType.ForeColor = System.Drawing.Color.White;
            this.txtReType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReType.Location = new System.Drawing.Point(44, 216);
            this.txtReType.Name = "txtReType";
            this.txtReType.PasswordChar = '\0';
            this.txtReType.PlaceholderText = "";
            this.txtReType.SelectedText = "";
            this.txtReType.Size = new System.Drawing.Size(290, 38);
            this.txtReType.TabIndex = 2;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BorderRadius = 8;
            this.btnConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirm.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.btnConfirm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.btnConfirm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(241, 283);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 33);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lbChangePassword
            // 
            this.lbChangePassword.AutoSize = true;
            this.lbChangePassword.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
            this.lbChangePassword.Location = new System.Drawing.Point(12, 12);
            this.lbChangePassword.Name = "lbChangePassword";
            this.lbChangePassword.Size = new System.Drawing.Size(162, 23);
            this.lbChangePassword.TabIndex = 4;
            this.lbChangePassword.Text = "Change password";
            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbNewPassword.Location = new System.Drawing.Point(44, 123);
            this.lbNewPassword.Name = "lbNewPassword";
            this.lbNewPassword.Size = new System.Drawing.Size(109, 18);
            this.lbNewPassword.TabIndex = 0;
            this.lbNewPassword.Text = "New password";
            // 
            // lbCurrentPassword
            // 
            this.lbCurrentPassword.AutoSize = true;
            this.lbCurrentPassword.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbCurrentPassword.Location = new System.Drawing.Point(44, 51);
            this.lbCurrentPassword.Name = "lbCurrentPassword";
            this.lbCurrentPassword.Size = new System.Drawing.Size(128, 18);
            this.lbCurrentPassword.TabIndex = 0;
            this.lbCurrentPassword.Text = "Current password";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lbWarning
            // 
            this.lbWarning.AutoSize = true;
            this.lbWarning.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(60)))), ((int)(((byte)(30)))));
            this.lbWarning.Location = new System.Drawing.Point(44, 258);
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Size = new System.Drawing.Size(171, 14);
            this.lbWarning.TabIndex = 5;
            this.lbWarning.Text = "Vui lòng nhập đầy đủ thông tin!";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 8;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::BankManagement.Properties.Resources.letter_x;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnClose.ImageSize = new System.Drawing.Size(11, 11);
            this.btnClose.Location = new System.Drawing.Point(343, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(378, 341);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbWarning);
            this.Controls.Add(this.lbChangePassword);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtReType);
            this.Controls.Add(this.lbReType);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lbNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.lbCurrentPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswordForm";
            this.Text = "ChangePasswordForm";
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtCurrentPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPassword;
        private System.Windows.Forms.Label lbReType;
        private Guna.UI2.WinForms.Guna2TextBox txtReType;
        private Guna.UI2.WinForms.Guna2GradientButton btnConfirm;
        private System.Windows.Forms.Label lbChangePassword;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.Label lbCurrentPassword;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label lbWarning;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}