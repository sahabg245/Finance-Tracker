using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceTracker.Forms
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void LoadView(UserControl view)
        {
            containerPanel.Controls.Clear();

            // Stretch the control to fill the container area
            view.Dock = DockStyle.Fill;

            // Add it to the panel and bring it to the front
            containerPanel.Controls.Add(view);
            view.BringToFront();

        }
        private void profileButton_Click(object sender, EventArgs e)
        {
            ProfileControl profile = new ProfileControl();
            LoadView(profile);
        }

        private void SettingsControl_Load(object sender, EventArgs e)
        {
            ProfileControl profileControl = new ProfileControl();
            LoadView(profileControl);
        }

        private void budgetButton_Click(object sender, EventArgs e)
        {
            BudgetControl budget = new BudgetControl();
            LoadView(budget);
        }
    }
}
