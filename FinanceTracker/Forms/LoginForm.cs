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

namespace FinanceTracker.Forms
{
    public partial class LoginForm : Form
    {

        private readonly AuthLogic _authLogic;
        public LoginForm()
        {
            InitializeComponent();
            _authLogic = new AuthLogic();

        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();
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

                    InactivityTimer.Start(() =>
                    {
                        MessageBox.Show("You have been logged out due to inactivity.", "Session Timeout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserSession.Logout();

                        this.Invoke(()=>
                        {
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                        });
                    });
                    MessageBox.Show($"Login Successful!\n\n" +
                                        $"User ID: {user.Id}\n" +
                                        $"Name: {user.FullName}\n" +
                                        $"Email: {user.Email}\n" +
                                        $"Timer Started: 1 minute inactivity timeout",
                                        "Session Started ✅",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
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
    }
}
