using HomeBudget.Models;
using HomeBudget.Panels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace HomeBudget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Global glob = new Global();
            InitializeComponent();
            //Page p1 = new StartSettingsPanel(1);
            Page p1 = new LoginPanel();
            //Page p1 = new IrregularBudgetPanel(2);
            myframe.NavigationService.Navigate(p1);
            DB db = new DB();
         
           // CheckConnecting();

        }

        //sprawdzanie połączenia do bazy danych
        private void CheckConnecting()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                string connetionString = null;
                connetionString = "Data Source=homebudget.database.windows.net;Initial Catalog=HomeBudget;User ID=Bartas199;Password=QWERTY_1234";
                conn.ConnectionString = connetionString;

                try
                {
                    conn.Open();
                    //ConnectingLabel.Content = "Connection Open ! ";
                    //SqlCommand command = new SqlCommand("SELECT * from test", conn);
                    //SqlDataReader dataReader;
                    //dataReader = command.ExecuteReader();
                    //while (dataReader.Read())
                    //{
                    //    EmailBox.Text = dataReader.GetValue(0) + " - " + dataReader.GetValue(1);
                    //}
                    conn.Close();
                }
                catch 
                {
                    MyError.ConnectingFail();
                }

                // SqlCommand command = new SqlCommand("SELECT * test", conn);
            }
        }


    }
}
