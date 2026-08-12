using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTrackerLibrary.Models;

namespace FinanceTracker.Helpers
{
    public class UserSession
    {
        public static User CurrentUser { get; set; }
        public static bool LogIn()
        {
            return CurrentUser != null;
        }
        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
