using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public class Categories
    {
        public string Name { get; set; }
        public string Descript { get; set; }
        public string Color { get; set; }

        public Categories(string name, string desc, string color)
        {
            Name = name;
            Descript = desc;
            Color = color;
        }
    }
}
