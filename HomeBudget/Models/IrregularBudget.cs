using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public class IrregularBudget
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Value { get; set; }
        public int __recid { get; set; }

        public IrregularBudget(string n, string a, string v, int r)
        {
            Name = n;
            Amount= Validation.Validation.GetNumberTwoZero(a);
            Value = Validation.Validation.GetNumberTwoZero(v);
            __recid = r;
        }
    }
}
