using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public static class DrinkFactory
    {
        static string[] numbers = new string[] { "no", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        static Report report = new Report();
        static BeverageQuantityChecker checker = new BeverageQuantityChecker();
        static EmailNotifier notifier = new EmailNotifier();


        public static string CreateDrink(string order)
        {
            string[] ingredients = order.Split(':');
            // Check is machine is empty
            if (checker.IsEmpty(ingredients[0]))
            {
                notifier.NotifyMissingDrink(order);
                return "No more drinks avaible";
            }

            StringBuilder stringBuilder = new StringBuilder("Drink maker ");

            // Adding drink
            switch (ingredients[0])
            {
                case "C":
                    stringBuilder.Append("makes 1 coffee ");
                    report.NbCoffee++;
                    break;
                case "Ch":
                    stringBuilder.Append("will make an extra hot coffee ");
                    report.NbHotCoffee++;
                    break;
                case "O":
                    report.NbOrangeJuice++;
                    return stringBuilder.Append("will make one orange juice").ToString();
                case "T":
                    report.NbTea++;
                    stringBuilder.Append("makes 1 tea ");
                    break;
                case "H":
                    report.NbChocolate++;
                    stringBuilder.Append("makes 1 chocolate ");
                    break;
                case "Hh":
                    report.NbHotChocolate++;
                    stringBuilder.Append("will make an extra hot chocolate ");
                    break;
                case "Th":
                    report.NbHotTea++;
                    stringBuilder.Append("will make an extra hot tea ");
                    break;
                default:
                    return "Bad order";
            }

            // Adding sugar
            int nbSugar = 0;
            Int32.TryParse(ingredients[1], out nbSugar);
            if (ingredients[0].Length > 1)
                stringBuilder.Append("with " + numbers[nbSugar] + " sugar");
            else if (nbSugar > 0)
                stringBuilder.Append("with " + nbSugar +" sugar" + ((nbSugar>1)? "s" : ""));
            else
                stringBuilder.Append("with no sugar");

            // Adding stick
            if(ingredients[2] == "0")
                stringBuilder.Append(" and a stick");
            else if(ingredients[0].Length < 2)
                stringBuilder.Append(" and no stick");

            return stringBuilder.ToString();
        }

        public static string CreateDrink(string order, double money)
        {
            string[] ingredients = order.Split(':');
            switch (ingredients[0])
            {
                case "O":
                    if (money < 0.6)
                        return "You need " + (0.6 - money).ToString();
                    break;
                case "C":
                case "Ch":
                    if (money < 0.6)
                        return "You need " + (0.6 - money).ToString();
                    break;
                case "T":
                case "Th":
                    if (money < 0.4)
                        return "You need " + (0.4 - money).ToString();
                    break;
                case "H":
                case "Hh":
                    if (money < 0.5)
                        return "You need " + (0.5 - money).ToString();
                    break;
                default:
                    return "Bad order";
            }

            return CreateDrink(order);
        }

        public static List<string> Report()
        {
            return report.Sold();
        }

        public static void ResetData()
        {
            report = new Report();
            notifier = new EmailNotifier();
        }
    }
}
