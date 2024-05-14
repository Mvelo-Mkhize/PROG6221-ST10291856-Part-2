using PROG6221_ST10291856_Part_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_ST10291856_Part_2
{
    class CalorieCalculator
    {
        public string Name { get; set; }
        public List<Ingredients> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public CalorieCalculator(string name, List<Ingredients> ingredients, List<string> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredients ingredient in Ingredients)
            {
                totalCalories += ingredient.calories;
            }
            return totalCalories;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Recipe: {Name}");
            sb.AppendLine("Ingredients:");
            foreach (Ingredients ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }
            sb.AppendLine("Steps:");
            foreach (string step in Steps)
            {
                sb.AppendLine(step);
            }
            sb.AppendLine($"Total Calories: {CalculateTotalCalories()}");
            return sb.ToString();
        }
    }
}