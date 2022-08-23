using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {

        // Implement unit tests here

        [Test]
        public void TestConstructorWorksProperly()
        {
            string gymName = "Athletic";
            int gymSize = 45;

            var athletes = new List<Athlete>();

            var gym = new Gym(gymName, gymSize);

            Assert.AreEqual("Athletic", gym.Name);
            Assert.AreEqual(45, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void TestSetterForNamePropertyHandlingException()
        {
            int capacity = 45;
            string name1 = null;
            string name2 = string.Empty;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var gym1 = new Gym(name1, capacity);
                var gym2 = new Gym(name2, capacity);
            }, "Name cannot be null or empty");
        }

        [Test]
        public void TestSetterForNamePropertyWorksCorrectly()
        {
            string name = "Athletic";
            int capacity = 100;

            var gym = new Gym(name, capacity);

            Assert.AreEqual("Athletic", gym.Name);
        }

        [Test]
        public void TestSetterForCapacityPropHandlingException()
        {
            int capacity = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                var gym = new Gym("Athletic", capacity);
            }, "Invalid gym capacity.");
        }

        [Test]
        public void TestSetterForCapacityPropWorksCorrectly()
        {
            int capacity = 10;

            var gym = new Gym("Athletic", capacity);

            Assert.AreEqual(capacity, gym.Capacity);
        }

        [Test]
        public void TestCounterReturnsCorrectValue()
        {
            var gym = new Gym("Athletic", 45);

            var athlete1 = new Athlete("James");
            var athlete2 = new Athlete("Alex");
            var athlete3 = new Athlete("John");

            //Also tested Add method for correct values
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete3);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(3, gym.Count);
        }

        [Test]
        public void TestForFullGymException()
        {
            var gym = new Gym("Athletic", 3);

            var athlete1 = new Athlete("James");
            var athlete2 = new Athlete("Alex");
            var athlete3 = new Athlete("John");
            var athlete4 = new Athlete("Samantha");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete3);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
           {
               gym.AddAthlete(athlete4);
           }, "Gym is full! Cannot add more athletes");
        }

        [Test]
        public void TestRemoveAthleteMethodWorksProperly()
        {
            var gym = new Gym("Athletic", 3);

            var athlete1 = new Athlete("James");
            var athlete2 = new Athlete("Alex");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            gym.RemoveAthlete(athlete1.FullName);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void TestForNonExistingAthlete()
        {
            var gym = new Gym("Athletic", 3);

            var athlete1 = new Athlete("James");
            var athlete2 = new Athlete("Alex");
            var athlete3 = new Athlete("John");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

           Assert.Throws<InvalidOperationException>(() =>
           {
               gym.RemoveAthlete(athlete3.FullName);
           }, "Athlete does not exist!");
        }

        [Test]
        public void InjuredAthleteMethodWorksProperly()
        {

            var gym = new Gym("Athletic", 3);
            var athlete1 = new Athlete("James");
            var athlete2 = new Athlete("Alex");

            gym.AddAthlete(athlete1);

            var athlete = gym.InjureAthlete(athlete1.FullName);
            
            Assert.AreEqual(true, athlete.IsInjured);
        }

        [Test]
        public void InjuredAthleteMethodExceptionHandling()
        {
            var gym = new Gym("Athletic", 3);
            var athlete1 = new Athlete("James");
            var athlete2 = new Athlete("Alex");

            gym.AddAthlete(athlete1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var athlete = gym.InjureAthlete(athlete2.FullName);
            }, "Athlete does not exist.");
        }

        [Test]
        public void TestReportMehtodWorksProperly()
        {
            var gym = new Gym("Athletic", 3);
            var athlete1 = new Athlete("James");
            var athlete2 = new Athlete("Alex");
            var athlete3 = new Athlete("John");

        
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            gym.InjureAthlete(athlete1.FullName);

            string expectedReport = $"Active athletes at Athletic: Alex, John";

            string actualReport = gym.Report();

            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
