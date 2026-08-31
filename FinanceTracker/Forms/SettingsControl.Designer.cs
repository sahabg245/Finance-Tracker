namespace FinanceTracker.Forms
{
    partial class SettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            containerPanel = new Guna.UI2.WinForms.Guna2Panel();
            profileButton = new Guna.UI2.WinForms.Guna2Button();
            budgetButton = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = SystemColors.Window;
            guna2HtmlLabel1.Location = new Point(41, 26);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(116, 27);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "PREFERENCES";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = SystemColors.Window;
            guna2HtmlLabel2.Location = new Point(41, 68);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(128, 39);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "SETTINGS";
            // 
            // containerPanel
            // 
            containerPanel.AutoScroll = true;
            containerPanel.BorderColor = Color.Silver;
            containerPanel.CustomizableEdges = customizableEdges1;
            containerPanel.FillColor = Color.Transparent;
            containerPanel.ForeColor = SystemColors.Window;
            containerPanel.Location = new Point(262, 68);
            containerPanel.Name = "containerPanel";
            containerPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            containerPanel.Size = new Size(670, 803);
            containerPanel.TabIndex = 2;
            // 
            // profileButton
            // 
            profileButton.BorderColor = Color.DarkOrange;
            profileButton.BorderRadius = 10;
            profileButton.BorderThickness = 2;
            profileButton.CustomizableEdges = customizableEdges3;
            profileButton.DisabledState.BorderColor = Color.DarkGray;
            profileButton.DisabledState.CustomBorderColor = Color.DarkGray;
            profileButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            profileButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            profileButton.FillColor = Color.Transparent;
            profileButton.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            profileButton.ForeColor = Color.White;
            profileButton.Location = new Point(45, 139);
            profileButton.Name = "profileButton";
            profileButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            profileButton.Size = new Size(174, 52);
            profileButton.TabIndex = 3;
            profileButton.Text = "Profile";
            profileButton.Click += profileButton_Click;
            // 
            // budgetButton
            // 
            budgetButton.BorderColor = Color.DarkOrange;
            budgetButton.BorderRadius = 10;
            budgetButton.BorderThickness = 2;
            budgetButton.CustomizableEdges = customizableEdges5;
            budgetButton.DisabledState.BorderColor = Color.DarkGray;
            budgetButton.DisabledState.CustomBorderColor = Color.DarkGray;
            budgetButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            budgetButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            budgetButton.FillColor = Color.Transparent;
            budgetButton.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            budgetButton.ForeColor = Color.White;
            budgetButton.Location = new Point(45, 193);
            budgetButton.Name = "budgetButton";
            budgetButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            budgetButton.Size = new Size(174, 52);
            budgetButton.TabIndex = 4;
            budgetButton.Text = "Budget";
            budgetButton.Click += budgetButton_Click;
            // 
            // SettingsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 26, 53);
            Controls.Add(budgetButton);
            Controls.Add(profileButton);
            Controls.Add(containerPanel);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Name = "SettingsControl";
            Size = new Size(1097, 879);
            Load += SettingsControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Panel containerPanel;
        private Guna.UI2.WinForms.Guna2Button profileButton;
        private Guna.UI2.WinForms.Guna2Button budgetButton;
    }
}
