namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void TestConstructorWorksProperly()
        {
            var car = new Car("Make", "BMW", 3.45, 67);

            Assert.AreEqual("Make", car.Make);
            Assert.AreEqual("BMW", car.Model);
            Assert.AreEqual(3.45, car.FuelConsumption);
            Assert.AreEqual(67, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        
        [Test]
        public void TestMakeSetterThrowsException()
        {
            var make = string.Empty;
            

           Assert.Throws<ArgumentException>(() =>
           {
               var car = new Car(make, "BMW", 3.45, 67);
               var car2 = new Car(null, "BMW", 3.45, 67);
           });
        }

        [Test]
        public void TestModelSetterThrowsException()
        {
            var model = string.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car("Make", model, 3.45, 67);
                var car2 = new Car("Make", null, 3.45, 67);
            });
        }

        [Test]
        public void TestFuelConsumptionSetterThrowsException()
        {
            var consumption1 = 0;
            var consumption2 = -1;
            var consumption3 = -45;

            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car("Make", "BMW", consumption1, 67);
                var car2 = new Car("Make", "BMW", consumption2, 67);
                var car3 = new Car("Make", "BMW", consumption3, 67);
            });
        }

        [Test]
        public void TestFuelCapacitySetterThrowsException()
        {
          
            var capacity1 = -1;
            var capacity2 = -45;
            var capacity3 = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car("Make", "BMW", 3.56, capacity1);
                var car2 = new Car("Make", "BMW", 3.45, capacity2);
                var car3 = new Car("Make", "BMW", 3.45, capacity3);
            });
        }

        [Test]
        public void TestRefuelMethodThrowsException()
        {
            var car = new Car("Make", "BMW", 3.56, 88);

           
            var fuelToRefuel1 = -1;
            var fuelToRefuel2 = -45;
            var fuelToRefuel3 = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel1);
                car.Refuel(fuelToRefuel2);
                car.Refuel(fuelToRefuel3);
            });
        }

        [Test]
        public void TestRefuelMethodWorksProperly()
        {
            var car = new Car("Make", "BMW", 3.56, 88);

            var fuelToRefuel1 = 30;

            car.Refuel(fuelToRefuel1);

            Assert.AreEqual(30, car.FuelAmount);
        }

        [Test]
        public void TestRefuelMethodWorksProperlyForExtraFuelAmount()
        {
            var car = new Car("Make", "BMW", 3.56, 88);

            var fuelToRefuel1 = 90;

            car.Refuel(fuelToRefuel1);

            Assert.AreEqual(88, car.FuelAmount);
        }

        [Test]
        public void TestDriveMethodForFuelNeededThrowsException()
        {
            var car = new Car("Make", "BMW", 3.00, 88);

            double distance = 50;

           Assert.Throws<InvalidOperationException>(() =>
           {
               car.Drive(distance);
           });
        }

        [Test]
        public void TestDriveMethodWorksCorrectly()
        {
            var car = new Car("Make", "BMW", 10, 88);

            var fuelToRefuel1 = 30;

            car.Refuel(fuelToRefuel1);

            car.Drive(40.00);

            Assert.AreEqual(26, car.FuelAmount);
        }
    }
}