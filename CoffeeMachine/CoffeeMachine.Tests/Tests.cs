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
        public void Drink_asked_are_created()
        {
            string drinkOne = DrinkFactory.CreateDrink("T:1:0");
            string drinkTwo = DrinkFactory.CreateDrink("H::");
            string drinkThree = DrinkFactory.CreateDrink("C:2:0");

            Assert.AreEqual(drinkOne, "Drink maker makes 1 tea with 1 sugar and a stick");
            Assert.AreEqual(drinkTwo, "Drink maker makes 1 chocolate with no sugar and no stick");
            Assert.AreEqual(drinkThree, "Drink maker makes 1 coffee with 2 sugars and a stick");
        }
    }
}
