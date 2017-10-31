using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for RegisterPanel.xaml
    /// </summary>
    public partial class RegisterPanel : Page
    {
        public RegisterPanel()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.Validation.StringNotNull(NameBox.Text))
            {
                RegisterFail.Content = "Wprowadź imię";
            }
            if (!Validation.Validation.StringNotNull(EmailBox.Text))
            {
                RegisterFail.Content = "Wprowadź adres email";
            }
            else if (PasswordBox.Password.Count() == 0)
            {
                RegisterFail.Content = "Wprowadź hasło";
            }
            else if (PasswordConfirmBox.Password.Count() == 0)
            {
                RegisterFail.Content = "Wprowadź potwierdzenie hasła";
            }
            else if (!Validation.Validation.TwoStringsEquals(PasswordConfirmBox.Password.ToString(), PasswordBox.Password.ToString()))
            {
                RegisterFail.Content = "Hasła nie są równe";
            }
            else if (!Validation.Validation.IsValidEmail(EmailBox.Text))
            {
                RegisterFail.Content = "Niepoprawny adres email";
            }
            else
            {
                string hash = null;
                using (MD5 md5Hash = MD5.Create())
                {
                    hash=GetMd5Hash(md5Hash, PasswordBox.Password.ToString());


                    if (!VerifyMd5Hash(md5Hash, PasswordBox.Password.ToString(), hash))
                    {
                        MessageBox.Show("Błąd funkcji skrótu.");
                        return;
                    }
                }

                DB db = new DB();
                if(db.CheckUniqueEmail(EmailBox.Text))
                {
                    RegisterFail.Content = "Adres zajęty";
                    return;
                }
                else if(!db.InsertUser(NameBox.Text,EmailBox.Text,hash))
                {
                    MessageBox.Show("UPS. Coś poszło nie tak :(");
                    return;
                }
                else
                {
                    MessageBox.Show("Użytkownik został poprawnie zarejestrowany.");
                    this.NavigationService.Navigate(new LoginPanel());
                }

            }

        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
           byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
           StringBuilder sBuilder = new StringBuilder();
           for (int i = 0; i < data.Length; i++)
           {
               sBuilder.Append(data[i].ToString("x2"));
           }
           return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
