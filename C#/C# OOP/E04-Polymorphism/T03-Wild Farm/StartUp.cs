﻿namespace WildFarm
{
    using System;
    using WildFarm.Core;
    using WildFarm.Factories.Interfaces;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            IEngine engine = new Engine(foodFactory, animalFactory);
            engine.Start();


        }
    }
}
