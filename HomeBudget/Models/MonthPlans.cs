using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public class MonthPlans
    {
        public string __recid { get; set; }
        public string _user { get; set; }
        public string Earning { get; set; }
        public string IrregularBudgetFund { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public bool Exist { get; set; }

        public MonthPlans(string user)
        {
            _user = user;
        }

        public void ChangeMonthPlan(string year, string month, bool exist,string ib)
        {
            Year = year;
            Month = month;
            Exist = exist;
            IrregularBudgetFund = Validation.Validation.GetNumberTwoZero(ib);

        }

        public void ChangeMonthPlan(string year, string month, bool exist, string recid, string earning, string ib)
        {
            Year = year;
            Month = month;
            Exist = exist;
            __recid = recid;
            Earning = Validation.Validation.GetNumberTwoZero(earning);
            IrregularBudgetFund = Validation.Validation.GetNumberTwoZero(ib);
        }

    }
}
