using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Data;
using System;
using System.Windows.Input;
using MVVMReports.Model;

namespace MVVMReports.ViewModel
{
    public class ExpenseViewModel : INotifyPropertyChanged
    {
        public void ResetExpense()
        {
            NewExpense = new Expense();
            DueDate = DateTime.Today;
            Amount = 0f;
            Note = "";
            Category = "";
        }

        public DateTime DueDate
        {
            get
            {
                if (NewExpense == null)
                {
                    NewExpense = new Expense("", 0f, DateTime.Today);
                }
                return NewExpense.DueDate;
            }
            set
            {
                if (NewExpense == null)
                {
                    NewExpense = new Expense("", 0f, DateTime.Today);
                }
                NewExpense.DueDate = value;
                RaisePropertyChanged("DueDate");
            }
        }

        public float Amount
        {
            get
            {
                if (NewExpense == null)
                {
                    NewExpense = new Expense("", 0f, DateTime.Today);
                }
                return NewExpense.Amount;
            }
            set
            {
                if (NewExpense == null)
                {
                    NewExpense = new Expense("", 0f, DateTime.Today);
                }
                NewExpense.Amount = value;
                RaisePropertyChanged("Amount");
            }
        }

        public string Note
        {
            get
            {
                if (NewExpense == null)
                {
                    NewExpense = new Expense("", 0f, DateTime.Today);
                }
                return NewExpense.Note;
            }
            set
            {
                if (NewExpense == null)
                {
                    NewExpense = new Expense("", 0f, DateTime.Today);
                }
                NewExpense.Note = value;
                RaisePropertyChanged("Note");
            }
        }

        public string Category
        {
            get
            {
                if (NewExpense == null)
                {
                    NewExpense = new Expense("", 0f,DateTime.Today);
                }
                return NewExpense.Category;
            }
            set
            {
                if (NewExpense == null)
                {
                    NewExpense = new Expense("", 0f, DateTime.Today);
                }
                NewExpense.Category = value;
                RaisePropertyChanged("Category");
            }
        }

        private Expense newExpense;
        public Expense NewExpense
        {
            get
            {

                return newExpense;
            }
            set
            {
                newExpense = value;
                RaisePropertyChanged("Expense");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
