using FinanceTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerLibrary.DataAccess
{
    public class BudgetData
    {
        private readonly SqlDataAccess _db;

        public BudgetData()
        {
            _db = new SqlDataAccess(DataBaseConfig.ConnectionString);
        }

        public async Task SetMonthlyBudget(MonthlyBudget monthlyBudget)
        {
            string sql = @"Insert into MonthlyBudget (UserId, TotalBudget, Month, Year) Values
                          (@UserId, @TotalBudget, @Month, @Year) 
                          On Duplicate key Update 
                          TotalBudget = @TotalBudget";

            await _db.SaveDataAsync(sql, monthlyBudget);
        }

        public async Task<MonthlyBudget> GetMonthlyBudget(int userId, int month, int year)
        {
            string sql = @"Select * from MonthlyBudget where UserId = @UserId and Month = @Month and Year = @Year";
            var result = await _db.LoadDataAsync<MonthlyBudget>(sql, new { UserId = userId, Month = month, Year = year });
            return result.FirstOrDefault();
        }

        public async Task SetCategoryBudget(CategoryBudget categoryBudget)
        {
            string sql = @"Insert into CategoryBudgets (UserId, Category, BudgetLimit, Month, Year) Values
                          (@UserId, @Category, @BudgetLimit, @Month, @Year) 
                          On Duplicate key Update 
                          BudgetLimit = @BudgetLimit";
            await _db.SaveDataAsync(sql, categoryBudget);
        }

        public async Task<List<CategoryBudget>> GetCategoryBudgets(int userId, int month, int year)
        {
            string sql = @"Select * from CategoryBudgets where UserId = @UserId and Month = @Month and Year = @Year";
            var result = await _db.LoadDataAsync<CategoryBudget>(sql, new { UserId = userId, Month = month, Year = year });
            return result;
        }
        public async Task DeleteCategoryBudget(int id)
        {
            string sql = "DELETE FROM CategoryBudgets WHERE Id = @Id;";
            await _db.SaveDataAsync(sql, new { Id = id });
        }
    }
}