namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void EstimateConstructorWorksCorrectly()
        {
            int capacity = 50;

            RobotManager rmanager = new RobotManager(capacity);

            Assert.AreEqual(0, rmanager.Count);
            Assert.AreEqual(50, rmanager.Capacity);
        }

        [Test]
        public void EstimateCapacityPropertyWorksCorrectly()
        {
            int capacity = 56;

            RobotManager rmanager = new RobotManager(capacity);

            Assert.AreEqual(56, rmanager.Capacity);
        }

        [Test]
        public void EstimateCapacityThrowsExceptionWithNegativeValue()
        {
            int capacity = - 86;

            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager rmanager = new RobotManager(capacity);
            }, "Invalid capacity!");
        }

        [Test]
        public void EstimateCounterReturnsCorrectValue()
        {
            int capacity = 56;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);
            var robot2 = new Robot("L67", 130);
            var robot3 = new Robot("MK5", 2);

            rmanager.Add(robot1);
            rmanager.Add(robot2);
            rmanager.Add(robot3);

            Assert.AreEqual(3, rmanager.Count);
        }

        [Test]
        public void EstimateAddMethodThrowsExceptionWhenRobotExists()
        {
            int capacity = 56;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);
            var robot2 = new Robot("L67", 130);
            var robot3 = new Robot("MK5", 2);

            rmanager.Add(robot1);
            rmanager.Add(robot2);
            rmanager.Add(robot3);

           Assert.Throws<InvalidOperationException>(() =>
           {
               rmanager.Add(robot3);
           }, "This robot already exists");
        }

        [Test]
        public void EstimateAddMethodThrowsExceptionWhenCapacityIsNotEngough()
        {
            int capacity = 3;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);
            var robot2 = new Robot("L67", 130);
            var robot3 = new Robot("MK5", 2);
            var robot4 = new Robot("PK5r4t", 2);

            rmanager.Add(robot1);
            rmanager.Add(robot2);
            rmanager.Add(robot3);

           Assert.Throws<InvalidOperationException>(() =>
           {
               rmanager.Add(robot4);
           }, "Not enough space for more robots!");
        }

        [Test]
        public void EstimateRemoveMethodWorksCorrectly()
        {
            int capacity = 10;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);
            var robot2 = new Robot("L67", 130);
            var robot3 = new Robot("MK5", 2);
            var robot4 = new Robot("PK5r4t", 2);

            rmanager.Add(robot1);
            rmanager.Add(robot2);
            rmanager.Add(robot3);
            rmanager.Add(robot4);

            rmanager.Remove(robot4.Name);

            Assert.AreEqual(3, rmanager.Count);
        }

        [Test]
        public void EstimateRemoveMethodThrowsExceptionWhenRobotIsNull()
        {
            int capacity = 10;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);
            var robot2 = new Robot("L67", 130);

            rmanager.Add(robot1);
            rmanager.Add(robot2);

            var robot3 = new Robot("MK5", 2);

           Assert.Throws<InvalidOperationException>(() =>
           {
               rmanager.Remove(robot3.Name);
           }, "This robot does not exist");
        }

        [Test]
        public void EstimateWorkMethodWorksCorrectly()
        {
            int capacity = 10;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);
            var robot2 = new Robot("L67", 130);

            rmanager.Add(robot1);
            rmanager.Add(robot2);

            rmanager.Work(robot1.Name, "Clean the kitchen", 50);

            Assert.AreEqual("L45", robot1.Name);
            Assert.AreEqual(40, robot1.Battery);

        }

        [Test]
        public void EstimateWorkMethodThrowsExceptionWhenNonExistingRobot()
        {
            int capacity = 10;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);
            var robot2 = new Robot("L67", 130);
            var robot3 = new Robot("OIGNR9", 130);

            rmanager.Add(robot1);
            rmanager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                rmanager.Work(robot3.Name, "Cook a cake", 45);

            }, "Robot does not exists.");  
        }

        [Test]
        public void EstimateWorkMethodThrowsExcpetionWhenBatteryNotEnough()
        {
            int capacity = 10;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);

            rmanager.Add(robot1);

           Assert.Throws<InvalidOperationException>(() =>
           {
               rmanager.Work(robot1.Name, "Build a house", 91);
           });
        }

        [Test]
        public void EstimateChargeMethodWorksCorrectly()
        {
            int capacity = 10;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);

            rmanager.Add(robot1);

            rmanager.Work(robot1.Name, "Go to the garden", 30);

            rmanager.Charge(robot1.Name);

            Assert.AreEqual(90, robot1.Battery);
        }

        [Test]
        public void EstimateChargeMethodThrowsExcpetionWhenRobotDoesNotExist()
        {
            int capacity = 10;

            RobotManager rmanager = new RobotManager(capacity);

            var robot1 = new Robot("L45", 90);
            var robot2 = new Robot("222", 90);

            rmanager.Add(robot1);

           Assert.Throws<InvalidOperationException>(() =>
           {
               rmanager.Charge(robot2.Name);
           },"Robot does not exist");
        }
    }
}
