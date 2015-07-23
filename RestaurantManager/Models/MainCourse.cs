using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class MainCourse : Meal, IMainCourse
    {

        private MainCourseType mainCourseType;

        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, MainCourseType type)
            :base ( name,  price,  calories,quantityPerServing,MetricUnit.Grams,timeToPrepare,  isVegan)
        {
            this.mainCourseType = type;
        }

        public MainCourseType Type
        {
            get 
            {
                return this.mainCourseType;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.AppendLine(string.Format("Type: {0}", mainCourseType));

            return result.ToString();
        }
    }
}
