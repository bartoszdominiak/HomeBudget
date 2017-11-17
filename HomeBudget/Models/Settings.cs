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

        public Settings(string ss, string ea, string sd)
        {
            StartsSaving = ss;
            Earnings = ea;
            int x = 0;

            Int32.TryParse(sd, out x);
            StartDay = Int32.Parse(sd); //zle
        }
    }
}
