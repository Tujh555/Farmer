using System;

namespace Farmer.Domain.Plants
{
    [Serializable]
    public abstract class Plant : IUniqueIdOwner
    {
        public Guid Id { get; } = Guid.NewGuid();
        
        public string PlantName { get; set;}
        
        public string Color { get; set;}
        
        public bool IsRipped { get; set;}
        
        public DateTime PlantingDate { get; set;}
        
        protected Plant(string plantName, string color, DateTime plantingDate, bool isRipped)
        {
            PlantName = plantName;
            Color = color;
            IsRipped = isRipped;
            PlantingDate = plantingDate;
        }
    }
}