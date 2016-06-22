using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Data;
using System;

namespace MVVMReports
{
    public class BudgetViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Test WPF for proper loading
        /// </summary>
        public BudgetViewModel()
        {
            budgetViewSource = new CollectionViewSource();

            List<Expense> test = new List<Expense>();
            Expense data = new Expense("Gas", 4.5f, DateTime.Today);
            Expense data2 = new Expense("Redbull", 2.5f, DateTime.Today);
            Expense data3 = new Expense("Dog", 450f, DateTime.Today, "No regrets");
            test.Add(data);
            test.Add(data2);
            test.Add(data3);
            Expenses = test;
        }

        /// <summary>
        /// Construct listviewmodel from list of blockinfo
        /// </summary>
        /// <param name="blockInfoList"></param>
        public BudgetViewModel(List<Expense> expenseList)
        {
            budgetViewSource = new CollectionViewSource();
        }

        internal CollectionViewSource budgetViewSource { get; set; }
        public ICollectionView AllBudgetItems
        {
            get
            {
                return budgetViewSource.View;
            }
        }

        private string filter;
        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                OnFilterChanged();
            }
        }

        private void OnFilterChanged()
        {
            budgetViewSource.View.Refresh();
        }

        private List<Expense> expenses;
        public List<Expense> Expenses
        {
            get
            {
                return expenses;
            }
            set
            {
                expenses = value;
                SetFilteredPurchaseOrders();
                RaisePropertyChanged("Expenses");
            }
        }

        private void SetFilteredPurchaseOrders()
        {
            budgetViewSource = new CollectionViewSource();
            budgetViewSource.Source = Expenses;
            budgetViewSource.Filter += ExpenseFilter;
        }

        private void ExpenseFilter(object sender, FilterEventArgs e)
        {
            Expense test = ((Expense)(e.Item));

            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
            {
                e.Accepted = true;
            }
            else if (test.Category.Contains(Filter, StringComparison.OrdinalIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
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
