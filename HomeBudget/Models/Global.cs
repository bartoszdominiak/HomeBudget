using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HomeBudget.Models
{


    class Global
    {
        public static bool ChangePage = false;
        public static Page MenuPage;

        static Global()
        {

        }

        public static void SetChangePage(bool to)
        {
            ChangePage = to;
        }
        public static bool GetChangePage()
        {
            return ChangePage;
        }

        public static void SetMenuPage(Page toPage)
        {
            MenuPage = toPage;
        }
        public static Page GetMenuPage()
        {
            return MenuPage;
        }

    }
}
