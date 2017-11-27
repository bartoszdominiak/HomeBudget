using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeBudget.Panels
{
    /// <summary>
    /// Interaction logic for AllExpenses.xaml
    /// </summary>
    public partial class AllExpenses : Page
    {
        private int UserId { get; }
        public AllExpenses(int Id)
        {
            InitializeComponent();
            Page p1 = new InterfacePanel();
            InterfaceFrame.NavigationService.Navigate(p1);

            UserId = Id;
            GetDataToGrid();
        }

        private void InterfaceButton_MouseMove(object sender, MouseEventArgs e)
        {
            InterfaceFrame.Visibility = Visibility.Visible;
            ExpensesButton.Visibility = Visibility.Visible;
            AllExpensesButton.Visibility = Visibility.Visible;
            MenuButton.Visibility = Visibility.Visible;
            MonthPlansButton.Visibility = Visibility.Visible;
            HistoryMonthPlansButton.Visibility = Visibility.Visible;
            CategoriesButton.Visibility = Visibility.Visible;
            IrregularBudgetButton.Visibility = Visibility.Visible;
            SettingsButton.Visibility = Visibility.Visible;
            LogOutButton.Visibility = Visibility.Visible;
        }

        private void InterfaceFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            InterfaceFrame.Visibility = Visibility.Hidden;
            ExpensesButton.Visibility = Visibility.Hidden;
            MenuButton.Visibility = Visibility.Hidden;
            AllExpensesButton.Visibility = Visibility.Hidden;
            MonthPlansButton.Visibility = Visibility.Hidden;
            HistoryMonthPlansButton.Visibility = Visibility.Hidden;
            CategoriesButton.Visibility = Visibility.Hidden;
            IrregularBudgetButton.Visibility = Visibility.Hidden;
            SettingsButton.Visibility = Visibility.Hidden;
            LogOutButton.Visibility = Visibility.Hidden;
        }

        private void ExpensesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ExpensesPanel(UserId, false));
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPanel());
        }

        private void IrregularBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IrregularBudgetPanel(UserId));
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CategoriesPanel(UserId));
        }

        private void MonthPlansButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MonthPlansPanel(UserId));
        }

        private void HistoryMonthPlansButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HistoryMonthPlansPanel(UserId));
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPanel(UserId));
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPanel(UserId));
        }

        private void AllExpensesButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AllExpenses(UserId));
        }

        private void GetDataToGrid()
        {
            DB db = new DB();
            List<Expenses> cat = db.GetAllFromExpenses(UserId);
            foreach (Expenses c in cat)
            {
                ExpensesGrid.Items.Add(c);
            }
        }
        private void GetDataToGridBetweenDate(string from, string to)
        {
            DB db = new DB();
            List<Expenses> cat = db.GetAllFromExpensesBetweenDate(UserId,from,to);
            foreach (Expenses c in cat)
            {
                ExpensesGrid.Items.Add(c);
            }

        }

        private void ModifyExpenses_Click(object sender, RoutedEventArgs e)
        {
            Expenses ex = (Expenses)ExpensesGrid.SelectedItem;
            this.NavigationService.Navigate(new ModifyEpensesPanel(UserId,ex));
        }

        private void DateFromBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DateFromBox_GotFocus(object sender, RoutedEventArgs e)
        {
            CalendarFrom.Visibility = Visibility.Visible;
        }

        private void DateFromBox_LostFocus(object sender, RoutedEventArgs e)
        {
            CalendarFrom.Visibility = Visibility.Hidden;
        }

        private void DateToBox_GotFocus(object sender, RoutedEventArgs e)
        {
            CalendarTo.Visibility = Visibility.Visible;
        }

        private void DateToBox_LostFocus(object sender, RoutedEventArgs e)
        {
            CalendarTo.Visibility = Visibility.Hidden;
        }

        private void CalendarFrom_GotFocus(object sender, RoutedEventArgs e)
        {
            CalendarFrom.Visibility = Visibility.Visible;
        }

        private void CalendarTo_GotFocus(object sender, RoutedEventArgs e)
        {
            CalendarTo.Visibility = Visibility.Visible;
        }

        private void CalendarFrom_LostFocus(object sender, RoutedEventArgs e)
        {
            CalendarFrom.Visibility = Visibility.Hidden;
        }

        private void CalendarTo_LostFocus(object sender, RoutedEventArgs e)
        {
            CalendarTo.Visibility = Visibility.Hidden;
        }

        private void CalendarFrom_MouseLeave(object sender, MouseEventArgs e)
        {
            CalendarFrom.Visibility = Visibility.Hidden;
        }

        private void CalendarTo_MouseLeave(object sender, MouseEventArgs e)
        {
            CalendarTo.Visibility = Visibility.Hidden;
        }

        private void CalendarFrom_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar.SelectedDate.HasValue)
            {
                DateTime date = calendar.SelectedDate.Value;
                DateFromBox.Text = Validation.Validation.GetGoodDate(date.ToShortDateString().ToString());
                CalendarFrom.Visibility = Visibility.Hidden;
            }
        }

        private void CalendarTo_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar.SelectedDate.HasValue)
            {
                DateTime date = calendar.SelectedDate.Value;
                DateToBox.Text = Validation.Validation.GetGoodDate(date.ToShortDateString().ToString());
                CalendarTo.Visibility = Visibility.Hidden;
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            int type = 0;
            if (!Validation.Validation.StringNotNull(DateFromBox.Text))
            {
                type = 1; //nie ma z
            }
            if(!Validation.Validation.StringNotNull(DateToBox.Text))
            {
                if (type == 1)
                {
                    type = 3; //ani jedno ani drugie
                }
                else
                {
                    type = 2; //nie ma do
                }
            }

            if(type==3)
            {
                    ExpensesGrid.Items.Clear();
                    GetDataToGrid();
            }
            if(type==2)
            {
                if (!Validation.Validation.IsValidDateFormat(DateFromBox.Text))
                {
                    MessageBox.Show("Nieprawidłowy format daty");
                    return;
                }
                else
                {
                    ExpensesGrid.Items.Clear();
                    GetDataToGridBetweenDate(DateFromBox.Text, "01-01-3001");
                }
            }
            if (type == 1)
            {
                if (!Validation.Validation.IsValidDateFormat(DateToBox.Text))
                {
                    MessageBox.Show("Nieprawidłowy format daty");
                    return;
                }
                else
                {
                    ExpensesGrid.Items.Clear();
                    GetDataToGridBetweenDate("01-01-1001", DateToBox.Text);
                }
            }
            if(type==0)
            {
                if (!Validation.Validation.IsValidDateFormat(DateFromBox.Text)|| (!Validation.Validation.IsValidDateFormat(DateToBox.Text)))
                {
                    MessageBox.Show("Nieprawidłowy format daty");
                    return;
                }
                else
                {
                    ExpensesGrid.Items.Clear();
                    GetDataToGridBetweenDate(DateFromBox.Text, DateToBox.Text);
                }
            }
        }

        private void DateFromBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CalendarFrom.Visibility = Visibility.Visible;
        }

        private void DateToBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CalendarTo.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Expenses ex = (Expenses)ExpensesGrid.SelectedItem;

            if (MessageBox.Show("Czy na pewno chcesz usunąć wydatek \""+ex.Name+"\"?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                DB db = new Models.DB();
                db.DeleteteExpenditure(ex.ExpRecid);
                this.NavigationService.Navigate(new AllExpenses(UserId));
            }
        }
    }
}
