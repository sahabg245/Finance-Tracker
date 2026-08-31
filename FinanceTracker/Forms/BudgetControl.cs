using FinanceTracker.Helpers;
using FinanceTrackerLibrary.Logic;
using Guna.UI2.WinForms;
using Org.BouncyCastle.Tls;
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
    public partial class BudgetControl : UserControl
    {

        private readonly BudgetLogic _budgetLogic;
        public BudgetControl()
        {
            InitializeComponent();
            _budgetLogic = new BudgetLogic();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void saveChanges_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(monthlyBudget.Text.Replace("Rs.","").Trim(), out decimal totalBudget) || totalBudget <= 0)
            {
                MessageBox.Show("Please enter a valid number for the monthly budget.");
                return;
            }

            Dictionary<string, decimal> categoryBudgets = new();

            string[] categories = { "Housing", "Food", "Transport", "Shopping", "Health", "Entertainment", "Utilities", "Other" };

            Guna2TextBox[] budgetTextBoxes = { HousingBudget, foodBudget, transportBudget, shoppingBudget, healthBudget, entertainmentBudget, utilitiesBudget, othersBudget };
            for (int i = 0; i < categories.Length; i++)
            {
                string cleanText = budgetTextBoxes[i].Text.Replace("Rs.", "").Trim();

                if (!decimal.TryParse(cleanText, out decimal limit))
                {
                    MessageBox.Show(
                        $"Please enter a valid amount for {categories[i]}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                categoryBudgets[categories[i]] = limit;
            }

            decimal totalCategories = categoryBudgets.Values.Sum();
            if (totalCategories > totalBudget)
            {
                MessageBox.Show(
                    $"Category budgets total (Rs. {totalCategories:N0}) " +
                    $"exceeds overall budget (Rs. {totalBudget:N0})!\n\n" +
                    "Please adjust your category budgets.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Step 5 - Save to database
                int userId = UserSession.CurrentUser.Id;
                await _budgetLogic.SaveBudget(userId, totalBudget, categoryBudgets);

                MessageBox.Show(
                    "Budget saved successfully! ✅",
                    "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error saving budget: {ex.Message}\n\n" +
                    $"{ex.InnerException?.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BudgetControl_Load(object sender, EventArgs e)
        {
            await LoadBudget();
        }

        public async Task LoadBudget()
        {
            try
            {
                int userId = UserSession.CurrentUser.Id;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;

                var monthlyBudgetText = await _budgetLogic.GetMonthlyBudget(userId, month, year);

                if (monthlyBudgetText != null)
                {
                    this.monthlyBudget.Text = monthlyBudgetText.TotalBudget.ToString();
                }
                else
                {
                    this.monthlyBudget.Text = "0.00";
                }


                var categoryBudgets = await _budgetLogic.GetCategoryBudgets(userId, month, year);

                foreach (var budget in categoryBudgets)
                {
                    switch (budget.Category)
                    {
                        case "Housing":
                            HousingBudget.Text = budget.BudgetLimit.ToString();
                            break;
                        case "Food":
                            foodBudget.Text = budget.BudgetLimit.ToString();
                            break;
                        case "Transport":
                            transportBudget.Text = budget.BudgetLimit.ToString();
                            break;
                        case "Shopping":
                            shoppingBudget.Text = budget.BudgetLimit.ToString();
                            break;
                        case "Health":
                            healthBudget.Text = budget.BudgetLimit.ToString();
                            break;
                        case "Entertainment":
                            entertainmentBudget.Text = budget.BudgetLimit.ToString();
                            break;
                        case "Utilities":
                            utilitiesBudget.Text = budget.BudgetLimit.ToString();
                            break;
                        case "Other":
                            othersBudget.Text = budget.BudgetLimit.ToString();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading budget: {ex.Message}");
            }
        }
    }
}
