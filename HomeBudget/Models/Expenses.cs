using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public class Expenses
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public string CategoryName { get; set; }
        public int CategoryRecid { get; set; }
        public int ExpRecid { get; set; }

        public Expenses(string n, string v, string d, string cn, string cr, string expRecid)
        {
            Name = n;
            Value = Validation.Validation.GetNumberTwoZero(v);
            Date = Validation.Validation.GetShortDate(d);
            CategoryName = cn;
            CategoryRecid = Convert.ToInt16(cr);
            ExpRecid = Convert.ToInt16(expRecid);
        }
    }
}
