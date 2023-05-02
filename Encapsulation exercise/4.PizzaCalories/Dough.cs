using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Dough
    {

        public Dough(string flourType,string bakingTechnique,double doughtWeight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.DoughWeight = doughWeight;
        }

        private string flourType;
        private string bakingTechnique;
        private double doughWeight;
        private double calories;

        public string FlourType
        {
            get 
            { 
                return this.flourType; 
            }
            private set
            {
                if (value != "White" && value != "Wholegrain")
                {
                    throw new ArgumentException(Error_messages.doughIncorrectType);
                }
                this.flourType = value;
            }
        }


        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if(value!="Crispy" && value!="Chewy" && value != "Homemade")
                {
                    throw new ArgumentException(Error_messages.doughIncorrectType);
                }
                this.bakingTechnique = value;
            }
        }

        public double DoughWeight
        {
            get
            {
                return this.doughWeight;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Error_messages.doughRange);
                }
                this.doughWeight = value;
            }
        }

        public double Calories
        {
            get { return this.calories; }
        }

        public double FlourTypeMultiplyer()
        {
            if (FlourType == "White")
            {
                return 1.5;
            }
            return 1.1;
        }

        public double BakingTechniqueMultiplyer()
        {
            if (BakingTechnique == "Crispy")
            {
                return 0.9;
            }
            else if (BakingTechnique == "Chewy")
            {
                return 1.1;
            }
            return 1.0;
        }

        public double CalculateCalories()
        {
            return 2 * DoughWeight * FlourTypeMultiplyer() * BakingTechniqueMultiplyer();
        }


        public override string ToString()
        {
            return $"{this.Calories}";
        }
    }
}
