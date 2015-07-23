using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public abstract class Recipe : IRecipe
    {

        private const int Zero = 0;
        private const string NegativeExceptionFormat = "{0} cannot be qual to {1}";

        private string name;
        private decimal price;
        private int calories;
        private int quntityPerServing;
        private readonly MetricUnit metricUnit;
        private int timeToPrepare;


        public Recipe(string initialName, decimal initialPrice, int initialCalories,
            int initialQuantityPerServing, MetricUnit initialmetricUnit, int initialTimeToPrepare)
        {
            this.Name = initialName;
            this.Price = initialPrice;
            this.Calories = initialCalories;
            this.QuantityPerServing = initialQuantityPerServing;
            this.metricUnit = initialmetricUnit;
            this.TimeToPrepare = initialTimeToPrepare;
        }
        public string Name
        {
            get 
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Recipe name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get 
            {
                return this.price;
            }
            set
            {
                if (value < Zero)
                {
                    throw new ArgumentOutOfRangeException(string.Format(NegativeExceptionFormat,"Price",Zero));
                }
                this.price = decimal.Round(value, 2);
            }
        }

        public int Calories
        {
            get 
            {
                return this.calories;
            }
            set
            {
                if (value < Zero)
                {
                    throw new ArgumentOutOfRangeException(string.Format(NegativeExceptionFormat, "Calories", Zero));
                }
                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quntityPerServing;
            }
            set
            {
                if (value < Zero)
                {
                    throw new ArgumentOutOfRangeException(string.Format(NegativeExceptionFormat, "QuantityPerServing", Zero));
                }
                this.quntityPerServing = value;
            }
        }

        public MetricUnit Unit
        {
            get 
            {
                return this.metricUnit;
            }
        }

        public int TimeToPrepare
        {
            get 
            {
                return this.timeToPrepare;
            }
            set 
            {
                if (value < Zero)
                {
                    throw new ArgumentOutOfRangeException(string.Format(NegativeExceptionFormat, "TimeToPrepare", Zero));
                }
                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("==  {0} == ${1}", this.Name, this.Price));
            result.AppendLine(string.Format("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing,
                (this.Unit == MetricUnit.Milliliters)? "ml" : "g", this.Calories));
            result.AppendLine(string.Format("Ready in {0} minutes", this.TimeToPrepare));

            return result.ToString();
        }
    }
}
