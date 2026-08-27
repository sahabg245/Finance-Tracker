using FinanceTracker.Helpers;
using FinanceTrackerLibrary.DataAccess;
using FinanceTrackerLibrary.Logic;
using Guna.UI2.WinForms;
using OpenTK.Audio.OpenAL;
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
    public partial class ProfileControl : UserControl
    {

        private readonly AuthLogic _authLogic;
        public ProfileControl()
        {
            InitializeComponent();
            _authLogic = new AuthLogic();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void userNameDisplay_Click(object sender, EventArgs e)
        {

        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {

            warningLabel.Visible = false;
            if (UserSession.CurrentUser != null)
            {
                userNameDisplay.Text = UserSession.CurrentUser.FullName;
                userEmailDisplay.Text = UserSession.CurrentUser.Email;
            }
        }

        private async void saveChanges_Click(object sender, EventArgs e)
        {
            int UserId = UserSession.CurrentUser.Id;
            bool anyChangeMade = false;


            string userName = txtChangeUsername.Text.Trim();

            if (!string.IsNullOrEmpty(userName) && userName != UserSession.CurrentUser.FullName)
            {
                bool nameUpadated = await _authLogic.UpdateName(UserId, userName);
                
                if (nameUpadated)
                {
                    UserSession.CurrentUser.FullName = userName;
                    anyChangeMade = true;
                    txtChangeUsername.Clear();

                }
            }

            string currPassword = txtCurrentPass.Text;
            string newPassword = txtNewPass.Text;

            if (!string.IsNullOrEmpty(currPassword) || !string.IsNullOrEmpty(newPassword))
            {
                if (string.IsNullOrEmpty(currPassword))
                {
                    warningLabel.Text = "Please enter your current password";
                    warningLabel.Visible = true;
                    return;
                }

                if (string.IsNullOrEmpty(newPassword))
                {
                    warningLabel.Text = "Please enter a new password.";
                    warningLabel.Visible = true;
                    return;
                }

                bool passChanged = await _authLogic.UpdatePassword(UserId, currPassword,newPassword);
                if (passChanged)
                {
                    anyChangeMade = true;
                    warningLabel.Text = "";
                    txtCurrentPass.Clear();
                    txtNewPass.Clear();
                }
                else
                {
                    warningLabel.Text = "Current password is incorrect";
                    warningLabel.Visible = true;
                    return;
                }
            }

            if (anyChangeMade)
            {
                MessageBox.Show("Profile Updated Successfully! ✅", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                userNameDisplay.Text = UserSession.CurrentUser.FullName;
            }
            else
            {
                MessageBox.Show("No changes were made.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
