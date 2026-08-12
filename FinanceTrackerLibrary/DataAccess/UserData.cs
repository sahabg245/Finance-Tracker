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
            var sql = "INSERT INTO Users (FullName, Email, PasswordHash) VALUES (@Fullname, @Email, @PasswordHash)";
            await _dbString.SaveDataAsync(sql, user);
        }

        public async Task <User> GetUserByEmail(string email)
        {
            string sql = "select * from Users where Email=@Email";
            var result = await _dbString.LoadDataAsync<User>(sql, new { Email = email });
            return result.FirstOrDefault();
        }
    }
}
