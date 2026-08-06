using FinanceTrackerLibrary.DataAccess;

namespace FinanceTracker
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            // Test database connection
            try
            {
                var db = new SqlDataAccess(DataBaseConfig.ConnectionString);
                var result = await db.LoadDataAsync<dynamic>("SELECT 1;");
                MessageBox.Show("Database Connected Successfully!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Connection Failed!\n\n{ex.Message}", "Error");
            }

            Application.Run(new Form1());
        }
    }
}