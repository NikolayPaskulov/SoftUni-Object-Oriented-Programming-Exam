using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Dessert: Meal, IDessert
    {

        private bool haveSugar = true;

        public Dessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base( name,  price,  calories,  quantityPerServing,MetricUnit.Grams,  timeToPrepare,  isVegan)
        {

        }

        public bool WithSugar 
        { 
            get
            {
                return this.haveSugar;
            }
        }

        public void ToggleSugar()
        {
            this.haveSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (!WithSugar) result.Append("[NO SUGAR] ");
            result.Append(base.ToString());

            return result.ToString();
        }
    }
}
