using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public static class DictionaryGenerator
    {
        public static Dictionary<int,string> GetMonths()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "Styczeń");
            dic.Add(2, "Luty");
            dic.Add(3,"Marzec");
            dic.Add(4,"Kwiecień");
            dic.Add(5, "Maj");
            dic.Add(6,"Czerwiec");
            dic.Add(7,"Lipiec");
            dic.Add(8,"Sierpień");
            dic.Add(9,"Wrzesień");
            dic.Add(10,"Październik");
            dic.Add(11,"Listopad");
            dic.Add(12,"Grudzień");
            return dic;
        }
    }
}
