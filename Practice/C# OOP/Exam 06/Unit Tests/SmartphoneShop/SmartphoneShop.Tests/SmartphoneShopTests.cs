using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {

        [Test]
        public void TestConstructorInitializesEmptyCollectionOfSmartphones()
        {
            Shop shop = new Shop(4);

            List<Smartphone> expectedPhones = new List<Smartphone>();

            List<Smartphone> actualSmartphones = new List<Smartphone>();

            Assert.AreEqual(expectedPhones.Count, actualSmartphones.Count);

        }

        [Test]
        public void TestConstructorForCapacityProperty()
        {

            Shop expectedShop = new Shop(4);

            Assert.AreEqual(4, expectedShop.Capacity);
        }

        [Test]
        public void TestCapacitySetter()
        {
            int capaicty = -4;


            Assert.Throws<ArgumentException>(() =>
            {
                new Shop(capaicty);
            }, "Invalid capacity.");

        }

        [Test]

        public void EmptyShopShouldHaveCountOf0()
        {
            var shop = new Shop(4);

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void ShopShouldHaveProperCount()
        {
            var shop = new Shop(4);

            shop.Add(new Smartphone("Xiaomi", 120));
            shop.Add(new Smartphone("Samsung", 190));
            shop.Add(new Smartphone("IPhone", 100));

            Assert.AreEqual(3, shop.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenDoubleNames()
        {
            var shop = new Shop(4);

            shop.Add(new Smartphone("Xiaomi", 120));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Xiaomi", 100));
            }, "The phone model already exist.");

        }

        [Test]
        public void AddShouldThrowExceptionWhenCapacityIsReached()
        {
            var shop = new Shop(2);

            shop.Add(new Smartphone("Xiaomi", 120));
            shop.Add(new Smartphone("IPhone", 124));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Xiaomi", 100));
            }, "The shop is full.");
        }

        [Test]

        public void RemoveShouldWorkProperly()
        {
            var shop = new Shop(2);

            shop.Add(new Smartphone("Xiaomi", 120));
            shop.Add(new Smartphone("IPhone", 124));

            shop.Remove("IPhone");

            Assert.That(shop.Count == 1);

            shop.Remove("Xiaomi");

            Assert.AreEqual(0, shop.Count);
        }

        [Test]

        public void RemoveNullWithException()
        {
            var shop = new Shop(2);

            shop.Add(new Smartphone("Xiaomi", 120));
            shop.Add(new Smartphone("IPhone", 124));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Samsung");

            }, "Phone can not be null");
        }

        [Test]
        public void TestBatteryUsageWorkingProperly()
        {
            var shop = new Shop(2);
            var smartphone = new Smartphone("Xiaomi", 120);
            shop.Add(smartphone);
            shop.Add(new Smartphone("IPhone", 124));

            shop.TestPhone("Xiaomi", 50);

            Assert.AreEqual(70, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestBatteryUsageShouldThrowExceptionIfSmartphoneIsNotFound()
        {
            var shop = new Shop(2);
            var smartphone = new Smartphone("Xiaomi", 120);
            shop.Add(smartphone);
            shop.Add(new Smartphone("IPhone", 124));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Samsung", 50);
            });
        }

        [Test]
        public void TestLowBatteryThrowingException()
        {
            var shop = new Shop(2);
            var smartphone = new Smartphone("Xiaomi", 120);
            shop.Add(smartphone);
            shop.Add(new Smartphone("IPhone", 124));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Xiaomi", 130);
            });
        }

        [Test]

        public void TestIfChargePhoneMethodIsWorkingProperly()
        {
            var shop = new Shop(2);
            var smartphone = new Smartphone("Xiaomi", 120);
            shop.Add(smartphone);
            shop.Add(new Smartphone("IPhone", 124));

            shop.TestPhone("Xiaomi", 20);

            shop.ChargePhone("Xiaomi");

            Assert.AreEqual(120, smartphone.CurrentBateryCharge);
        }


        [Test]

        public void TestIfChargePhoneMethodThrowsExceptionWhenValueIsNull()
        {
            var shop = new Shop(2);
            var smartphone = new Smartphone("Xiaomi", 120);
            shop.Add(smartphone);
            shop.Add(new Smartphone("IPhone", 124));

            shop.TestPhone("Xiaomi", 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
            shop.ChargePhone("Samsung");
            });
        }
    }
}
       
