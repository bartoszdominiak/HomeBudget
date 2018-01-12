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
    /// Interaction logic for SettingsPanel.xaml
    /// </summary>
    public partial class SettingsPanel : Page
    {
        private int UserId { get; }
        private List<Settings> settings { get; set; } = new List<Settings>();
        public SettingsPanel(int Id)
        {
            InitializeComponent();
            Page p1 = new InterfacePanel();
            InterfaceFrame.NavigationService.Navigate(p1);

            UserId = Id;

            DB db = new DB();
            settings= db.GetAllFromSettings(UserId);
            if(settings.Count==0)
            {
                MessageBox.Show("Brak danych z ustawieniami. Skontaktuj się z administratorem.");
                this.NavigationService.Navigate(new MenuPanel(UserId));
            }
            else
            {
                StartsSavingBox.Text= Validation.Validation.GetNumberTwoZero(settings[0].StartsSaving);
                EarningsBox.Text = Validation.Validation.GetNumberTwoZero(settings[0].Earnings);
                
            }
            
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

        private void StartsSavingBox_LostFocus(object sender, RoutedEventArgs e)
        {
            StartsSavingBox.Text = Validation.Validation.GetNumberWithDot(StartsSavingBox.Text.Trim());
        }
        private void EarningsBox_LostFocus(object sender, RoutedEventArgs e)
        {
            EarningsBox.Text = Validation.Validation.GetNumberWithDot(EarningsBox.Text.Trim());
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if(settings[0].HaveChanged(StartsSavingBox.Text, EarningsBox.Text))
            {
                DB db = new Models.DB();
                if (db.UpdateSettings(UserId, StartsSavingBox.Text.Replace(',','.'), EarningsBox.Text.Replace(',', '.')))
                {
                    settings.Clear();
                    settings.Add(new Settings(StartsSavingBox.Text, EarningsBox.Text));
                    MessageBox.Show("Modyfikacja zakończona");
                }

                else
                {
                    MessageBox.Show("Ups. Coś poszło nie tak.");
                }
            }
            else
            {
                MessageBox.Show("Modyfikacja zakończona");
            }
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
