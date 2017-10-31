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
    /// Interaction logic for StartSettingsPanel.xaml
    /// </summary>
    public partial class StartSettingsPanel : Page
    {
        public StartSettingsPanel()
        {
            InitializeComponent();
            this.colorList1.ItemsSource = typeof(Brushes).GetProperties();
            this.colorList2.ItemsSource = typeof(Brushes).GetProperties();
            this.colorList3.ItemsSource = typeof(Brushes).GetProperties();
            this.colorList4.ItemsSource = typeof(Brushes).GetProperties();
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




        private void ColorCategory1_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Visible;
            colorList2.Visibility = Visibility.Hidden;
            colorList3.Visibility = Visibility.Hidden;
            colorList4.Visibility = Visibility.Hidden;
        }
      
        private void ColorCategory2_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Hidden;
            colorList2.Visibility = Visibility.Visible;
            colorList3.Visibility = Visibility.Hidden;
            colorList4.Visibility = Visibility.Hidden;
        }

        private void ColorCategory3_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Hidden;
            colorList2.Visibility = Visibility.Hidden;
            colorList3.Visibility = Visibility.Visible;
            colorList4.Visibility = Visibility.Hidden;
        }

        private void ColorCategory4_Click(object sender, RoutedEventArgs e)
        {
            colorList1.Visibility = Visibility.Hidden;
            colorList2.Visibility = Visibility.Hidden;
            colorList3.Visibility = Visibility.Hidden;
            colorList4.Visibility = Visibility.Visible;
        }
    }
}
