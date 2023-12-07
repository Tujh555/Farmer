using System;

namespace Farmer.Domain.Plants
{
    [Serializable]
    public sealed class Vegetable : Plant
    {
        public double Calories { get; set; }

        public Vegetable(
            double calories,
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
            Calories = calories;
        }
    }
}