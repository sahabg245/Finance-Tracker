using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace FinanceTrackerLibrary.DataAccess
{
    public static class DataBaseConfig
    {
        public static string ConnectionString
        {
            get
            {
                Env.Load();
                string server = Env.GetString("DB_SERVER");
                string database = Env.GetString("DB_NAME");
                string user = Env.GetString("DB_USER");
                string password = Env.GetString("DB_PASSWORD");

                return $"Server={server};Database={database};Uid={user};Pwd={password};";
            }
        }
    }
}
