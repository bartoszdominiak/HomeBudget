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
    /// Interaction logic for ExpensesPanel.xaml
    /// </summary>
    public partial class ExpensesPanel : Page
    {
        private int UserId { get; }
        public ExpensesPanel(int Id,bool added)
        {
            InitializeComponent();

            UserId = Id;
            //global = new Global();
            Page p1 = new InterfacePanel();
            InterfaceFrame.NavigationService.Navigate(p1);

            DB db = new DB();
            string FirstCat = db.GetUserFirstCat(UserId);
            int CatExist = -1;
            int temp = 0;
            List<string> categories = db.GetCategoriesName(UserId);
            foreach(string cat in categories)
            {
                CategoryComboBox.Items.Add(cat);
                if (cat == FirstCat) CatExist = temp;
                temp++;
            }
            if (CatExist < 0) CategoryComboBox.SelectedIndex = 0;
            else CategoryComboBox.SelectedIndex = CatExist;


            if (added==true)
            {
                Added.Content = "Dodano wydatek";
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

        private void DateBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Calendar.Visibility = Visibility.Visible;
        }

        private void DateBox_LostFocus(object sender, RoutedEventArgs e)
        { 
            Calendar.Visibility = Visibility.Hidden; 
        }

        private void Calendar_GotFocus(object sender, RoutedEventArgs e)
        {
            Calendar.Visibility = Visibility.Visible;
        }

        private void Calendar_LostFocus(object sender, RoutedEventArgs e)
        {
            Calendar.Visibility = Visibility.Hidden;
        }

        private void Calendar_MouseLeave(object sender, MouseEventArgs e)
        {
            Calendar.Visibility = Visibility.Hidden;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar.SelectedDate.HasValue)
            {
                DateTime date = calendar.SelectedDate.Value;
                DateBox.Text=Validation.Validation.GetGoodDate(date.ToShortDateString().ToString());
                Calendar.Visibility = Visibility.Hidden;
            }

        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Added.Content = "";
            if (!Validation.Validation.StringNotNull(NameBox.Text))
            {
                AddFail.Content = "Wprowadź opis";
                return;
            }
            if (!Validation.Validation.StringNotNull(DateBox.Text))
            {
                AddFail.Content = "Wprowadź datę";
                return;
            }
            if (!Validation.Validation.StringNotNull(AmountBox.Text))
            {
                AddFail.Content = "Wprowadź kwotę";
                return;
            }
            int myInt;
            if (int.TryParse(AmountBox.Text, out myInt) && (myInt < 0))
            {
                AddFail.Content = Convert.ToDecimal(AmountBox.Text) + "Kwota nie może być mniejsza niz zero";
                return;
            }
            if (!Validation.Validation.NotLongerThen(NameBox.Text, 100))
            {
                AddFail.Content = "Opis może mieć do 100 znaków";
                return;
            }
            if (!Validation.Validation.IsValidDateFormat(DateBox.Text))
            {
                AddFail.Content = "Nieprawidłowy format daty";
                return;
            }
            if (!Validation.Validation.IsGreaterOrEqualThenZero(Convert.ToDecimal(AmountBox.Text))) 
            {
                AddFail.Content = "Kwota nie może być ujemna";
                return;
            }
            else
            {
                DB db = new DB();
                int CategoryId = db.GetCategoryRecid(UserId, CategoryComboBox.Text);
                if(CategoryId==-2)
                {
                    AddFail.Content = "Nieprawidłowy format danych";
                    return;
                }
                else
                {
                    if(!db.InsertExpenditure(UserId,NameBox.Text,AmountBox.Text,DateBox.Text,CategoryId))
                    {
                        AddFail.Content = "Nieprawidłowy format danych";
                        return;
                    }
                    else
                    {
                        this.NavigationService.Navigate(new ExpensesPanel(UserId,true));
                    }
                }
            }
        }

        private void AddButton_Click()
        {
            Added.Content = "";
            if (!Validation.Validation.StringNotNull(NameBox.Text))
            {
                AddFail.Content = "Wprowadź opis";
                return;
            }
            if (!Validation.Validation.StringNotNull(DateBox.Text))
            {
                AddFail.Content = "Wprowadź datę";
                return;
            }
            if (!Validation.Validation.StringNotNull(AmountBox.Text))
            {
                AddFail.Content = "Wprowadź kwotę";
                return;
            }
            int myInt;
            if (int.TryParse(AmountBox.Text, out myInt) && (myInt < 0))
            {
                AddFail.Content = Convert.ToDecimal(AmountBox.Text) + "Kwota nie może być mniejsza niz zero";
                return;
            }
            if (!Validation.Validation.NotLongerThen(NameBox.Text, 100))
            {
                AddFail.Content = "Opis może mieć do 100 znaków";
                return;
            }
            if (!Validation.Validation.IsValidDateFormat(DateBox.Text))
            {
                AddFail.Content = "Nieprawidłowy format daty";
                return;
            }
            if (!Validation.Validation.IsGreaterOrEqualThenZero(Convert.ToDecimal(AmountBox.Text)))
            {
                AddFail.Content = "Kwota nie może być ujemna";
                return;
            }
            else
            {
                DB db = new DB();
                int CategoryId = db.GetCategoryRecid(UserId, CategoryComboBox.Text);
                if (CategoryId == -2)
                {
                    AddFail.Content = "Nieprawidłowy format danych";
                    return;
                }
                else
                {
                    if (!db.InsertExpenditure(UserId, NameBox.Text, AmountBox.Text, DateBox.Text, CategoryId))
                    {
                        AddFail.Content = "Nieprawidłowy format danych";
                        return;
                    }
                    else
                    {
                        this.NavigationService.Navigate(new ExpensesPanel(UserId, true));
                    }
                }
            }
        }

        private void AmountBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AmountBox_LostFocus(object sender, RoutedEventArgs e)
        {
            AmountBox.Text = Validation.Validation.GetNumberWithDot(AmountBox.Text.Trim());
        }

        private void DateBox_MouseLeave(object sender, MouseEventArgs e)
        {
            //Calendar.Visibility = Visibility.Hidden;
        }

        private void DateBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Calendar.Visibility = Visibility.Visible;
        }

        private void DateBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Calendar.Visibility = Visibility.Visible;
        }

        private void AmountBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddButton_Click();
            }
        }
    }
}
