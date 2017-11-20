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
        public int StartDay { get; set; }
        private string StringStartDay { get; set; }

        public Settings(string ss, string ea, string sd)
        {
            StartsSaving = ss;
            Earnings = ea;
            StringStartDay = sd;
            int x = 0;

            Int32.TryParse(sd, out x);
            StartDay = Int32.Parse(sd); //zle
        }

        public bool HaveChanged(string ss, string ea, string sd)
        {
            if((StartsSaving==ss)&&(Earnings==ea)&&(StringStartDay==sd))
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
