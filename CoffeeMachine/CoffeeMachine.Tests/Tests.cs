using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Nunit_works()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void T1_Drink_asked_are_created()
        {
            string drinkOne = DrinkFactory.CreateDrink("T:1:0");
            string drinkTwo = DrinkFactory.CreateDrink("H::");
            string drinkThree = DrinkFactory.CreateDrink("C:2:0");

            Assert.AreEqual(drinkOne, "Drink maker makes 1 tea with 1 sugar and a stick");
            Assert.AreEqual(drinkTwo, "Drink maker makes 1 chocolate with no sugar and no stick");
            Assert.AreEqual(drinkThree, "Drink maker makes 1 coffee with 2 sugars and a stick");
        }

        [Test]
        public void T2_Drink_are_payed()
        {
            string drinkOne = DrinkFactory.CreateDrink("T:1:0", 0.1);
            string drinkTwo = DrinkFactory.CreateDrink("H::", 1);
            string drinkThree = DrinkFactory.CreateDrink("C:2:0", 0.6);

            Assert.AreEqual(drinkOne, "You need 0,3");
            Assert.AreEqual(drinkTwo, "Drink maker makes 1 chocolate with no sugar and no stick");
            Assert.AreEqual(drinkThree, "Drink maker makes 1 coffee with 2 sugars and a stick");
        }

        [Test]
        public void T3_Added_OrangeJuice_and_HotDrinks()
        {
            string drinkZero = DrinkFactory.CreateDrink("O::", 0.3);
            string drinkOne = DrinkFactory.CreateDrink("O::", 0.6);
            string drinkTwo = DrinkFactory.CreateDrink("Ch::", 1);
            string drinkThree = DrinkFactory.CreateDrink("Hh:1:0", 0.6);
            string drinkFour = DrinkFactory.CreateDrink("Th:2:0", 0.6);

            Assert.AreEqual(drinkZero, "You need 0,3");
            Assert.AreEqual(drinkOne, "Drink maker will make one orange juice");
            Assert.AreEqual(drinkTwo, "Drink maker will make an extra hot coffee with no sugar");
            Assert.AreEqual(drinkThree, "Drink maker will make an extra hot chocolate with one sugar and a stick");
            Assert.AreEqual(drinkFour, "Drink maker will make an extra hot tea with two sugar and a stick");
        }

        [Test]
        public void T4_number_of_each_sold()
        {
            DrinkFactory.ResetData();

            DrinkFactory.CreateDrink("T::", 1);
            DrinkFactory.CreateDrink("Ch::", 1);
            DrinkFactory.CreateDrink("Ch::", 1);
            string drinkZero = DrinkFactory.CreateDrink("O::", 0.3);
            string drinkOne = DrinkFactory.CreateDrink("O::", 0.6);
            string drinkTwo = DrinkFactory.CreateDrink("Ch::", 1);
            string drinkThree = DrinkFactory.CreateDrink("Hh:1:0", 0.6);
            string drinkFour = DrinkFactory.CreateDrink("Th:2:0", 0.6);

            List<string> list = DrinkFactory.Report();

            Assert.Contains("Number of tea : 1", list);
            Assert.Contains("Number of hot coffee : 3", list);
            Assert.Contains("Number of orange juice : 1", list);
            Assert.Contains("Number of chocolate : 0", list);
            Assert.Contains("Number of hot chocolate : 1", list);
            Assert.Contains("Number of hot tea : 1", list);
            Assert.Contains("Number of coffee : 0", list);
        }
    }
}
