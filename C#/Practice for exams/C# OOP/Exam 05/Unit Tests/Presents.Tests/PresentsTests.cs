namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void EstimateConstructorWorksCorrectly()
        {
            var bag = new Bag();

            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void EstimateCreateMethodHasCorrectExecution()
        {
            var bag = new Bag();
            var present = new Present("Cake", 56);

            bag.Create(present);

            Assert.AreEqual(1, bag.GetPresents().Count);
        }

        [Test]
        public void EstimateCreatheMethodThrowsExceptionWhenPresentIsNull()
        {
            var bag = new Bag();

           Assert.Throws<ArgumentNullException>(() =>
           {
               bag.Create(null);

           }, "Present cannot be null");
        }

        [Test]
        public void EstimateCreateMethodThrowsExceptionWhenPresentExists()
        {
            var bag = new Bag();
            var present = new Present("Cake", 56);

            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            }, "Present already exists");
                
        }

        [Test]
        public void EstimateCreateMethodReturnsCorrectMessage()
        {
            var bag = new Bag();
            var present = new Present("Cake", 56);

            var actualText = bag.Create(present);

            Assert.AreEqual("Successfully added present Cake.", actualText);
        }

        [Test]
        public void EstimateRemoveMethodWorksCorrectly()
        {
            var bag = new Bag();
            var present = new Present("Cake", 56);
            var present2 = new Present("Toy", 256);
            var present3 = new Present("Computer", 1256);

            bag.Create(present);
            bag.Create(present2);

            bool actualResult = bag.Remove(present);
            bool actualResult2 = bag.Remove(present3);

            Assert.AreEqual(true, actualResult);
            Assert.AreEqual(false, actualResult2);
        }

        [Test]
        public void EstimateGetPresentWithLeastMagicReturnsTheCorrectOne()
        {
            var bag = new Bag();
            var present = new Present("Cake", 56);
            var present2 = new Present("Toy", 256);
            var present3 = new Present("Computer", 1256);

            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            var presentWithLeastMagic = bag.GetPresentWithLeastMagic();

            Assert.AreEqual("Cake", presentWithLeastMagic.Name);
        }

        [Test]
        public void EstimateGetPresentWorksCorrectly()
        {
            var bag = new Bag();
            var present = new Present("Cake", 56);
            var present2 = new Present("Toy", 256);
            var present3 = new Present("Computer", 1256);

            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            var gottenPresent = bag.GetPresent("Computer");
            var gottenPresentNull = bag.GetPresent("Chocolate");

            Assert.AreEqual(present3, gottenPresent);
            Assert.AreEqual(null, gottenPresentNull);
        }
    }
}
