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

namespace HomeBudget.Panels
{
    /// <summary>
    /// Interaction logic for LoginPanel.xaml
    /// </summary>
    public partial class LoginPanel : Page
    {
        public LoginPanel()
        {
            InitializeComponent();


            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                // Trusted_Connection is used to denote the connection uses Windows Authentication
                string connetionString = null;
                //SqlConnection conn;
                connetionString = "Data Source=homebudget.database.windows.net;Initial Catalog=HomeBudget;User ID=Bartas199;Password=QWERTY_1234";
                conn.ConnectionString = connetionString;

                //conn.ConnectionString = "Server=[homebudget.database.windows.net];Database=[HomeBudget];Trusted_Connection=true";
                try
                {
                    conn.Open();
                    ConnectingLabel.Content = "Connection Open ! ";
                    SqlCommand command = new SqlCommand("SELECT * from test", conn);
                    SqlDataReader dataReader;
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        EmailBox.Text= dataReader.GetValue(0) + " - " + dataReader.GetValue(1);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    ConnectingLabel.Content = "Can not open connection ! ";
                }

                // SqlCommand command = new SqlCommand("SELECT * test", conn);



            }
        }
    }
}
