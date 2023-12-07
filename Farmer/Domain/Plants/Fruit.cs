using System;

namespace Farmer.Domain.Plants
{
    [Serializable]
    public sealed class Fruit : Plant
    {
        public string Taste { get; set; }

        public bool IsEdiblePeel { get; set; }

        public Fruit(
            string taste,
            bool isEdiblePeel,
            string plantName,
            string color,
            DateTime plantingDate,
            bool isRipped
        ) : base(
            plantName,
            color,
            plantingDate,
            isRipped
        ) 
        {
            Taste = taste;
            IsEdiblePeel = isEdiblePeel;
        }
    }
}