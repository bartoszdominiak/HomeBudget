using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for CategoriesPanel.xaml
    /// </summary>
    /// 
    public partial class CategoriesPanel : Page
    {
        private int UserId { get; }
        private string TempName { get; set; }

        public CategoriesPanel(int Id)
        {
            InitializeComponent();
            Page p1 = new InterfacePanel();
            InterfaceFrame.NavigationService.Navigate(p1);

            UserId = Id;

            GetDataToGrid();
            this.colorList1.ItemsSource = typeof(Brushes).GetProperties();

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
            List<Categories> cat = db.GetAllFromCategories(UserId);
            foreach (Categories c in cat)
            {
                CategoryGrid.Items.Add(c);
            }
        }


        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("TODO. Brak możliwości usunięcia rekordu");
            Categories ex = (Categories)CategoryGrid.SelectedItem;
            DB db = new Models.DB();
            string count = db.GetNumberExpensesInCaterory(UserId.ToString(), ex.Name);
            if(count!="0")
            {
                MessageBox.Show("Nie można usuwać kategorii dla których istnieją wydatki.");
                return;
            }
            else
            {
                if(db.GetNumberCategoryPlansWithCategory(UserId.ToString(),ex.Name)!="0")
                {
                    MessageBox.Show("Nie można usuwać kategorii dla których zaplanowany jest już budżet.");
                    return;
                }

                List<Categories> cat = db.GetAllFromCategories(UserId);
                if(cat.Count<=5)
                {
                    MessageBox.Show("Musisz mieć przynajmniej pięć kategorii wydatków.");
                    return;
                }

                if (db.DeleteteCategory(UserId.ToString(),ex.Name))
                {
                    MessageBox.Show("Usunięto kategorię.");
                    this.NavigationService.Navigate(new CategoriesPanel(UserId));
                }
                else
                {
                    MessageBox.Show("Nie udało się usunąć kategorii.");
                    return;
                }
            }

        }


        private void ColorCategory1_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Visible;
        }
        private void colorList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            ColorCategory1.Background = selectedColor;
            colorList1.Visibility = Visibility.Hidden;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.Validation.StringNotNull(NameCategory1.Text))
            {
                MessageBox.Show("Uzupełnij nazwy kategorii");
                return;
            }
            if (!Validation.Validation.NotLongerThen(NameCategory1.Text, 100))
            {
                MessageBox.Show("Nazwa kategorii może mieć do 100 znaków");
                return;
            }
            if (!Validation.Validation.NotLongerThen(DescriptionCategory1.Text, 100))
            {
                MessageBox.Show("Opis kategorii może mieć do 100 znaków");
                return;
            }
            DB db = new DB();
            if (!db.InsertCategory(UserId, NameCategory1.Text, DescriptionCategory1.Text, ColorCategory1.Background.ToString(), false))
            {
                MessageBox.Show("UPS. Coś poszło nie tak :(");
                return;
            }
            else
            {
                Categories cat = new Categories(NameCategory1.Text, DescriptionCategory1.Text, ColorCategory1.Background.ToString());
                CategoryGrid.Items.Add(cat);
            }
        }
        private void ModifyCategory_Click(object sender, RoutedEventArgs e)
        {
            ModifyButton.Visibility = Visibility.Visible;
            ChangeButton.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Hidden;
            Categories cat = (Categories)CategoryGrid.SelectedItem;
            //MessageBox.Show("Zawartość wiersza "+cat.Name.ToString() +cat.Descript.ToString() + cat.Color.ToString());
            NameCategory1.Text = cat.Name.ToString();
            DescriptionCategory1.Text = cat.Descript.ToString();
            TempName= cat.Name.ToString();

            var bc = new BrushConverter();
            ColorCategory1.Background = (Brush)bc.ConvertFrom(cat.Color.ToString());


        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            ModifyButton.Visibility = Visibility.Hidden;
            ChangeButton.Visibility = Visibility.Hidden;
            AddButton.Visibility = Visibility.Visible;
            NameCategory1.Text = "";
            DescriptionCategory1.Text = "";
            ColorCategory1.Background = Brushes.Yellow;
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.Validation.StringNotNull(NameCategory1.Text))
            {
                MessageBox.Show("Uzupełnij nazwy kategorii");
                return;
            }
            if (!Validation.Validation.NotLongerThen(NameCategory1.Text, 100))
            {
                MessageBox.Show("Nazwa kategorii może mieć do 100 znaków");
                return;
            }
            if (!Validation.Validation.NotLongerThen(DescriptionCategory1.Text, 100))
            {
                MessageBox.Show("Opis kategorii może mieć do 100 znaków");
                return;
            }
            DB db = new DB();
            int recid = db.GetCategoryRecid(UserId, TempName);
            if(recid==-2)
            {
                MessageBox.Show("UPS. Coś poszło nie tak :(");
                return;
            }
            if (!db.UpdateCategory(UserId,recid, NameCategory1.Text, DescriptionCategory1.Text, ColorCategory1.Background.ToString()))
            {
                MessageBox.Show("UPS. Coś poszło nie tak :(");
                return;
            }
            else
            {
                this.NavigationService.Navigate(new CategoriesPanel(UserId));
            }
            
         
            
        }
    }
}
