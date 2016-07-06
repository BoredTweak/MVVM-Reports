using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMReports.Model
{
    public class Expense
    {
        public string Category { get; set; }
        public float Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Note { get; set; }

        public Expense(string category, float amount, DateTime date, string note = "")
        {
            this.Category = category;
            this.Amount = amount;
            this.DueDate = date;
            this.Note = note;
        }

        public Expense()
        {

        }
    }
}
