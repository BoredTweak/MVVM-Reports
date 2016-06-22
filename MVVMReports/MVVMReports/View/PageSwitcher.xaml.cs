using System;
using System.Windows;
using System.Windows.Controls;

namespace MVVMReports
{
    public partial class PageSwitcher : Window
    {
        public PageSwitcher()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new BudgetView());
            this.Drop += new DragEventHandler(OnScreenChecker);
        }

        public void Navigate(UserControl nextPage)
        {
            this.PageSwitcherContent.Content = nextPage;
        }

        #region Window UI

        void OnScreenChecker(object sender, EventArgs e)
        {
            IsOnScreen((sender as Window));
        }

        public bool IsOnScreen(Window form)
        {
            System.Windows.Forms.Screen[] screens = System.Windows.Forms.Screen.AllScreens;
            System.Drawing.Rectangle workingSpace = new System.Drawing.Rectangle();
            foreach (System.Windows.Forms.Screen screen in screens)
            {
                workingSpace = System.Drawing.Rectangle.Union(workingSpace, screen.WorkingArea);
            }
            foreach (System.Windows.Forms.Screen screen in screens)
            {
                System.Drawing.Rectangle formRectangle = new System.Drawing.Rectangle((int)form.Left, (int)form.Top, (int)form.Width, (int)form.Height);

                if (workingSpace.Contains(formRectangle))
                {
                    return true;
                }
            }
            this.Left = 0;
            this.Top = 0;
            return false;
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MVVMReports.Properties.Settings.Default.Save();
        }

        private void TitleBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                if (e.ClickCount == 2)
                {
                    AdjustWindowSize();
                }
                else
                {
                    this.DragMove();
                }
            IsOnScreen(this);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
            IsOnScreen(this);
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            IsOnScreen(this);
        }
        
        private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        #endregion

    }
}
