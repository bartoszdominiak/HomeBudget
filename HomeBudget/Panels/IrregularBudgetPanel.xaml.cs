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
    /// Interaction logic for IrregularBudgetPanel.xaml
    /// </summary>
    public partial class IrregularBudgetPanel : Page
    {
        private int UserId { get; }
        public IrregularBudgetPanel(int Id)
        {
            InitializeComponent();
        }

        private void InterfaceButton_MouseMove(object sender, MouseEventArgs e)
        {
            InterfaceFrame.Visibility = Visibility.Visible;
            ExpensesButton.Visibility = Visibility.Visible;
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
            MonthPlansButton.Visibility = Visibility.Hidden;
            HistoryMonthPlansButton.Visibility = Visibility.Hidden;
            CategoriesButton.Visibility = Visibility.Hidden;
            IrregularBudgetButton.Visibility = Visibility.Hidden;
            SettingsButton.Visibility = Visibility.Hidden;
            LogOutButton.Visibility = Visibility.Hidden;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void ExpensesButton_Click(object sender, RoutedEventArgs e)
        {
            InterfaceFrame.Visibility = Visibility.Hidden;
            ExpensesButton.Visibility = Visibility.Hidden;
            MonthPlansButton.Visibility = Visibility.Hidden;
            HistoryMonthPlansButton.Visibility = Visibility.Hidden;
            CategoriesButton.Visibility = Visibility.Hidden;
            IrregularBudgetButton.Visibility = Visibility.Hidden;
            SettingsButton.Visibility = Visibility.Hidden;
            LogOutButton.Visibility = Visibility.Hidden;
            this.NavigationService.Navigate(new ExpensesPanel(UserId));
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
    }
}
