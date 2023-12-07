using System;
using System.Collections.Generic;
using System.Linq;
using Farmer.Domain;
using Farmer.Domain.Collection;
using Farmer.Domain.Plants;

namespace Farmer
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Berry blackberry = new Berry(true, true, false, "Blackberry", "Back", DateTime.Now, false);
            Berry strawberry = new Berry(false, true, false, "Strawberry", "Red", DateTime.Now, true);
            Berry cowberry = new Berry(false, false, true, "Cowberry", "Red", DateTime.Now, true);
            
            Fruit apple = new Fruit("Сладкий", true,"Яблоко", "зеленый", DateTime.Now, false);
            Fruit pear = new Fruit("Сладкий", true,"Груша", "зеленый",  DateTime.Now, false);
            
            Vegetable eggplant = new Vegetable(12.3, "Бакалажан", "фиолетовый", DateTime.Now, false);
            Vegetable cucumber = new Vegetable(2.45, "Огурец", "зелёный",  DateTime.Now, false);

            IImmutableList<Berry> berries = ListFactory.ListOf(blackberry, strawberry, cowberry);
            IImmutableList<Fruit> fruits = ListFactory.ListOf(apple, pear);
            IImmutableList<Vegetable> vegetables = ListFactory.ListOf(eggplant, cucumber);
            
            var farmers = new List<Granger>
            {
                new Granger("Иван"),
                new Granger("Василий"),
                new Granger("Николай"),
                new Granger("Артём"),
                new Granger("Егор"),
                new Granger("Данила"),
                new Granger("Марк"),
                new Granger("Илья"),
                new Granger("Макар"),
                new Granger("Арсений"),
                new Granger("Андрей"),
                new Granger("Петр"),
                new Granger("Александр"),
                new Granger("Максим")
            };

            Farm<Berry> berryFarm = new Farm<Berry>();
            berryFarm.AddPlants(berries);
            berryFarm.AddFarmers(farmers.Where((farmer) => farmer.Name.StartsWith("А")));
            berryFarm.CollectHarvest();

            PrintFarmers("--> Фермеры на ферме ягод <--", berryFarm.Farmers);

            Farm<Fruit> fruitFarm = new Farm<Fruit>();
            fruitFarm.AddPlants(fruits);
            fruitFarm.AddFarmers(farmers.Where((framer) => framer.Name.StartsWith("М")));
            fruitFarm.CollectHarvest();
            
            PrintFarmers("--> Фермеры на ферме фруктов <--", fruitFarm.Farmers);

            Farm<Vegetable> vegetableFarm = new Farm<Vegetable>();
            vegetableFarm.AddPlants(vegetables);
            vegetableFarm.AddFarmers(farmers.Where((framer) => framer.Name.StartsWith("И")));
            vegetableFarm.CollectHarvest();
            
            PrintFarmers("--> Фермеры на ферме овощей <--", vegetableFarm.Farmers);

            IImmutableList<Plant> allPlants =
                ListFactory.ListOf<Plant>(blackberry, strawberry, cowberry, apple, pear, eggplant, cucumber);
            Farm<Plant> allFarm = new Farm<Plant>();
            allFarm.AddPlants(allPlants);
        }

        private static void PrintFarmers(string message, IDictionary<Guid, Granger> farmers)
        {
            Console.WriteLine(message);
            foreach (var farmer in farmers.Values)
            {
                Console.WriteLine($"{farmer.Name} ({farmer.HarvestCount})");
            }
        }
    }
}