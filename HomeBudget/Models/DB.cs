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
                catch
                {
                    MyError.ConnectingFail();
                }
            }
            //MessageBox.Show("SELECT Email FROM Users WHERE Email =/ ' /'");
        }

        //TWORZENIE WIERSZA Z NOWYM UŻYTKOWNIKIEM
        public bool InsertUser( string email, string hash)
        {
            string query = "INSERT INTO Users VALUES(N'" + email + "','" + hash + "')";
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
                catch
                {
                    return false;
                }
            }
        }
        //TWORZENIE WIERSZA Z NOWYM WYDATKIEM
        public bool InsertExpenditure(int UserId,string name, string amount, string date, int CategoryId)
        {
            string query = "INSERT INTO Expenses VALUES(N'" + name + "'," + amount.Replace(',','.') + ",'" + date + "',"+CategoryId+")";
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
                catch
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
                query = "INSERT INTO Categories VALUES("+user+",N'" + name + "',N'" + description + "','" + color + "', 1 )";
            }
            else
            {
                query = "INSERT INTO Categories VALUES("+user+",N'" + name + "',N'" + description + "','" + color + "', 0 )";
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
                catch
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
            string query = "INSERT INTO Settings VALUES(" + userid + "," + a + "," + b +")";

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
                catch
                {
                    return false;
                }
            }
        }
        //TWORZENIE NOWEGO WIERSZA Z WYDATKIEM NIEREGULARNYM
        public bool InsertIrregularBudget(int UserId, string name, string amount)
        {
            string query = "INSERT INTO IrregularBudget VALUES(" + UserId + ",N'" + name + "'," + amount.Replace(',', '.') + "," + "0.0"+ ")";
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
                catch
                {
                    return false;
                }
            }
        }

        public bool InsertMonthPlan(int UserId,string earnings, int year, int month, string irregolarbudget)
        {
            string e = earnings.ToString().Replace(',', '.');
            string ir = irregolarbudget.ToString().Replace(',', '.');
            string query = "INSERT INTO MonthPlans VALUES(" + UserId + ",'" + e + "'," + year + "," + month+ "," + ir+")";
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
                    return false;
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool InsertCategoryPlan(string categoryrec, string monthplanrecid, string value)
        {
            string e = value.ToString().Replace(',', '.');
            string query = "INSERT INTO CategoryPlan VALUES(" + categoryrec + "," + monthplanrecid + "," + e+ ")";
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
                catch
                {
                    return false;
                }
            }
        }
        //TWORZENIE WIERSZA Z NOWYM UŻYTKOWNIKIEM
        public bool UpdateCategory(int UserId,int recid , string name, string desc, string color)
        {
            string query = "UPDATE Categories SET Name=N'"+name+"', Descript=N'"+desc+"', Color='"+color+"' WHERE __recid="+recid+" AND _user="+UserId+" ";
            
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
                catch
                {
                    return false;
                }
            }
        }
        public bool UpdateExpenses(int UserId, string name, string amount, string date, int CategoryId, int ExpRecid)
        {
            string query = "UPDATE Expenses SET Name=N'" + name + "', Amount=" + amount.Replace(',', '.') + ", Date='" + date + "', _category="+CategoryId+" WHERE __recid=" + ExpRecid ;

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
                catch
                {
                    return false;
                }
            }
        }
        public bool UpdateIrregularBudget(int UserId, string name, string amount, int recid)
        {
            string query = "UPDATE IrregularBudget SET Name=N'" + name + "', Amount=" + amount.Replace(',', '.') + " WHERE __recid=" + recid;

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
                catch
                {
                    return false;
                }
            }
        }
        public bool UpdateSettings(int UserId, string startssaving, string earnings)
        {
            string query = "UPDATE Settings SET StartsSaving='" + startssaving + "', Earnings='" + earnings + "' WHERE  _user=" + UserId + " ";

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
                catch 
                {
                    return false;
                }
            }
        }

        public bool UpdateMonthPlan(string recid, string earnings, string irregularbudget)
        {
            string e = earnings.ToString().Replace(',', '.');
            string ib = irregularbudget.ToString().Replace(',', '.');
            string query = "UPDATE MonthPlans SET Earnings=" + e+ ", IrregularBudgetFund="+ ib +" WHERE __recid = "+recid;

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
                catch
                {
                    return false;
                }
            }
        }

        public bool UpdateCategoryPlan(string recid, string value)
        {
            string e = value.ToString().Replace(',', '.');
            string query = "UPDATE CategoryPlan SET Value=" + e + " WHERE __recid = " + recid;

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
                catch
                {
                    return false;
                }
            }
        }
        //SPRAWDZENIE CZY ISTNIEJE UŻYTKOWNIK O PODANYM ADRESIE EMAIL
        public bool CheckUniqueEmail(string email)
        {


            string query = "SELECT Email FROM Users WHERE Email=N'" + email + "'";
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
        public bool CheckMonthPlan(int _user,int year, int month)
        {


            string query = "SELECT * FROM MonthPlans WHERE _user=" + _user + " AND [Year]= "+year+" AND [Month]="+month;
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


            string query = "SELECT __recid FROM Users WHERE Email=N'" + email + "' AND Password='"+hash+"'";
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

        public bool CheckCategory(int user,string name)
        {


            string query = "Select count(c.Name) from Categories c where c.Name=N'"+name+"' and c._user="+user.ToString();
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
                    if (temp == "0")
                    {
                        return false;
                    }
                    else
                    {
                        Connection.Close();
                        return true;
                    }
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
            string query = "SELECT __recid FROM Categories WHERE _user=" + UserId + " AND Name=N'" + name + "'";
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


            string query = "SELECT __recid FROM Users WHERE Email=N'" + email + "' AND Password='" + hash + "'";
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
        public List<IrregularBudget> GetAllFromIrregularBudget(int UserId)
        {

            List<IrregularBudget> list = new List<IrregularBudget>();
            string query = "SELECT Name,Amount, Value, __recid FROM IrregularBudget WHERE _User=" + UserId;
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
                        IrregularBudget cat = new IrregularBudget(Reader.GetValue(0).ToString(), Reader.GetValue(1).ToString(), Reader.GetValue(2).ToString(), Convert.ToInt16(Reader.GetValue(3)));
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
        public List<Expenses> GetAllFromExpenses(int UserId)
        {

            List<Expenses> list = new List<Expenses>();
            string query = "Select e.Name, e.Amount, e.[Date] da, c.Name, c.__recid, e.__recid from Expenses e join Categories c on e._category=c.__recid where c._user="+UserId+" order by da";
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
                        Expenses cat = new Expenses(Reader.GetValue(0).ToString(), Reader.GetValue(1).ToString(), Reader.GetValue(2).ToString(), Reader.GetValue(3).ToString(), Reader.GetValue(4).ToString(), Reader.GetValue(5).ToString());
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
        public List<Expenses> GetAllFromExpensesBetweenDate(int UserId,string DateFrom, string DateTo)
        {

            List<Expenses> list = new List<Expenses>();
            string query = "Select e.Name, e.Amount, e.[Date] da, c.Name, c.__recid, e.__recid from Expenses e join Categories c on e._category=c.__recid where c._user=" + UserId + " and e.[Date] between '"+DateFrom+"' and '"+DateTo+"' order by da";
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
                        Expenses cat = new Expenses(Reader.GetValue(0).ToString(), Reader.GetValue(1).ToString(), Reader.GetValue(2).ToString(), Reader.GetValue(3).ToString(), Reader.GetValue(4).ToString(), Reader.GetValue(5).ToString());
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
            string query = "SELECT StartsSaving,Earnings FROM Settings WHERE _User=" + UserId;
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
                        Settings cat = new Settings(Reader.GetValue(0).ToString(), Reader.GetValue(1).ToString());
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
        public MonthPlans GetMonthPlan(string UserId,string Year, string Month)
        {
            MonthPlans mp = new MonthPlans(UserId);
            string query = "SELECT __recid,  Earnings, IrregularBudgetFund  FROM MonthPlans WHERE _user=" + UserId +"and Month= "+Month+" and Year = "+Year;
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
                        mp.ChangeMonthPlan(Year, Month, true, Reader.GetValue(0).ToString(), Reader.GetValue(1).ToString(), Reader.GetValue(2).ToString());
                    }

                    Connection.Close();
                    return mp;

                }
                else
                {
                    Connection.Close();
                    return mp;
                }
            }
        }

        public string GetMonthPlanRecid(int _user, int year, int month)
        {


            string query = "SELECT __recid FROM MonthPlans WHERE _user=" + _user + " AND [Year]= " + year + " AND [Month]=" + month;
            Connection.ConnectionString = ConnectionString;
            Cmd = new SqlCommand(query, Connection);
            //Cmd.Connection = Connection;
            using (Connection)
            {

                Connection.Open();
                Reader = Cmd.ExecuteReader();


                if (Reader.HasRows)
                {
                    string recid="";
                    while (Reader.Read())
                    {
                        recid = Reader.GetValue(0).ToString();
                    }
                    Connection.Close();
                    return recid;
                }
                else
                {
                    Connection.Close();
                    return "";
                }
            }

        }

        public List<CategoryPlan> GetCategoryPlan(int monthplanrecid)
        {

            List<CategoryPlan> list = new List<CategoryPlan>();
            string query = "SELECT cp.__recid, cat.Name, cp._category, cp._monthplan, cp.Value FROM CategoryPlan cp left join Categories cat on cp._category=cat.__recid WHERE _monthplan=" + monthplanrecid ;
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
                        list.Add(new CategoryPlan(Reader.GetValue(0).ToString(), (Reader.GetValue(1).ToString()), Reader.GetValue(2).ToString(), Reader.GetValue(3).ToString(), Reader.GetValue(4).ToString()));
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

        public List<AnnualSummary> GeAnnualSUmmary(string user,string year)
        {

            List<AnnualSummary> list = new List<AnnualSummary>();
            string query = "Select c.Name, SUM(e.Amount) as sum from Categories c  left join Expenses e  on e._category=c.__recid where c._user="+user+" and e.[Date] between '"+year+"-01-01' and '"+year+"-12-31' group by c.Name ";
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
                        list.Add(new AnnualSummary(Reader.GetValue(0).ToString(), (Reader.GetValue(1).ToString())));
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


        public List<CategoryPlan> GetCategoryPlanWithSum(int monthplanrecid,int month, int year)
        {

            List<CategoryPlan> list = new List<CategoryPlan>();
            string query = "SELECT cp.__recid, cat.Name, cp._category, cp._monthplan, cp.Value FROM CategoryPlan cp left join Categories cat on cp._category=cat.__recid WHERE _monthplan=" + monthplanrecid;
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
                        DB db = new DB();
                        list.Add(new CategoryPlan(Reader.GetValue(0).ToString(), (Reader.GetValue(1).ToString()), Reader.GetValue(2).ToString(), Reader.GetValue(3).ToString(), Reader.GetValue(4).ToString(), db.GetAmuntToCategory(Reader.GetValue(2).ToString(),month,year)));
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

        public string GetAmuntToCategory(string catrecid, int month, int year)
        {

            string tempmonth = month.ToString();
            if(month<10)
            {
                tempmonth="0"+ month.ToString();
            }
            
            string toreturn = "0,00";
            string query = "Select SUM(e.Amount) from Expenses e join Categories c on e._category=c.__recid  where c.__recid="+catrecid+" and e.[Date] between '"+year+"-"+tempmonth+ "-01' and '" + year + "-" + tempmonth + "-"+Validation.Validation.GetDayInMonth(tempmonth) +"'";
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
                        toreturn = (Reader.GetValue(0).ToString());
                    }
                    if (toreturn == "") toreturn = "0,00";
                    Connection.Close();
                    return toreturn;

                }
                else
                {
                    Connection.Close();
                    return toreturn;
                }
            }
        }

        public string GetCategoryColor(string catrecid)
        {



            string toreturn = "#FF07B226";
            string query = "SELECT Color FROM Categories WHERE __recid="+catrecid;
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
                        toreturn = (Reader.GetValue(0).ToString());
                    }
                    if (toreturn == "") toreturn = "#FF07B226";
                    Connection.Close();
                    return toreturn;

                }
                else
                {
                    Connection.Close();
                    return toreturn;
                }
            }
        }

        public string GetIrregularBudgetSum(string user)
        {
            string toreturn = "0,0";
            string query = "SELECT Sum(Amount) FROM IrregularBudget WHERE _user=" + user;
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
                        toreturn = (Reader.GetValue(0).ToString());
                    }
                    if (toreturn == "") toreturn = "0,0";
                    Connection.Close();
                    return toreturn;

                }
                else
                {
                    Connection.Close();
                    return toreturn;
                }
            }
        }

        public string GetIrregularBudgetFund(string user,string year)
        {



            string toreturn = "0,0";
            string query = "SELECT SUM(IrregularBudgetFund) FROM MonthPlans WHERE _user=" + user+"AND Year="+year;
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
                        toreturn = (Reader.GetValue(0).ToString());
                    }
                    if (toreturn == "") toreturn = "0,0";
                    Connection.Close();
                    return toreturn;

                }
                else
                {
                    Connection.Close();
                    return toreturn;
                }
            }
        }



        public string GetNumberExpensesInCaterory(string user, string name)
        {



            string toreturn = "0";
            string query = "Select Count(e.Name)from Expenses e join Categories c on e._category = c.__recid where c.Name=N'"+name+"' and  c._user="+user;
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
                        toreturn = (Reader.GetValue(0).ToString());
                    }
                    if (toreturn == "") toreturn = "0";
                    Connection.Close();
                    return toreturn;

                }
                else
                {
                    Connection.Close();
                    return toreturn;
                }
            }
        }

        public string GetNumberCategoryPlansWithCategory(string user, string name)
        {



            string toreturn = "0";
            string query = "select Count(cp.__recid) from CategoryPlan cp join Categories c on cp._category=c.__recid where c._user="+user+" and c.Name=N'"+name+"'";
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
                        toreturn = (Reader.GetValue(0).ToString());
                    }
                    if (toreturn == "") toreturn = "0";
                    Connection.Close();
                    return toreturn;

                }
                else
                {
                    Connection.Close();
                    return toreturn;
                }
            }
        }
        public string GetYearEarnings(string user, string year)
        {



            string toreturn = "0";
            string query = "select Sum(Earnings) from MonthPlans where _user="+user+" and [Year]="+year;
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
                        toreturn = (Reader.GetValue(0).ToString());
                    }
                    if (toreturn == "") toreturn = "0,0";
                    Connection.Close();
                    return toreturn;

                }
                else
                {
                    Connection.Close();
                    return toreturn;
                }
            }
        }

        public string GetYearExpenses(string user, string year)
        {



            string toreturn = "0";
            //string query = "select Sum(Amount) from Expenses where _user="+user+" and [Date] between '" + year + "-01-01' and '" + year+"-12-31'";
            string query = "select Sum(e.Amount) from Expenses e right join Categories c on e._category = c.__recid where c._user = " + user + " and e.[Date] between '" + year + "-01-01' and '" + year+"-12-31'";
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
                        toreturn = (Reader.GetValue(0).ToString());
                    }
                    if (toreturn == "") toreturn = "0,0";
                    Connection.Close();
                    return toreturn;

                }
                else
                {
                    Connection.Close();
                    return toreturn;
                }
            }
        }


        public string GetUserEarnings(int user)
        {



            string toreturn = "0";
            string query = "SELECT Earnings from Settings where _user = '"+user+"'";
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
                        toreturn = (Reader.GetValue(0).ToString());
                    }
                    if (toreturn == "") toreturn = "0,0";
                    Connection.Close();
                    return toreturn;

                }
                else
                {
                    Connection.Close();
                    return toreturn;
                }
            }
        }

        public bool DeleteteExpenditure(int __recid)
        {
            string query = "Delete from expenses where __recid="+__recid;
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
                catch
                {
                    return false;
                }
            }
        }
        public bool DeleteteIrregularBudget(int __recid)
        {
            
            string query = "Delete from IrregularBudget where __recid=" + __recid;
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
                catch
                {
                    return false;
                }
            }
        }

        public bool DeleteteCategory(string user, string name)
        {

            string query = "Delete from  Categories where Name=N'"+name+"' and  _user="+user;
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
                catch
                {
                    return false;
                }
            }
        }

        public List<CategoryPlan> NewCategoryPlan(int UserId)
        {

            List<CategoryPlan> list = new List<CategoryPlan>();
            string query = "SELECT Name, __recid FROM Categories WHERE _User=" + UserId;
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
                        list.Add(new CategoryPlan(Reader.GetValue(0).ToString(), (Reader.GetValue(1).ToString()), "0"));
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
