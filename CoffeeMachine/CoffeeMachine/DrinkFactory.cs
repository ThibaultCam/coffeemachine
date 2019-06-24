using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public static class DrinkFactory
    {
        public static string CreateDrink(string order)
        {
            string[] ingredients = order.Split(':');
            StringBuilder stringBuilder = new StringBuilder("Drink maker makes ");

            // Adding drink
            switch (ingredients[0])
            {
                case "C":
                    stringBuilder.Append("1 coffee ");
                    break;
                case "T":
                    stringBuilder.Append("1 tea ");
                    break;
                case "H":
                    stringBuilder.Append("1 chocolate ");
                    break;
                default:
                    return "Bad order";
            }

            // Adding sugar
            int nbSugar = 0;
            Int32.TryParse(ingredients[1], out nbSugar);
            if(nbSugar > 0)
                stringBuilder.Append("with " + nbSugar +" sugar" + ((nbSugar>1)? "s " : " "));
            else
                stringBuilder.Append("with no sugar ");

            // Adding stick
            if(ingredients[2] == "0")
                stringBuilder.Append("and a stick");
            else
                stringBuilder.Append("and no stick");

            return stringBuilder.ToString();
        }
    }
}
