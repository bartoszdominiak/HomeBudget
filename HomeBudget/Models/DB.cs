using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeBudget.Models
{
    public class DB
    {
        public string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlCommand Cmd { get; set; }
        public SqlDataReader Reader { get; set; }


        public DB()
        {
            ConnectionString = "Data Source=homebudget.database.windows.net;Initial Catalog=HomeBudget;User ID=Bartas199;Password=QWERTY_1234";

            using (Connection = new SqlConnection())
            {
                try
                {
                    Connection.ConnectionString = ConnectionString;
                    Connection.Open();
                    Connection.Close();
                }
                catch (Exception ex)
                {
                    MyError.ConnectingFail();
                }
            }
            //MessageBox.Show("SELECT Email FROM Users WHERE Email =/ ' /'");
        }


        //TWORZENIE WIERSZA Z NOWYM UŻYTKOWNIKIEM
        public bool InsertUser(string name, string email, string hash)
        {
            string query = "INSERT INTO Users VALUES('" + name + "','" + email + "','" + hash + "')";
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {
                try
                {
                    Connection.Open();
                    Cmd.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        //TWORZENIE WIERSZA Z NOWYM WYDATKIEM
        public bool InsertExpenditure(int UserId,string name, string amount, string date, int CategoryId)
        {
            string query = "INSERT INTO Expenses VALUES(" + UserId + ",'" + name + "'," + amount.Replace(',','.') + ",'" + date + "',"+CategoryId+")";
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {
                try
                {
                    Connection.Open();
                    Cmd.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        //TWORZENIE WIERSZA Z NOWĄ KATEGORIĄ
        public bool InsertCategory(int user, string name, string description, string color, bool parent)
        {
            string query = "";
            if (parent == true)
            {
                query = "INSERT INTO Categories VALUES("  + user + ",'" + name + "','" + description + "','" + color + "', 1 )";
            }
            else
            {
                query = "INSERT INTO Categories VALUES(" + user + ",'" + name + "','" + description + "','" + color + "', 0 )";
            }
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {
                try
                {
                    Connection.Open();
                    Cmd.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        //TWORZENIE NOWEGO WIERSZA Z USTAWIENIAMI
        public bool InsertSettings(int userid, decimal saving, decimal earnings)
        {
            string a = saving.ToString().Replace(',','.');
            string b = earnings.ToString().Replace(',', '.');
            string query = "INSERT INTO Settings VALUES(" + userid + "," + a + "," + b + ")";

            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {
                try
                {
                    Connection.Open();
                    Cmd.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        //TWORZENIE WIERSZA Z NOWYM UŻYTKOWNIKIEM
        public bool UpdateCategory(int UserId,int recid , string name, string desc, string color)
        {
            string query = "UPDATE Categories SET Name='"+name+"', Descript='"+desc+"', Color='"+color+"' WHERE __recid="+recid+" AND _user="+UserId+" ";
            
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {
                try
                {
                    Connection.Open();
                    Cmd.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }



        //SPRAWDZENIE CZY ISTNIEJE UŻYTKOWNIK O PODANYM ADRESIE EMAIL
        public bool CheckUniqueEmail(string email)
        {


            string query = "SELECT Email FROM Users WHERE Email='" + email + "'";
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {

                Connection.Open();
                Reader = Cmd.ExecuteReader();


                if (Reader.HasRows)
                {
                    Connection.Close();
                    return true;
                }
                else
                {
                    Connection.Close();
                    return false;
                }
            }

        }

        //Sprawdzenie czy istnieje użytkownik
        public bool ChechUserLogin(string email, string hash)
        {


            string query = "SELECT __recid FROM Users WHERE Email='" + email + "' AND Password='"+hash+"'";
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {

                Connection.Open();
                Reader = Cmd.ExecuteReader();


                if (Reader.HasRows)
                {
                    Connection.Close();
                    return true;
                }
                else
                {
                    Connection.Close();
                    return false;
                }
            }
        }

        //Sprawdzenie czy użytkownik posiada ustawienia
        public bool ChechUserSettings(int user)
        {


            string query = "SELECT __recid FROM Settings WHERE _user=" + user;
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {

                Connection.Open();
                Reader = Cmd.ExecuteReader();


                if (Reader.HasRows)
                {
                    Connection.Close();
                    return true;
                }
                else
                {
                    Connection.Close();
                    return false;
                }
            }
        }

        //Pobranie recidu kategorii po użytkowniku i nazwie
        public int GetCategoryRecid(int UserId, string name)
        {
            string query = "SELECT __recid FROM Categories WHERE _user=" + UserId + " AND Name='" + name + "'";
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {

                Connection.Open();
                Reader = Cmd.ExecuteReader();


                if (Reader.HasRows)
                {
                    string temp = "";
                    while (Reader.Read())
                    {
                        temp = Reader.GetValue(0).ToString();
                    }

                    Connection.Close();
                    return Convert.ToInt32(temp);

                }
                else
                {
                    Connection.Close();
                    return -2;
                }
            }
        }


        //Pobranie recidu użytkownika podczas logowania
        public int GetUserRecid(string email, string hash)
        {


            string query = "SELECT __recid FROM Users WHERE Email='" + email + "' AND Password='" + hash + "'";
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {

                Connection.Open();
                Reader = Cmd.ExecuteReader();


                if (Reader.HasRows)
                {
                    string temp="";
                    while (Reader.Read())
                    {
                       temp = Reader.GetValue(0).ToString();
                    }
                   
                    Connection.Close();
                    return Convert.ToInt32(temp);

                }
                else
                {
                    Connection.Close();
                    return -2;
                }
            }
        }
        //Pobranie nazw kategorii należących do użytkownika
        public List<string> GetCategoriesName(int UserId)
        {

            List<string> list = new List<string>();
            string query = "SELECT Name FROM Categories WHERE _User=" + UserId;
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {

                Connection.Open();
                Reader = Cmd.ExecuteReader();


                if (Reader.HasRows)
                {
                    
                    while (Reader.Read())
                    {
                        list.Add(Reader.GetValue(0).ToString());
                    }

                    Connection.Close();
                    return list;

                }
                else
                {
                    Connection.Close();
                    return list;
                }
            }
        }

        public List<Categories> GetAllFromCategories(int UserId)
        {

            List<Categories> list = new List<Categories>();
            string query = "SELECT Name,Descript,Color FROM Categories WHERE _User=" + UserId;
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {

                Connection.Open();
                Reader = Cmd.ExecuteReader();


                if (Reader.HasRows)
                {

                    while (Reader.Read())
                    {
                        Categories cat = new Categories(Reader.GetValue(0).ToString(), Reader.GetValue(1).ToString(), Reader.GetValue(2).ToString());
                        list.Add(cat);
                    }

                    Connection.Close();
                    return list;

                }
                else
                {
                    Connection.Close();
                    return list;
                }
            }
        }


        public List<Settings> GetAllFromSettings(int UserId)
        {

            List<Settings> list = new List<Settings>();
            string query = "SELECT StartsSaving,Earnings,StartDay FROM Settings WHERE _User=" + UserId;
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {

                Connection.Open();
                Reader = Cmd.ExecuteReader();


                if (Reader.HasRows)
                {

                    while (Reader.Read())
                    {
                        Settings cat = new Settings(Reader.GetValue(0).ToString(), Reader.GetValue(1).ToString(), Reader.GetValue(2).ToString() );
                        list.Add(cat);
                    }

                    Connection.Close();
                    return list;

                }
                else
                {
                    Connection.Close();
                    return list;
                }
            }
        }

    }
}
