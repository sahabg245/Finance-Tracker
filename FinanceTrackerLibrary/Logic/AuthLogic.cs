using FinanceTrackerLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTrackerLibrary.Models;

namespace FinanceTrackerLibrary.Logic
{
    public class AuthLogic
    {
        private readonly UserData _userData;
        public AuthLogic()
        {
            _userData = new UserData();
        }

        public async Task<bool> Register(string fullname, string email, string password)
        {
            var existingUser = await _userData.GetUserByEmail(email);
            if (existingUser != null)
            {
                return false;
            }
            else
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                User user = new User
                {
                    FullName = fullname,
                    Email = email,
                    PasswordHash = hashedPassword,
                    CreatedAt = DateTime.UtcNow
                };

                await _userData.RegisterUser(user);
                return true;
            }


        }
        public async Task<User> Login(string email, string password)
        {
            var user = await _userData.GetUserByEmail(email);

            if (user == null)
            {
                return null;
            }
            else
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
                if (isPasswordValid)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
