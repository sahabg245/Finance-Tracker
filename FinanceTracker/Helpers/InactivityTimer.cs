using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Helpers
{
    public static class InactivityTimer
    {
        private static System.Windows.Forms.Timer _timer;
        private static Action _onTimeOut;
        private const int TimeOut = 10 * 60 * 1000; // 10 minutes in milliseconds


        public static void Start(Action onTimeOut)
        {
            _onTimeOut = onTimeOut;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = TimeOut;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        public static void Reset()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Start();
            }
        }

        public static void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Tick -= Timer_Tick;
                _timer.Dispose();
                _timer = null;
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _onTimeOut?.Invoke();
        }
    }
}
