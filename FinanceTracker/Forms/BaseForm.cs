using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinanceTracker.Helpers;

namespace FinanceTracker.Forms
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.MouseMove += (s, e) => InactivityTimer.Reset();
            this.KeyPress += (s, e) => InactivityTimer.Reset();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InactivityTimer.Reset();

        }
    }
}
