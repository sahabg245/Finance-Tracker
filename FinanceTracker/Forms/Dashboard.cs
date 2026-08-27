using FinanceTracker.Helpers;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Org.BouncyCastle.Asn1.BC;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FinanceTracker.Forms
{
    public partial class Dashboard : BaseForm
    {


        bool sidebarExpand;
        public Dashboard()
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

        private void Dashboard_Load(object sender, EventArgs e)
        {


            showTime.Text = DateTime.Now.ToString("dddd, MMMM dd").ToUpper();


            if (UserSession.CurrentUser != null)
            {
                showName.Text = $"Welcome Back, {UserSession.CurrentUser.FullName} 😉";
            }
            else
            {
                showName.Text = "Welcome Back, User 😉";
            }

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sidebar_timer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sideBar.Width -= 10;
                if (sideBar.Width <= sideBar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebar_timer.Stop();
                }
            }
            else
            {
                sideBar.Width += 10;
                if (sideBar.Width >= sideBar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebar_timer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebar_timer.Start();
        }

        private void sideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showName_Click(object sender, EventArgs e)
        {

        }

        private void addExpense_Click(object sender, EventArgs e)
        {
            AddTransactionForm addForm = new AddTransactionForm();
            addForm.ShowDialog();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void heroPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser != null)
            {
                UserSession.Logout();
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("No user is currently logged in.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SettingsControl settingsControl = new SettingsControl();
            LoadView(settingsControl);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void AddExpense_Click_1(object sender, EventArgs e)
        {
            AddTransactionForm addExpenseForm = new AddTransactionForm();
            addExpenseForm.Show();
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            /*Dashboard dashboard = new Dashboard();
            dashboard.Show();*/
        }

    }
}
