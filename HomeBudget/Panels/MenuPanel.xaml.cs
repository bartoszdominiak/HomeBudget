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
    /// Interaction logic for MenuPanel.xaml
    /// </summary>
    public partial class MenuPanel : Page
    {
        private int UserId { get; }
        private int Year = 0;
        private int Month = 0;
        private MonthPlans monthplans;
        private List<CategoryPlan> cat = new List<CategoryPlan>();
        public MenuPanel(int Id)
        {
            InitializeComponent();
            Page p1 = new InterfacePanel();
            InterfaceFrame.NavigationService.Navigate(p1);

            UserId = Id;

            DateTime localDate = DateTime.Now;
            Month = Validation.Validation.GetMonthFromDate(localDate.ToString());
            Year = Validation.Validation.GetYearFromDate(localDate.ToString());
            SetBudgetRealizationLabel();

            MonthPlanExist();
            IrregularBudget();
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
                BudgetRealizationVisibity(true);
                GetMonthAndCatPlan();
                GetMaxCat();

            }
            else
            {
                BudgetRealizationVisibity(false);
            }
        }

        private void BudgetRealizationVisibity(bool check)
        {
            if(check==true)
            {
                BudgetNotExistLabel.Visibility = Visibility.Hidden;
                SetBudgetButton.Visibility = Visibility.Hidden;
                MaxCatLabel.Visibility = Visibility.Visible;
                MaxCatPB.Visibility = Visibility.Visible;
                MaxCatText.Visibility = Visibility.Visible;
                Interjection1.Visibility = Visibility.Visible;
                MidCatLabel.Visibility = Visibility.Visible;
                MidCatPB.Visibility = Visibility.Visible;
                MidCatText.Visibility = Visibility.Visible;
                Interjection2.Visibility = Visibility.Visible;
                LowCatLabel.Visibility = Visibility.Visible;
                LowCatPB.Visibility = Visibility.Visible;
                LowCatText.Visibility = Visibility.Visible;
                Interjection3.Visibility = Visibility.Visible;
                Border1.Visibility = Visibility.Visible;
                HistoryMonthPlan.Visibility = Visibility.Visible;
            }
            else
            {
                BudgetNotExistLabel.Visibility = Visibility.Visible;
                SetBudgetButton.Visibility = Visibility.Visible;
                MaxCatLabel.Visibility = Visibility.Hidden;
                MaxCatPB.Visibility = Visibility.Hidden;
                MaxCatText.Visibility = Visibility.Hidden;
                Interjection1.Visibility = Visibility.Hidden;
                MidCatLabel.Visibility = Visibility.Hidden;
                MidCatPB.Visibility = Visibility.Hidden;
                MidCatText.Visibility = Visibility.Hidden;
                Interjection2.Visibility = Visibility.Hidden;
                LowCatLabel.Visibility = Visibility.Hidden;
                LowCatPB.Visibility = Visibility.Hidden;
                LowCatText.Visibility = Visibility.Hidden;
                Interjection3.Visibility = Visibility.Hidden;
                Border1.Visibility = Visibility.Hidden;
                HistoryMonthPlan.Visibility = Visibility.Hidden;
            }
        }


        private void SetBudgetRealizationLabel()
        {
            Dictionary<int, string> mon = new Dictionary<int, string>();
            mon = DictionaryGenerator.GetMonths();
            foreach (KeyValuePair<int, string> kvp in mon)
            {
                if (kvp.Key == Month)
                {
                    string temp = "Realizacja budżetu na " + kvp.Value.ToLower()+":";
                    BudgetRealizationLabel.Content = temp;
                }
            }
        }

        private void SetBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MonthPlansPanel(UserId));
        }

        private void GetMonthAndCatPlan()
        {
            DB db = new DB();
            MonthPlans mp = db.GetMonthPlan(UserId.ToString(), Year.ToString(), Month.ToString());
            monthplans = mp;
            cat.Clear();
            cat = db.GetCategoryPlanWithSum(Convert.ToInt16(mp.__recid), Month);
        }
        
        private void GetMaxCat()
        {
            DB db = new Models.DB();
            string maxrecid = "";
            string midrecid = "";
            decimal max = -1;
            CategoryPlan maxCP = new CategoryPlan("","0","0,0");
            foreach (CategoryPlan cp in cat)
            {
                if(cp.Percent>max)
                {
                    max = cp.Percent;
                    maxCP = cp;
                }
            }
            maxrecid =maxCP.CatRecid;
            MaxCatLabel.Content = maxCP.Name;
            Color color = (Color)ColorConverter.ConvertFromString(db.GetCategoryColor(maxCP.CatRecid));
            MaxCatPB.Foreground = new System.Windows.Media.SolidColorBrush(color);
            MaxCatPB.Value = Convert.ToDouble(maxCP.Percent);
            MaxCatText.Text = maxCP.Sum + "zł /" + maxCP.Value+ "zł";
            if (maxCP.Percent < 1)
                Interjection1.Visibility = Visibility.Hidden;
            else
                Interjection1.Visibility = Visibility.Visible;

            max = -1;
            CategoryPlan midCP = new CategoryPlan("", "0", "0,0");
            foreach (CategoryPlan cp in cat)
            {
                
                if ((cp.Percent > max)&&(maxrecid!=cp.CatRecid))
                {
                    max = cp.Percent;
                    midCP = cp;
                }
            }
            midrecid = midCP.CatRecid;
            MidCatLabel.Content = midCP.Name;
            color = (Color)ColorConverter.ConvertFromString(db.GetCategoryColor(midCP.CatRecid));
            MidCatPB.Foreground = new System.Windows.Media.SolidColorBrush(color);
            MidCatPB.Value = Convert.ToDouble(midCP.Percent);
            MidCatText.Text = midCP.Sum + "zł /" + midCP.Value+"zł";
            if (midCP.Percent < 1)
                Interjection2.Visibility = Visibility.Hidden;
            else
                Interjection2.Visibility = Visibility.Visible;

            max = -1;
            CategoryPlan lowCP = new CategoryPlan("", "0", "0,0");
            foreach (CategoryPlan cp in cat)
            {

                if ((cp.Percent > max) && (maxrecid != cp.CatRecid)&& (midrecid != cp.CatRecid))
                {
                    max = cp.Percent;
                    lowCP = cp;
                }
            }
   
            LowCatLabel.Content = lowCP.Name;
            color = (Color)ColorConverter.ConvertFromString(db.GetCategoryColor(lowCP.CatRecid));
            LowCatPB.Foreground = new System.Windows.Media.SolidColorBrush(color);
            LowCatPB.Value = Convert.ToDouble(lowCP.Percent);
            LowCatText.Text = lowCP.Sum + "zł /" + lowCP.Value + "zł";
            if (lowCP.Percent < 1)
                Interjection3.Visibility = Visibility.Hidden;
            else
                Interjection3.Visibility = Visibility.Visible;

        }

        public void IrregularBudget()
        {
            DB db = new DB();
            string sum =Validation.Validation.GetNumberTwoZero(db.GetIrregularBudgetSum(UserId.ToString()));
            string fund = Validation.Validation.GetNumberTwoZero(db.GetIrregularBudgetFund(UserId.ToString(),Year.ToString()));
            if(sum != "0,0")
            IBPB.Value = Convert.ToDouble(fund) / Convert.ToDouble(sum);
            else
            {
                if (fund != "0,0")
                {
                    IBPB.Value = Convert.ToDouble(fund)/1.0;
                }
                else
                {
                    IBPB.Value = 0;
                }
            }
            IBText.Text= fund + "zł /" + sum + "zł";

        }

        private void HistoryMonthPlan_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HistoryMonthPlansPanel(UserId));
        }

        private void AnnualSummary_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnnualSummaryPanel(UserId));
        }
    }
}
