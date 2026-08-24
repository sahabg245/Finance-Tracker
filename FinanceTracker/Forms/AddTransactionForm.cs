using FinanceTrackerLibrary.DataAccess;
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
    public partial class AddTransactionForm : BaseForm
    {
        private readonly TransactionData _transactionData;
        private string selectedCategory = "";

        public AddTransactionForm()
        {
            InitializeComponent();
            _transactionData = new TransactionData();
        }

        private void SetupCategoryButtons()
        {
            houseCategory.Tag="House";
            foodCategory.Tag = "Food";
            transportButton.Tag = "Transport";
            shoppingCategory.Tag = "Shopping";
            healthCategory.Tag = "Health";
            utilitiesCategory.Tag = "Utilities";
            otherCategory.Tag = "Other";
            entertainmentCategory.Tag = "Entertainment";

            Guna.UI2.WinForms.Guna2Button[] categoryButtons = { houseCategory, foodCategory, transportButton, shoppingCategory, healthCategory, utilitiesCategory, otherCategory, entertainmentCategory };
            
            foreach (var button in categoryButtons)
            {
                button.Click += CategoryButton_Click;
            }


        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2Button clickedButton)
            {
                selectedCategory = clickedButton.Tag.ToString();
                clickedButton.FillColor = Color.FromArgb(0, 150, 255); // Highlight selected button
            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void foodCategory_Click(object sender, EventArgs e)
        {

        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {
            SetupCategoryButtons();
        }

        private async void addExpense_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("User not logged in. Please log in to add a transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string title = txtTitle.Text.Trim();
            string amountText = txtAmount.Text.Replace("Rs.","").Replace(",","").Replace("RS.","").Trim();
            DateTime selectedDate = dateTimePick.Value;
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(amountText))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(amountText, out decimal amount)|| amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedCategory))
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Transaction transaction = new Transaction
                {
                    UserId = UserSession.CurrentUser.Id,
                    Title = title,
                    Amount = amount,
                    Description = description,
                    TransactionType = "Expense",
                    Category = selectedCategory,
                    TransactionDate = selectedDate
                };

                await _transactionData.AddTransaction(transaction);
                MessageBox.Show("Expense added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
