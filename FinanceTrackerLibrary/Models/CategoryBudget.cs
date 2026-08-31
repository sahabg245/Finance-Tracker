using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerLibrary.Models
{
    public class CategoryBudget
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public decimal BudgetLimit { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
