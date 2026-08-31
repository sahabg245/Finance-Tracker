using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerLibrary.Models
{
    public class MonthlyBudget
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalBudget { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
