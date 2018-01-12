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
    /// Interaction logic for HistoryMonthPlansPanel.xaml
    /// </summary>
    public partial class HistoryMonthPlansPanel : Page
    {
        private int UserId { get; }
        private int Year = 0;
        private int Month = 0;
        private MonthPlans monthplans;
        private List<CategoryPlan> cat = new List<CategoryPlan>();
        bool first = true;

        public HistoryMonthPlansPanel(int Id)
        {
            InitializeComponent();
            Page p1 = new InterfacePanel();
            InterfaceFrame.NavigationService.Navigate(p1);

            UserId = Id;
            DateTime localDate = DateTime.Now;
            Month = Validation.Validation.GetMonthFromDate(localDate.ToString());
            Year = Validation.Validation.GetYearFromDate(localDate.ToString());
            YearBox.Text = Convert.ToString(Year);
            monthplans = new MonthPlans(UserId.ToString());
            GetMonths(Month);
            MonthPlanExist();
            first = false;
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


        private void MonthPlanExist()
        {
            DB db = new DB();
            if (db.CheckMonthPlan(UserId, Year, Month))
            {
                MonthPlans mp = db.GetMonthPlan(UserId.ToString(), Year.ToString(), Month.ToString());
                monthplans = mp;
                cat.Clear();
                cat = db.GetCategoryPlanWithSum(Convert.ToInt16(mp.__recid),Month,Year);
                MonthBudgetGrid.ItemsSource = cat;
                EarningsBox.Text = monthplans.Earning;
                IrregularBudgetBox.Text = monthplans.IrregularBudgetFund;
            }
            else
            {
                List<CategoryPlan> EmptyList = new List<CategoryPlan>();
                MonthBudgetGrid.ItemsSource=EmptyList;
                EarningsBox.Text = "0,00";
                IrregularBudgetBox.Text = "0,00";
                if(first==false)
                MessageBox.Show("Nie zaplanowano budżetu na ten miesiąc");
            }

        }

        private void MonthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;
            Dictionary<int, string> mon = new Dictionary<int, string>();
            mon = DictionaryGenerator.GetMonths();
            foreach (KeyValuePair<int, string> kvp in mon)
            {
                if (kvp.Value == text)
                {
                    Month = kvp.Key;
                    break;
                }
            }
            MonthPlanExist();

        }
        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
            MonthPlanExist();
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
            MonthPlanExist();
        }

        public int NumValue
        {
            get { return Year; }
            set
            {
                Year = value;
                YearBox.Text = value.ToString();
            }
        }

        private void GetMonths(int month)
        {
            Dictionary<int, string> mon = new Dictionary<int, string>();
            mon = DictionaryGenerator.GetMonths();
            foreach (KeyValuePair<int, string> kvp in mon)
            {
                MonthComboBox.Items.Add(kvp.Value);
                if (kvp.Key == month)
                {
                    MonthComboBox.SelectedItem = kvp.Value;
                }
            }

        }
    }
}
