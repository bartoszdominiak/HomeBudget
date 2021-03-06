﻿using HomeBudget.Models;
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
    /// Interaction logic for LoginPanel.xaml
    /// </summary>
    public partial class LoginPanel : Page
    {
        public LoginPanel()
        {
            InitializeComponent();

          
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginButton_Click();


        }

        private void LoginButton_Click()
        {
            if (!Validation.Validation.StringNotNull(EmailBox.Text))
            {
                LoginFail.Content = "Wprowadź adres email";
            }
            else if (!Validation.Validation.StringNotNull(PasswordBox.Password))
            {
                LoginFail.Content = "Wprowadź hasło";
            }
            else if (!Validation.Validation.IsValidEmail(EmailBox.Text))
            {
                LoginFail.Content = "Niepoprawny adres email";
            }
            else
            {

                byte[] hash = Validation.Validation.Hash(PasswordBox.Password.ToString(), Validation.Validation.salt);
                string shash = System.Text.Encoding.UTF8.GetString(hash, 0, hash.Length);

                DB db = new DB();
                if(!db.ChechUserLogin(EmailBox.Text,shash))
                {
                    LoginFail.Content = "Podany dane nieprawidłowe";
                    return;
                }




                //DB db = new DB();
                //using (MD5 md5Hash = MD5.Create())
                //{
                //    hash = GetMd5Hash(md5Hash, PasswordBox.Password.ToString());


                //    if (!Validation.Validation.VerifyMd5Hash(md5Hash, PasswordBox.Password.ToString(), hash))
                //    {
                //        MessageBox.Show("Błąd funkcji skrótu.");
                //        return;
                //    }
                //}

                if (db.GetUserRecid(EmailBox.Text, shash) == -2 || db.GetUserRecid(EmailBox.Text, shash) == 0)
                {
                    LoginFail.Content = "Podany dane nieprawidłowe";
                    return;
                }
                else
                {
                    int UserId = db.GetUserRecid(EmailBox.Text, shash);
                    if (!db.ChechUserSettings(UserId))
                        this.NavigationService.Navigate(new StartSettingsPanel(UserId));
                    else
                        this.NavigationService.Navigate(new MenuPanel(UserId));
                }

            }


        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterPanel());
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

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoginButton_Click();
            }
        }
    }
}
