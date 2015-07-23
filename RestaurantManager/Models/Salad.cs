using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Salad : Meal, ISalad
    {

        private bool conteinsPasta;

        public Salad(string initialName, decimal initialPrice, int initialCalories,
            int initialQuantityPerServing, int initialTimeToPrepare, bool initialConteintsPasta)
            :base( initialName,  initialPrice,  initialCalories,
             initialQuantityPerServing,  MetricUnit.Grams, initialTimeToPrepare, true)
        {
            this.conteinsPasta = initialConteintsPasta;
        }

        public bool ContainsPasta
        {
            get
            {
                return this.conteinsPasta;
            }

        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.AppendLine(string.Format("Contains pasta: {0}",(conteinsPasta) ? "yes" : "no"));

            return result.ToString();
        }
    }
}
