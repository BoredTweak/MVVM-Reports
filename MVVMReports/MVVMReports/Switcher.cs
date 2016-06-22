using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVMReports
{
    public static class Switcher
    {
        public static PageSwitcher pageSwitcher;
        public static Queue<UserControl> navQueue;
        
        public static void Switch(UserControl entryPage)
        {
            pageSwitcher.Navigate(entryPage);
        }

        public static void Switch(UserControl newPage, UserControl currentPage)
        {
            UserControl lastPage = currentPage;
            string lastHeader = pageSwitcher.HeaderText.Text;
            if (navQueue == null)
            {
                navQueue = new Queue<UserControl>();
            }
            navQueue.Enqueue(lastPage);

            pageSwitcher.Navigate(newPage);
        }

        public static void Back()
        {
            UserControl lastPage = navQueue.Dequeue();
            pageSwitcher.Navigate(lastPage);
        }
    }
}
