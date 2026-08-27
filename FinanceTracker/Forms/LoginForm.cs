using FinanceTrackerLibrary.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinanceTrackerLibrary.Models;
using FinanceTracker.Helpers;
using FinanceTrackerLibrary.DataAccess;

namespace FinanceTracker.Forms
{
    public partial class LoginForm : BaseForm
    {

        private readonly AuthLogic _authLogic;
        public LoginForm()
        {
            InitializeComponent();
            _authLogic = new AuthLogic();

        }


        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup signup = new Signup();
            signup.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private async void registerButton_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;


            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                User user = await _authLogic.Login(email, password);

                if (user != null)
                {
                    UserSession.CurrentUser = user;
                    this.Hide();
                    Dashboard dashboardForm = new Dashboard();
                    dashboardForm.Show();

                    InactivityTimer.Start(() =>
                    {
                        UserSession.Logout();

                        if (this.IsHandleCreated)
                        {
                            this.Invoke(() =>
                            {
                                LoginForm loginForm = new LoginForm();
                                loginForm.Show();
                            });
                        }
                    });

                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
