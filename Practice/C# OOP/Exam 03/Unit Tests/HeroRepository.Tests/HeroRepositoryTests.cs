using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
    }

    [Test]
    public void TestConstructorWorksProperly()
    {
        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateMethodWorksPropery()
    {
        var hero = new Hero("Batman", 6);

        heroRepository.Create(hero);

        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateMethodThrowsExceptionWhenHeroIsNull()
    {
       Assert.Throws<ArgumentNullException>(() =>
       {
           heroRepository.Create(null);
       }, "Hero is null");

    }

    [Test]
    public void CreateMethodThrowsExceptionWhenHeroExists()
    {
        var hero = new Hero("Batman", 6);

        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        }, "Hero already exists!");
    }

    [Test]
    public void TestRemoveHeroMethodWorksProperyl()
    {
        var hero1 = new Hero("Batman", 20);
        var hero2 = new Hero("Spiderman", 45);

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        heroRepository.Remove("Batman");

        Assert.AreEqual(1, heroRepository.Heroes.Count);

    }

    [Test]
    public void TestRemoveHeroMethodThrowsAnExcetpionWhenNameIsNull()
    {
        var hero1 = new Hero("   ", 20);
        var hero2 = new Hero(String.Empty, 45);

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

       Assert.Throws<ArgumentNullException>(() =>
       {
           heroRepository.Remove(hero1.Name);
           heroRepository.Remove(hero2.Name);

       });

    }

    [Test]
    public void TestGetHeroWithHighestLevelWorksProperly()
    {
        var hero1 = new Hero("Batman", 20);
        var hero2 = new Hero("Barbie", 78);
        var hero3 = new Hero("Spiderman", 45);

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);

        var actualHero = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual("Barbie", actualHero.Name);

    }

    [Test]
    public void TestGetHeroMethodWorkProperly()
    {
        var hero1 = new Hero("Batman", 20);
        var hero2 = new Hero("Barbie", 78);
        var hero3 = new Hero("Spiderman", 45);

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);

        var actualHero = heroRepository.GetHero("Batman");
        int expectedHeroLevel = 20;

        Assert.AreEqual(expectedHeroLevel, actualHero.Level);
    }

}