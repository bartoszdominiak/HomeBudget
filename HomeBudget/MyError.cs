using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeBudget
{
    public class MyError
    {
    
        public static void ConnectingFail()
        {
            MessageBox.Show("Program nie może połączyć się do bazy danych." + "\n" + "Sprawdź połączenie z Internetem.");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
