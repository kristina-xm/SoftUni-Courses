namespace PlanetWars.Tests
{
    using NUnit.Framework;
    using System;
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void EstimateWeaponConstructor_WorksCorrectly()
            {
                var weapon = new Weapon("Gun", 679, 40);
                
                Assert.AreEqual("Gun", weapon.Name);
                Assert.AreEqual(679, weapon.Price);
                Assert.AreEqual(40, weapon.DestructionLevel);
            }

            [Test]
            public void EstimatePriceProperty_ThrowsAnException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var weapon = new Weapon("Gun", -15, 40);
                }, "Price cannot be negative.");
            }

            [Test]
            public void EstimateIncreaseDestructionLevelMethod_WorksCorrectly()
            {
                var weapon = new Weapon("Gun", 679, 40);
                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(41, weapon.DestructionLevel);
            }

            [Test]
            public void EstimateIsNuclearProperty_WorksProperly()
            {
                var weapon = new Weapon("Gun", 679, 9);
                var weapon2 = new Weapon("Gun2", 679, 10);

                Assert.AreEqual(false, weapon.IsNuclear);
                Assert.AreEqual(true, weapon2.IsNuclear);
            }

            [Test]
            public void EstimateConstructorOfPlanet_WorksProperly()
            {
                var planet = new Planet("Earth", 30);

                Assert.AreEqual("Earth", planet.Name);
                Assert.AreEqual(30, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);   
            }

            [Test]
            public void EstimateNameProperty_ThrowsAnException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet(null, 30);
                    var planet2 = new Planet(string.Empty, 30);

                }, "Invalid planet Name");
            }

            [Test]
            public void EstimateBudgetProperty_ThrowsAnException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet("Mars", -30);
                    var planet2 = new Planet("Jupiter", -1);

                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void EstimateWeaponsProperty_ReturnsCorrectCount()
            {
                var planet2 = new Planet("Mercury", 30);

                var weapon = new Weapon("Gun", 679, 9);
                var weapon2 = new Weapon("Gun2", 679, 10);

                planet2.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);

                Assert.AreEqual(2, planet2.Weapons.Count);

            }

            [Test]
            public void EstimateMilitaryPowerRation_ReturnsCorrectSum()
            {
                var planet2 = new Planet("Mercury", 30);

                var weapon = new Weapon("Gun", 20, 9);
                var weapon2 = new Weapon("Gun2", 15, 10);

                planet2.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);

                Assert.AreEqual(19, planet2.MilitaryPowerRatio);
            }

            [Test]
            public void EstimateProfitMethod_WorksCorrectly()
            {
                var planet2 = new Planet("Mercury", 30);

                planet2.Profit(200);

                Assert.AreEqual(230, planet2.Budget);
            }

            [Test]
            public void EstimateSpendFunds_WorkCorrectly()
            {
                var planet2 = new Planet("Mercury", 120);

                planet2.SpendFunds(30);

                Assert.AreEqual(90, planet2.Budget);
            }

            [Test]
            public void EstimateSpendFunds_ThrowsException()
            {
                var planet2 = new Planet("Mercury", 120);
                var planet3 = new Planet("Mercury", 180);

                Assert.Throws<InvalidOperationException>(() =>
               {
                   planet2.SpendFunds(121);
                   planet3.SpendFunds(200);

               }, "Not enough funds to finalize the deal.");
            }

            [Test]
            public void EstimateAddWeapon_WorksProperly()
            {
                var planet2 = new Planet("Mercury", 30);

                var weapon = new Weapon("Gun", 20, 20);
                var weapon2 = new Weapon("Gun3", 15, 10);

                planet2.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);

                Assert.AreEqual(2, planet2.Weapons.Count);

            }

            [Test]
            public void EstimateAddWeapon_ThrowsException()
            {
                var planet2 = new Planet("Mercury", 30);

                var weapon = new Weapon("Gun", 20, 20);
                var weapon2 = new Weapon("Gun", 15, 10);

                planet2.AddWeapon(weapon);
               

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet2.AddWeapon(weapon2);

                }, "Weapon already exists");
            }

            [Test]
            public void EstimateRemoveWeaponMethod_WorksProperly()
            {
                var planet2 = new Planet("Mercury", 30);

                var weapon = new Weapon("Gun", 20, 20);
                var weapon2 = new Weapon("Gun3", 15, 10);

                planet2.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);

                planet2.RemoveWeapon(weapon.Name);

                Assert.AreEqual(1, planet2.Weapons.Count);
            }

            [Test]
            public void EstimateUpgradeWeapon_WorksCorrectly()
            {
                var planet = new Planet("Mercury", 30);

                var weapon = new Weapon("Gun", 20, 80);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);

                Assert.AreEqual(81, weapon.DestructionLevel);
            }

            [Test]
            public void EstimateUpgradeWeapon_ThrowsException()
            {
                var planet = new Planet("Mercury", 30);

                var weapon = new Weapon("Gun", 20, 80);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(weapon.Name);
                }, "Weapon not found in the repository");
            }

            [Test]
            public void EstimateDestructOpponentMethod_WorksCorrectly()
            {
                var planet = new Planet("Jupiter", 1245);

                var weapon = new Weapon("A95", 40, 100);
                var weapon2 = new Weapon("B75", 40, 120);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                var opponentPlanet = new Planet("Earth", 330);

                var opponentWeapon = new Weapon("A95", 40, 60);
                var opponentWeapon2 = new Weapon("B75", 40, 120);

                var result = planet.DestructOpponent(opponentPlanet);

                Assert.AreEqual("Earth is destructed!", result);
            }

            [Test]
            public void EstimateDestructOpponentMethod_ThrowsExceptionWhenEqual()
            {
                var planet = new Planet("Jupiter", 1245);

                var weapon = new Weapon("A95", 40, 100);
                var weapon2 = new Weapon("B75", 40, 120);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                var opponentPlanet = new Planet("Earth", 6330);

                var opponentWeapon = new Weapon("A95", 40, 100);
                var opponentWeapon2 = new Weapon("B75", 40, 120);

                opponentPlanet.AddWeapon(opponentWeapon);
                opponentPlanet.AddWeapon(opponentWeapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponentPlanet);

                }, "Opponent is too strong");
            }

            [Test]
            public void EstimateDestructOpponentMethod_ThrowsException()
            {
                var planet = new Planet("Jupiter", 1245);

                var weapon = new Weapon("A95", 40, 100);
                var weapon2 = new Weapon("B75", 40, 120);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                var opponentPlanet = new Planet("Earth", 330);

                var opponentWeapon = new Weapon("A95", 40, 400);
                var opponentWeapon2 = new Weapon("B75", 40, 120);

                opponentPlanet.AddWeapon(opponentWeapon);
                opponentPlanet.AddWeapon(opponentWeapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponentPlanet);

                }, "Opponent is too strong");
            }
        }
    }
}
