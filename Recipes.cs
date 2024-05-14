using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace PROG6221_ST10291856_Part_2
{
    class Recipes
    {
        public string name;
        public List<Ingredients> ingredients;
        public List<string> steps;

        public Recipes(string name, List<Ingredients> ingredients, List<string> steps)
        {
            this.name = name;
            this.ingredients = ingredients;
            this.steps = steps;
        }

        public void ScaleQuantities(double scaleFactor)
        {
            foreach (Ingredients ingredient in ingredients)
            {
                ingredient.ScaleQuantity(scaleFactor);
            }
        }

        public void ResetQuantities()
        {
            foreach (Ingredients ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }
        public override string ToString()
        {
            string recipeString = "Name: " + name + "\n";
            recipeString += "Ingredients:\n";

            foreach (Ingredients ingredient in ingredients)
            {
                recipeString += "- " + ingredient.ToString() + "\n";
            }

            recipeString += "Steps:\n";

            for (int i = 0; i < steps.Count; i++)
            {
                recipeString += (i + 1) + ". " + steps[i] + "\n";
            }

            return recipeString;
        }
    }
}
