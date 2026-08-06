namespace FinanceTrackerLibrary.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }         // "Income" or "Expense"
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
