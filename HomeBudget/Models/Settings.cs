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

  

        public Settings(string ss, string ea)
        {
            StartsSaving = ss;
            Earnings = ea;

        }

        public bool HaveChanged(string ss, string ea)
        {
            if((StartsSaving==ss)&&(Earnings==ea))
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
