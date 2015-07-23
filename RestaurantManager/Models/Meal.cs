using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Meal : Recipe, IMeal
    {

        private bool isVegan = false;

        public Meal(string initialName, decimal initialPrice, int initialCalories,
            int initialQuantityPerServing, MetricUnit initialmetricUnit, int initialTimeToPrepare,bool initialIsVegan)
            : base( initialName,  initialPrice,  initialCalories,
             initialQuantityPerServing, initialmetricUnit,  initialTimeToPrepare)
        {
            this.isVegan = initialIsVegan;
        }

        public bool IsVegan 
        {
            get
            {
                return this.isVegan;
            }
        }
        public void ToggleVegan()
        {
            this.isVegan = !this.isVegan;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (IsVegan) result.Append("[VEGAN] ");
            result.Append(base.ToString());

            return result.ToString();
        }



    }
}
