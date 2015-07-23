using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Drink: Recipe,IDrink
    {

        private bool isCarbonated;

        public Drink(string initialName, decimal initialPrice, int initialCalories,
            int initialQuantityPerServing, int initialTimeToPrepare, bool initialIsCarbonated)
            :base( initialName,  initialPrice,  initialCalories,
             initialQuantityPerServing,  MetricUnit.Milliliters, initialTimeToPrepare)
        {
            this.isCarbonated = initialIsCarbonated;
        }

        public bool IsCarbonated
        {
            get { return this.isCarbonated; }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.AppendLine(string.Format("Carbonated: {0}", (isCarbonated) ? "yes" : "no"));

            return result.ToString();
        }
    }
}
