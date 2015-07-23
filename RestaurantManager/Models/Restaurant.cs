using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Restaurant : IRestaurant
    {

        private string name;
        private string location;
        private readonly ICollection<IRecipe> recipes;

        public Restaurant(string initialName, string inititalLocation)
        {
            this.Name = initialName;
            this.Location = inititalLocation;
            this.recipes = new List<IRecipe>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Restaurant name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Restaurant location cannot be null or empty");
                }
                this.location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get
            {
                return new List<IRecipe>(this.recipes);
            }
        }

        public void AddRecipe(IRecipe recipe)
        {
            if(recipe == null)
            {
                throw new ArgumentNullException("Recipe cannot be null");
            }
            this.recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException("Recipe cannot be null");
            }
            this.recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("***** {0} - {1} *****", this.Name, this.Location));

            string[] allTypes = {"Drink", "Salad", "MainCourse", "Dessert"};

            if (recipes.Count != 0)
            {
                for (int i = 0; i < allTypes.Length; i++)
                {
                    var sortedRepices = new List<IRecipe>();

                    foreach (var recipe in recipes)
                    {
                        if (recipe.GetType().Name == allTypes[i])
                        {
                            sortedRepices.Add(recipe);
                        }
                    }

                    if(sortedRepices.Count() != 0)
                    {
                        if (allTypes[i] == allTypes[2])
                        {
                            result.AppendLine(string.Format("~~~~~ {0} ~~~~~", "MAIN COURSES"));
                        }
                        else
                        {
                            result.AppendLine(string.Format("~~~~~ {0} ~~~~~", allTypes[i].ToUpper() + 'S'));
                        }

                        foreach (var recipe in sortedRepices)
                        {
                            result.AppendLine(recipe.ToString().Trim());
                        }
                    }
                }
            }
            else
            {
                result.AppendLine("No recipes... yet");
            }

            return result.ToString().Trim();
        }
    }
}
