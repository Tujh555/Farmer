using System;
using Farmer.Domain.Collection;
using Farmer.Domain.Plants;

namespace Farmer.Domain
{
    /// <summary>
    /// Класс, представляющий собой фермера
    /// </summary>
    public class Granger : IUniqueIdOwner
    {
        private readonly IMutableList<Plant> _harvest = ListFactory.MutableListOf<Plant>(100); 

        public Guid Id { get; } = Guid.NewGuid();
        
        public string Name { get; }

        public int HarvestCount => _harvest.Size;

        public Granger(string name)
        {
            Name = name;
        }

        public void ApplyHarvest(Plant plant)
        {
            _harvest.Add(plant);
        }
    }
}