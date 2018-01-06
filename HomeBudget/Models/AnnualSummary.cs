using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public class AnnualSummary
    {
        public string Name { get; set; }
        public string Sum { get; set; }


        public AnnualSummary(string name, string sum)
        {
            Name = name;
            Sum = Validation.Validation.GetNumberTwoZero(sum);
        }
    }
}
