using FinanceTrackerLibrary.DataAccess;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace FinanceTracker
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            LiveCharts.Configure(configuration => 
            configuration.AddSkiaSharp()
                .AddDefaultMappers()
                .AddLightTheme()
                );

            Application.Run(new Forms.Signup());
        }
    }
}