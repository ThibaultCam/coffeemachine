using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class Report
    {
        public int NbTea { get; set; }
        public int NbHotTea { get; set; }
        public int NbCoffee { get; set; }
        public int NbHotCoffee { get; set; }
        public int NbChocolate { get; set; }
        public int NbHotChocolate { get; set; }
        public int NbOrangeJuice { get; set; }

        public List<string> Sold()
        {
            List<string> list = new List<string>();
            list.Add("Number of tea : " + NbTea.ToString());
            list.Add("Number of hot tea : " + NbHotTea.ToString());
            list.Add("Number of coffee : " + NbCoffee.ToString());
            list.Add("Number of hot coffee : " + NbHotCoffee.ToString());
            list.Add("Number of chocolate : " + NbChocolate.ToString());
            list.Add("Number of hot chocolate : " + NbHotChocolate.ToString());
            list.Add("Number of orange juice : " + NbOrangeJuice.ToString());

            return list;
        }
    }
}
