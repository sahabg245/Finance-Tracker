using FinanceTrackerLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTrackerLibrary.Models;

namespace FinanceTrackerLibrary.Logic
{
    public class BudgetLogic
    {
        private readonly BudgetData _budgetData;

        public BudgetLogic()
        {
            _budgetData = new BudgetData();
        }

        public async Task SaveBudget(int userId, decimal totalBudget, Dictionary<string, decimal> categoryBudgets)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            await _budgetData.SetMonthlyBudget(new MonthlyBudget
            {
                UserId = userId,
                TotalBudget = totalBudget,
                Month = month,
                Year = year
            });

            foreach (var catBudget in categoryBudgets)
            {
                await _budgetData.SetCategoryBudget(new CategoryBudget
                {
                    UserId = userId,
                    Category = catBudget.Key,
                    BudgetLimit = catBudget.Value,
                    Month = month,
                    Year = year
                });
            }
        }
        public bool IsOverBudget(string category, decimal spent, List<CategoryBudget> budgets)
        {
            var budget = budgets.FirstOrDefault(b => b.Category == category);

            if (budget == null) return false;
            return spent > budget.BudgetLimit;
        }

        public decimal GetCategoryRemaining(string category, decimal spent, List<CategoryBudget> budgets)
        {
            var budget = budgets.FirstOrDefault(b => b.Category == category);

            if (budget == null) return 0;
            return budget.BudgetLimit - spent;
        }

        public async Task<MonthlyBudget> GetMonthlyBudget(int userId, int month, int year)
        {
            return await _budgetData.GetMonthlyBudget(userId, month, year);
        }

        public async Task<List<CategoryBudget>> GetCategoryBudgets(int userId, int month, int year)
        {
            return await _budgetData.GetCategoryBudgets(userId, month, year);
        }
    }
}
