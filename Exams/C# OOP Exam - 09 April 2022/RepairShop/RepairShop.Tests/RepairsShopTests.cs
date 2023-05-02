using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private string SetUpCatName = "BMW";
            private int SetUpCarIssues = 100;
            private Garage fillingGarage;


            [SetUp]

            public void SetUP()
            {
                fillingGarage = new Garage("Ivan", 3);
                fillingGarage.AddCar(new Car("Opel",1000));
                fillingGarage.AddCar(new Car("Bmw", 11111111));
                fillingGarage.AddCar(new Car("Mercedes", 1));

            }


            [Test]
            public void TestingCarConstructor()
            {
                string expectedCarName = "BMW";
                int expectedCarIssues = 100;
                Car car = new Car(SetUpCatName, SetUpCarIssues);
                Assert.AreEqual(expectedCarName, car.CarModel);
                Assert.AreEqual(expectedCarIssues, car.NumberOfIssues);
            }


            [Test]
            public void TestingGarageConstructor()
            {
                var Garage = new Garage("BMWGarage", 100);
                Assert.AreEqual(Garage.Name, "BMWGarage");
                Assert.AreEqual(Garage.MechanicsAvailable, 100);
            }

            [Test]
            public void GarageNameThrowsException()
            {
                string garageName = "";
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var Garage = new Garage(garageName, 10);
                });
            }

            [Test]
            public void GarageMechanicsThrowsException()
            {
                int mechanicsAvailable = -1;
                Assert.Throws<ArgumentException>(() =>
                {
                    var Garage = new Garage("Pesho", mechanicsAvailable);
                });
            }
            [Test]
            public void AddMethodShoudlThrowExceptionWhenFull()
            {
                Car car = new Car("Audi", 2);
                Assert.Throws<InvalidOperationException>(() => 
                {
                  fillingGarage.AddCar(car);
                });
            }

            [Test]
            public void FixCarShouldThrowExceptionWhenInvalid()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    fillingGarage.FixCar("Yakudza");
                });
            }
        }
    }
}