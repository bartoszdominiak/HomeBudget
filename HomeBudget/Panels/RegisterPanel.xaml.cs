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
            RegisterButton_Click();
        }


        private void RegisterButton_Click()
        {
            //if (!Validation.Validation.StringNotNull(NameBox.Text))
            //{
            //    RegisterFail.Content = "Wprowadź imię";
            //    return;
            //}
            //if (!Validation.Validation.NotLongerThen(NameBox.Text,60))
            //{
            //    RegisterFail.Content = "Imię może mieć do 60 znaków";
            //    return;
            //}
            if (!Validation.Validation.StringNotNull(EmailBox.Text))
            {
                RegisterFail.Text = "Wprowadź adres email";
                return;
            }
            if (!Validation.Validation.NotLongerThen(EmailBox.Text, 60))
            {
                RegisterFail.Text = "Email może mieć do 60 znaków";
                return;
            }
            else if (PasswordBox.Password.Count() == 0)
            {
                RegisterFail.Text = "Wprowadź hasło";
                return;
            }
            else if (PasswordBox.Password.Count() < 8)
            {
                RegisterFail.Text = "Hasło musi mieć przynajmniej 8 znaków";
                return;
            }
            else if (PasswordConfirmBox.Password.Count() == 0)
            {
                RegisterFail.Text = "Wprowadź potwierdzenie hasła";
                return;
            }
            else if (!Validation.Validation.TwoStringsEquals(PasswordConfirmBox.Password.ToString(), PasswordBox.Password.ToString()))
            {
                RegisterFail.Text = "Hasła nie są równe";
                return;
            }
            else if (!Validation.Validation.IsValidEmail(EmailBox.Text))
            {
                RegisterFail.Text = "Niepoprawny adres email";
                return;
            }
            else
            {
                string hash = null;
                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, PasswordBox.Password.ToString());


                    if (!VerifyMd5Hash(md5Hash, PasswordBox.Password.ToString(), hash))
                    {
                        MessageBox.Show("Błąd funkcji skrótu.");
                        return;
                    }
                }

                DB db = new DB();
                if (db.CheckUniqueEmail(EmailBox.Text))
                {
                    RegisterFail.Text = "Adres zajęty";
                    return;
                }
                else if (!db.InsertUser(EmailBox.Text, hash))
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPanel());
        }

        private void PasswordConfirmBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
