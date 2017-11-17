using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for StartSettingsPanel.xaml
    /// </summary>
    public partial class StartSettingsPanel : Page
    {
        private int UserId { get; }

        public StartSettingsPanel(int Id)
        {
            InitializeComponent();

            this.colorList1.ItemsSource = typeof(Brushes).GetProperties();
            this.colorList2.ItemsSource = typeof(Brushes).GetProperties();
            this.colorList3.ItemsSource = typeof(Brushes).GetProperties();
            this.colorList4.ItemsSource = typeof(Brushes).GetProperties();
            this.colorList5.ItemsSource = typeof(Brushes).GetProperties();

            UserId = Id;
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.Validation.StringNotNull(NameCategory1.Text)|| !Validation.Validation.StringNotNull(NameCategory2.Text)|| !Validation.Validation.StringNotNull(NameCategory3.Text) || !Validation.Validation.StringNotNull(NameCategory4.Text) || !Validation.Validation.StringNotNull(NameCategory5.Text))
            {
                MessageBox.Show("Uzupełnij nazwy kategorii");
                return;
            }
            if (!Validation.Validation.NotLongerThen(NameCategory1.Text,100) || !Validation.Validation.NotLongerThen(NameCategory2.Text, 100) || !Validation.Validation.NotLongerThen(NameCategory3.Text, 100) || !Validation.Validation.NotLongerThen(NameCategory4.Text, 100) || !Validation.Validation.NotLongerThen(NameCategory5.Text, 100))
            {
                MessageBox.Show("Nazwa kategorii może mieć do 100 znaków");
                return;
            }
            if(!Validation.Validation.NotLongerThen(DescriptionCategory1.Text, 100) || !Validation.Validation.NotLongerThen(DescriptionCategory2.Text, 100) || !Validation.Validation.NotLongerThen(DescriptionCategory3.Text, 100) || !Validation.Validation.NotLongerThen(DescriptionCategory4.Text, 100) || !Validation.Validation.NotLongerThen(DescriptionCategory5.Text, 100))
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
                if (!db.InsertCategory(UserId, NameCategory2.Text, DescriptionCategory2.Text, ColorCategory2.Background.ToString(), false))
                {
                    MessageBox.Show("UPS. Coś poszło nie tak :(");
                    return;
                }
                else
                {
                    if (!db.InsertCategory(UserId, NameCategory3.Text, DescriptionCategory3.Text, ColorCategory3.Background.ToString(), false))
                    {
                        MessageBox.Show("UPS. Coś poszło nie tak :(");
                        return;
                    }
                    else
                    {
                        if (!db.InsertCategory(UserId, NameCategory4.Text, DescriptionCategory4.Text, ColorCategory4.Background.ToString(), false))
                        {
                            MessageBox.Show("UPS. Coś poszło nie tak :(");
                            return;
                        }
                        else
                        {
                            if (!db.InsertCategory(UserId, NameCategory5.Text, DescriptionCategory5.Text, ColorCategory5.Background.ToString(), false))
                            {
                                MessageBox.Show("UPS. Coś poszło nie tak :(");
                                return;
                            }
                            else
                            {
                                decimal savings = Decimal.Parse(StartsSavingBox.Text);
                                decimal earnings = Decimal.Parse(EarningsBox.Text);

                                if (!db.InsertSettings(UserId,savings, earnings))
                                {
                                    MessageBox.Show("UPS. Coś poszło nie tak :(");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Konfiguracja zakończona");
                                    this.NavigationService.Navigate(new MenuPanel(UserId));
                                }
                            }
                        }
                    }
                }
            }
       
        }



        private void colorList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            ColorCategory1.Background = selectedColor;
            colorList1.Visibility = Visibility.Hidden;
        }
        private void colorList2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            ColorCategory2.Background = selectedColor;
            colorList2.Visibility = Visibility.Hidden;
        }
        private void colorList3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            ColorCategory3.Background = selectedColor;
            colorList3.Visibility = Visibility.Hidden;
        }
        private void colorList4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            ColorCategory4.Background = selectedColor;
            colorList4.Visibility = Visibility.Hidden;
        }
        private void colorList5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            ColorCategory5.Background = selectedColor;
            colorList5.Visibility = Visibility.Hidden;
        }



        private void ColorCategory1_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Visible;
            colorList2.Visibility = Visibility.Hidden;
            colorList3.Visibility = Visibility.Hidden;
            colorList4.Visibility = Visibility.Hidden;
            colorList5.Visibility = Visibility.Hidden;
        }
        private void ColorCategory2_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Hidden;
            colorList2.Visibility = Visibility.Visible;
            colorList3.Visibility = Visibility.Hidden;
            colorList4.Visibility = Visibility.Hidden;
            colorList5.Visibility = Visibility.Hidden;
        }
        private void ColorCategory3_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Hidden;
            colorList2.Visibility = Visibility.Hidden;
            colorList3.Visibility = Visibility.Visible;
            colorList4.Visibility = Visibility.Hidden;
            colorList5.Visibility = Visibility.Hidden;
        }
        private void ColorCategory4_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Hidden;
            colorList2.Visibility = Visibility.Hidden;
            colorList3.Visibility = Visibility.Hidden;
            colorList4.Visibility = Visibility.Visible;
            colorList5.Visibility = Visibility.Hidden;
        }
        private void ColorCategory5_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Hidden;
            colorList2.Visibility = Visibility.Hidden;
            colorList3.Visibility = Visibility.Hidden;
            colorList4.Visibility = Visibility.Hidden;
            colorList5.Visibility = Visibility.Visible;
        }
        private void StartsSavingBox_LostFocus(object sender, RoutedEventArgs e)
        {
            StartsSavingBox.Text = Validation.Validation.GetNumberWithDot(StartsSavingBox.Text.Trim());
        }
        private void EarningsBox_LostFocus(object sender, RoutedEventArgs e)
        {
            EarningsBox.Text = Validation.Validation.GetNumberWithDot(EarningsBox.Text.Trim());
        }
    }
}
