using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FinanceTrackerLibrary.Models;

namespace FinanceTrackerLibrary.DataAccess
{
    public class UserData
    {
        private readonly SqlDataAccess _dbString;

        public UserData()
        {
            _dbString = new SqlDataAccess(DataBaseConfig.ConnectionString);
        }

        public async Task RegisterUser(User user)
        {
            var sql = "INSERT INTO Users (FullName, Email, PasswordHash) VALUES (@FullName, @Email, @PasswordHash)";
            await _dbString.SaveDataAsync(sql, user);
        }

        public async Task <User> GetUserByEmail(string email)
        {
            string sql = "select * from Users where Email=@Email";
            var result = await _dbString.LoadDataAsync<User>(sql, new { Email = email });
            if (result == null || !result.Any())
            {
                return null;
            }
            return result.FirstOrDefault();
        }


        public async Task <User> GetUserById(int userId)
        {
            string sql = @"select * from Users 
                        where Id= @Id";

            var result = await _dbString.LoadDataAsync<User>(sql, new { Id = userId });
            return result.FirstOrDefault();
        }

        public async Task UpdateFullname(int userId, string newName)
        {
            string sql = @"update Users
                          set FullName=@FullName
                          where Id = @Id";

            await _dbString.SaveDataAsync(sql, new { FullName = newName , Id = userId });
        }

        public async Task UpdatePassword(int userId, string newPassword)
        {
            string sql = @"update Users 
                           set PasswordHash=@PasswordHash
                           where Id= @Id";

            await _dbString.SaveDataAsync(sql,new { PasswordHash = newPassword ,Id = userId });
        }
    }
}
