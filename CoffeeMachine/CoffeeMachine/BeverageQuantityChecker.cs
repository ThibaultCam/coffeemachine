using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class BeverageQuantityChecker : IBeverageQuantityChecker
    {
        Dictionary<string, int> served;
        public BeverageQuantityChecker()
        {
            served = new Dictionary<string, int>();
        }

        public bool IsEmpty(string drink)
        {
            if (served.ContainsKey(drink))
            {
                if (served[drink] > 10)
                    return true;
                served[drink]++;
            }
            else
            {
                served.Add(drink, 1);
            }

            return false;
        }
    }
}
