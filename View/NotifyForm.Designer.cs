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
            this.vsScrollBarNotifyForm = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.SuspendLayout();
            // 
            // lbNotificationsLogForm
            // 
            this.lbNotificationsLogForm.AutoSize = true;
            this.lbNotificationsLogForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotificationsLogForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(25)))));
            this.lbNotificationsLogForm.Location = new System.Drawing.Point(16, 14);
            this.lbNotificationsLogForm.Name = "lbNotificationsLogForm";
            this.lbNotificationsLogForm.Size = new System.Drawing.Size(129, 25);
            this.lbNotificationsLogForm.TabIndex = 1;
            this.lbNotificationsLogForm.Text = "Notifications";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // flowPanelNotifyForm
            // 
            this.flowPanelNotifyForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanelNotifyForm.AutoScroll = true;
            this.flowPanelNotifyForm.Location = new System.Drawing.Point(22, 55);
            this.flowPanelNotifyForm.Name = "flowPanelNotifyForm";
            this.flowPanelNotifyForm.Size = new System.Drawing.Size(571, 326);
            this.flowPanelNotifyForm.TabIndex = 2;
            this.flowPanelNotifyForm.Paint += new System.Windows.Forms.PaintEventHandler(this.flowPanelNotifyForm_Paint);
            // 
            // vsScrollBarNotifyForm
            // 
            this.vsScrollBarNotifyForm.BindingContainer = this.flowPanelNotifyForm;
            this.vsScrollBarNotifyForm.BorderRadius = 5;
            this.vsScrollBarNotifyForm.FillColor = System.Drawing.Color.Transparent;
            this.vsScrollBarNotifyForm.InUpdate = false;
            this.vsScrollBarNotifyForm.LargeChange = 10;
            this.vsScrollBarNotifyForm.Location = new System.Drawing.Point(575, 55);
            this.vsScrollBarNotifyForm.Name = "vsScrollBarNotifyForm";
            this.vsScrollBarNotifyForm.ScrollbarSize = 18;
            this.vsScrollBarNotifyForm.Size = new System.Drawing.Size(18, 326);
            this.vsScrollBarNotifyForm.TabIndex = 1;
            this.vsScrollBarNotifyForm.ThumbColor = System.Drawing.Color.Transparent;
            this.vsScrollBarNotifyForm.Visible = false;
            // 
            // NotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(595, 400);
            this.Controls.Add(this.vsScrollBarNotifyForm);
            this.Controls.Add(this.flowPanelNotifyForm);
            this.Controls.Add(this.lbNotificationsLogForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotifyForm";
            this.Text = "NotifyForm";
            this.Deactivate += new System.EventHandler(this.NotifyForm_Deactivate);
            this.Load += new System.EventHandler(this.NotifyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNotificationsLogForm;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.FlowLayoutPanel flowPanelNotifyForm;
        private Guna.UI2.WinForms.Guna2VScrollBar vsScrollBarNotifyForm;
    }
}