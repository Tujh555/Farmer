using System;
using System.Collections.Generic;
using System.Linq;
using Farmer.Domain.Collection;
using Farmer.Domain.Plants;

namespace Farmer.Domain
{
    public class Farm<T> where T : Plant
    {
        private readonly IMutableList<T> _plants = ListFactory.MutableListOf<T>(100);
        private readonly Dictionary<Guid, Granger> _farmers = new Dictionary<Guid, Granger>();

        public IImmutableList<T> Plants => _plants;
        public IDictionary<Guid, Granger> Farmers => _farmers;

        public void AddPlants(IImmutableList<T> plants)
        {
            _plants.AddAll(plants);
        }

        public bool AddFarmers(IEnumerable<Granger> grangers)
        {
            foreach (var granger in grangers)
            {
                _farmers[granger.Id] = granger;
                if (_farmers.Count > 10) return false;
            }
            
            return true;
        }
        
        public bool CollectHarvest()
        {
            if (_plants.Size == 0 || _farmers.Count == 0) return false;

            var rnd = new Random();
            var randomFarmerId = _farmers.Keys.OrderBy(guid => rnd.Next()).First();
            _plants.Foreach(plant => _farmers[randomFarmerId].ApplyHarvest(plant));
            
            return true;
        }
    }
}