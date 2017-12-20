using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public class CategoryPlan
    {

        public string Recid { get; set; }
        public string Name { get; set; }
        public string MonthPlan { get; set; }
        public string CatRecid { get; set; }
        public string Value { get; set; }
        public string Sum { get; set; }
        public decimal Percent { get; set; }


        public CategoryPlan(string n, string cr, string v)
        {
            Name =n;
            CatRecid = cr;
            Value = Validation.Validation.GetNumberTwoZero(v);
        }
        public CategoryPlan(string r,string n, string cr, string mp, string v)
        {
            Recid = r;
            Name = n;
            CatRecid = cr;
            MonthPlan = mp;
            Value = Validation.Validation.GetNumberTwoZero(v);
        }
        public CategoryPlan(string r, string n, string cr, string mp, string v,string s)
        {
            Recid = r;
            Name = n;
            CatRecid = cr;
            MonthPlan = mp;
            Value = Validation.Validation.GetNumberTwoZero(v);
            Sum= Validation.Validation.GetNumberTwoZero(s);

            if (Convert.ToDecimal(v) > 0)
            Percent = Convert.ToDecimal(s) / Convert.ToDecimal(v);
            else
            Percent = (Convert.ToDecimal(s) /1)*100;
        }
    }
}
