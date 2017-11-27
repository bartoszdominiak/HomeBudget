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
    /// Interaction logic for IrregularBudgetPanel.xaml
    /// </summary>
    public partial class IrregularBudgetPanel : Page
    {
        private int UserId { get; }
        private int __recid { get; set; }
        public IrregularBudgetPanel(int Id)
        {
            InitializeComponent();

            Page p1 = new InterfacePanel();
            InterfaceFrame.NavigationService.Navigate(p1);

            UserId = Id;

            GetDataToGrid();
        }

        private void GetDataToGrid()
        {
            DB db = new DB();
            List<IrregularBudget> cat = db.GetAllFromIrregularBudget(UserId);
            foreach (IrregularBudget c in cat)
            {
                IrregularExpensesGrid.Items.Add(c);
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.Validation.StringNotNull(NameBox.Text))
            {
                MessageBox.Show("Uzupełnij nazwy kategorii");
                return;
            }
            if (!Validation.Validation.NotLongerThen(NameBox.Text, 100))
            {
                MessageBox.Show("Nazwa kategorii może mieć do 100 znaków");
                return;
            }
            if(!Validation.Validation.IsGreaterOrEqualThenZero(Validation.Validation.GetDecimal(AmountBox.Text)))
            {
                MessageBox.Show("Kwota musi być większa lub równa zero");
                return;
            }
            DB db = new Models.DB();
            if(!db.InsertIrregularBudget(UserId,NameBox.Text,AmountBox.Text))
            {
                MessageBox.Show("Ups... coś poszło nie tak :(");
                return;
            }
            else
            {
                this.NavigationService.Navigate(new IrregularBudgetPanel(UserId));
            }

        }

        private void AmountBox_LostFocus(object sender, RoutedEventArgs e)
        {
            AmountBox.Text = Validation.Validation.GetNumberWithDot(AmountBox.Text.Trim());
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            InfoLabel.Content = "Modyfikuj wydatek:";
            AddButton.Visibility = Visibility.Hidden;
            ModifyButton.Visibility = Visibility.Visible;
            BackButton.Visibility = Visibility.Visible;

            AddButton.Visibility = Visibility.Hidden;
            IrregularBudget cat = (IrregularBudget)IrregularExpensesGrid.SelectedItem;
            //MessageBox.Show("Zawartość wiersza "+cat.Name.ToString() +cat.Descript.ToString() + cat.Color.ToString());
            NameBox.Text = cat.Name.ToString();
            AmountBox.Text = cat.Amount.ToString();
            __recid = cat.__recid;
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.Validation.StringNotNull(NameBox.Text))
            {
                MessageBox.Show("Uzupełnij nazwy kategorii");
                return;
            }
            if (!Validation.Validation.NotLongerThen(NameBox.Text, 100))
            {
                MessageBox.Show("Nazwa kategorii może mieć do 100 znaków");
                return;
            }
            if (!Validation.Validation.IsGreaterOrEqualThenZero(Validation.Validation.GetDecimal(AmountBox.Text)))
            {
                MessageBox.Show("Kwota musi być większa lub równa zero");
                return;
            }
            DB db = new DB();
            if(!db.UpdateIrregularBudget(UserId, NameBox.Text,AmountBox.Text, __recid))
            {
                MessageBox.Show("Ups... Coś poszło nie tak :(");
                return;
            }
            else
            {
                this.NavigationService.Navigate(new IrregularBudgetPanel(UserId));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Info2Label.Content = "Dodawanie nowego wydatku nieregularnego:";
            AddButton.Visibility = Visibility.Visible;
            ModifyButton.Visibility = Visibility.Hidden;
            BackButton.Visibility = Visibility.Hidden;
            NameBox.Text = "";
            AmountBox.Text = "";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            IrregularBudget ex = (IrregularBudget)IrregularExpensesGrid.SelectedItem;
            if (MessageBox.Show("Czy na pewno chcesz usunąć wydatek \"" + ex.Name + "\"?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                DB db = new Models.DB();
                if(!db.DeleteteIrregularBudget(ex.__recid))
                {
                    MessageBox.Show("Ups... Coś poszło nie tak");
                    return;
                }
                this.NavigationService.Navigate(new IrregularBudgetPanel(UserId));
            }
        }
    }
}
