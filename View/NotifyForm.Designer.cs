namespace BankManagement.View
{
    partial class NotifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyForm));
            this.lbNotificationsLogForm = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.flowPanelNotifyForm = new System.Windows.Forms.FlowLayoutPanel();
            this.vsScrollBarLogForm = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.btnMoreNotifyForm = new Guna.UI2.WinForms.Guna2Button();
            this.flowPanelNotifyForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNotificationsLogForm
            // 
            this.lbNotificationsLogForm.AutoSize = true;
            this.lbNotificationsLogForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotificationsLogForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(25)))));
            this.lbNotificationsLogForm.Location = new System.Drawing.Point(18, 18);
            this.lbNotificationsLogForm.Name = "lbNotificationsLogForm";
            this.lbNotificationsLogForm.Size = new System.Drawing.Size(116, 23);
            this.lbNotificationsLogForm.TabIndex = 1;
            this.lbNotificationsLogForm.Text = "Notifications";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // flowPanelNotifyForm
            // 
            this.flowPanelNotifyForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanelNotifyForm.AutoScroll = true;
            this.flowPanelNotifyForm.Controls.Add(this.btnMoreNotifyForm);
            this.flowPanelNotifyForm.Location = new System.Drawing.Point(22, 55);
            this.flowPanelNotifyForm.Name = "flowPanelNotifyForm";
            this.flowPanelNotifyForm.Size = new System.Drawing.Size(570, 367);
            this.flowPanelNotifyForm.TabIndex = 2;
            // 
            // vsScrollBarLogForm
            // 
            this.vsScrollBarLogForm.BindingContainer = this.flowPanelNotifyForm;
            this.vsScrollBarLogForm.BorderRadius = 5;
            this.vsScrollBarLogForm.FillColor = System.Drawing.Color.Transparent;
            this.vsScrollBarLogForm.InUpdate = false;
            this.vsScrollBarLogForm.LargeChange = 367;
            this.vsScrollBarLogForm.Location = new System.Drawing.Point(574, 55);
            this.vsScrollBarLogForm.Maximum = 372;
            this.vsScrollBarLogForm.Name = "vsScrollBarLogForm";
            this.vsScrollBarLogForm.ScrollbarSize = 18;
            this.vsScrollBarLogForm.Size = new System.Drawing.Size(18, 367);
            this.vsScrollBarLogForm.SmallChange = 5;
            this.vsScrollBarLogForm.TabIndex = 1;
            this.vsScrollBarLogForm.ThumbColor = System.Drawing.Color.Transparent;
            this.vsScrollBarLogForm.Visible = false;
            // 
            // btnMoreNotifyForm
            // 
            this.btnMoreNotifyForm.BorderRadius = 13;
            this.btnMoreNotifyForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMoreNotifyForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMoreNotifyForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMoreNotifyForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMoreNotifyForm.FillColor = System.Drawing.Color.Transparent;
            this.btnMoreNotifyForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMoreNotifyForm.ForeColor = System.Drawing.Color.White;
            this.btnMoreNotifyForm.Image = global::BankManagement.Properties.Resources.more_v;
            this.btnMoreNotifyForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMoreNotifyForm.ImageOffset = new System.Drawing.Point(-5, 0);
            this.btnMoreNotifyForm.ImageSize = new System.Drawing.Size(18, 18);
            this.btnMoreNotifyForm.Location = new System.Drawing.Point(3, 3);
            this.btnMoreNotifyForm.Name = "btnMoreNotifyForm";
            this.btnMoreNotifyForm.Size = new System.Drawing.Size(28, 28);
            this.btnMoreNotifyForm.TabIndex = 3;
            // 
            // NotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(594, 441);
            this.Controls.Add(this.vsScrollBarLogForm);
            this.Controls.Add(this.flowPanelNotifyForm);
            this.Controls.Add(this.lbNotificationsLogForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotifyForm";
            this.Text = "NotifyForm";
            this.Load += new System.EventHandler(this.NotifyForm_Load);
            this.flowPanelNotifyForm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNotificationsLogForm;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.FlowLayoutPanel flowPanelNotifyForm;
        private Guna.UI2.WinForms.Guna2VScrollBar vsScrollBarLogForm;
        private Guna.UI2.WinForms.Guna2Button btnMoreNotifyForm;
    }
}