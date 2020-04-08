using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        // Flour type calories
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        // Baking technique calories
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private double weight;
        private string flourType;
        private string bakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.Weight = weight;
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Calories = TotalCalories();
        }

        private double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                else
                {
                    weight = value;
                }
            }
        }

        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value != nameof(White) && value != nameof(Wholegrain))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                else
                {
                    flourType = value;
                }
            }
        }

        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value != nameof(Crispy) && value != nameof(Chewy) && value != nameof(Homemade))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                else
                {
                    bakingTechnique = value;
                }
            }
        }

        public double Calories { get; private set; }

        private double TotalCalories()
        {
            var techniqueCalories = 0.0;
            var flourTypeCalories = 0.0;

            switch (this.BakingTechnique)
            {
                case "Crispy":
                    techniqueCalories = Crispy;
                    break;
                case "Chewy":
                    techniqueCalories = Chewy;
                    break;
                case "Homemade":
                    techniqueCalories = Homemade;
                    break;
            }

            switch (this.FlourType)
            {
                case "White":
                    flourTypeCalories = White;
                    break;
                case "Wholegrain":
                    flourTypeCalories = Wholegrain;
                    break;
            }

            return (this.Weight * 2) * flourTypeCalories * techniqueCalories;
        }
    }
}
