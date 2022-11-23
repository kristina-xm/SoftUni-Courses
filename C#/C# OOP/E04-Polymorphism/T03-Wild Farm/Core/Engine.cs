
namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Exceptions;
    using WildFarm.Factories.Interfaces;
    using WildFarm.Models.Animals;
    using WildFarm.Models.Foods;

    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;
        public void Start()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalsArgs = command.Split();
                    string[] foodArguments = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);


                    Food food = this.foodFactory.CreateFood(foodArguments[0], int.Parse(foodArguments[1]));

                    Animal animal = null;
                    if (animalsArgs.Length == 4)
                    {
                        animal = this.animalFactory.CreateAnimal(animalsArgs[0], animalsArgs[1], double.Parse(animalsArgs[2]), animalsArgs[3]);
                    }
                    else if (animalsArgs.Length == 5)
                    {
                        animal = this.animalFactory.CreateAnimal(animalsArgs[0], animalsArgs[1], double.Parse(animalsArgs[2]), animalsArgs[3], animalsArgs[4]);
                    }
                    

                    Console.WriteLine(animal.ProduceSound());

                    this.animals.Add(animal);

                    animal.Eat(food);

                }
                catch (InvalidFactoryTypeException ifte)
                {

                    Console.WriteLine(ifte.Message);
                   
                }
                catch(FoodNotPreferredException fnpe)
                {
                    Console.WriteLine(fnpe.Message);
               
                }   
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);

                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory) : this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
            
        }
    }

    //private Animal BuildAnimalFactory(string[] cmdArgs)
    //{

    //    Animal animal;
    //    if (animalsArgs.Length == 4)
    //    {
    //        animal = this.animalFactory.CreateAnimal(animalsArgs[0], animalsArgs[1], double.Parse(animalsArgs[2]), animalsArgs[3]);
    //    }
    //    else if (animalsArgs.Length == 5)
    //    {
    //        animal = this.animalFactory.CreateAnimal(animalsArgs[0], animalsArgs[1], double.Parse(animalsArgs[2]), animalsArgs[3], animalsArgs[4]);
    //    }
    //    else
    //    {
    //        throw new ArgumentException("Invalid input");
    //    }
    //    return animal;
    //}
}
