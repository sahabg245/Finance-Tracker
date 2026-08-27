using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FinanceTrackerLibrary.Models;

namespace FinanceTrackerLibrary.DataAccess
{
    public class TransactionData
    {
        private readonly SqlDataAccess _db;

        public TransactionData()
        {
            _db = new SqlDataAccess(DataBaseConfig.ConnectionString);
        }

        public async Task AddTransaction(Transaction transaction)
        {
            try
            {
                string sql = @"insert into Transactions (UserId, Title, Amount, TransactionType, Category, Description, TransactionDate) values
                (@UserId, @Title, @Amount, @TransactionType, @Category, @Description, @TransactionDate)";

                await _db.SaveDataAsync(sql, transaction);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding transaction: {ex.Message}");

                throw;
            }

        }

        public async Task<List<Transaction>> GetAllTransaction(int userId)
        {
            try
            {

                string sql = @"select * from Transaction
                           where UserId = @UserId
                           order by TransactionDate desc";

                return await _db.LoadDataAsync<Transaction>(sql, new { UserId = userId });

            }
            catch (Exception ex)
            {
                return new List<Transaction>();
            }
        }

        public async Task<List<Transaction>> GetTransactionsByType(int userId, string type)
        {
            try
            {
                string sql = @"select * from Transaction
                        where UserID = @UserId and TransationType = @TransactionType
                        order by TransactionDate desc";
                return await _db.LoadDataAsync<Transaction>(sql, new { UserId = userId, TransactionType = type });
            }
            catch (Exception ex)
            {
                return new List<Transaction>();
            }

        }
    }
}
