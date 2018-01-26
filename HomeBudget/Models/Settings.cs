using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public class Settings
    {
        public string StartsSaving { get; set; }
        public string Earnings { get; set; }
        public string FirstCat { get; set; }

  

        public Settings(string ss, string ea, string fc)
        {
            StartsSaving = ss;
            Earnings = ea;
            FirstCat = fc;
        }

        public bool HaveChanged(string ss, string ea,string fc)
        {
            if((StartsSaving==ss)&&(Earnings==ea) && (FirstCat == fc))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
