using System;

namespace Farmer.Domain.Plants
{
    [Serializable]
    public sealed class Berry : Plant
    {
        public bool IsMedicinal { get; set; }
        public bool IsSour { get; set; }
        public bool IsSweet { get; set; }
        
        public Berry(
            bool isMedicinal,
            bool sour,
            bool sweet,
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
            IsMedicinal = isMedicinal;
            IsSour = sour;
            IsSweet = sweet;
        }
    }
}