using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_ST10291856_Part_2
{
    delegate void RecipeExceedsCaloriesDelegate(Recipes recipe);


    class RecipeManager
    {
        public RecipeExceedsCaloriesDelegate recipeExceedsCaloriesHandler;

        private List<Recipes> recipes;

        public List<Recipes> savedRecipes { get; }

        public RecipeManager()
        {
            recipes = new List<Recipes>();
            savedRecipes = new List<Recipes>();
        }



        public void EnterAndSaveRecipe()
        {
            Console.WriteLine("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            Console.WriteLine("Input the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            List<Ingredients> ingredients = new List<Ingredients>();

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine("Enter the name of ingredient {0}: ", i + 1);
                string ingredientName = Console.ReadLine();

                Console.WriteLine("Input the quantity of ingredient: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine("Input the unit of measurement: ");
                string unit = Console.ReadLine();

                Console.WriteLine("Select the food group of ingredient {0}: ", i + 1);
                Console.WriteLine("1. Starchy foods");
                Console.WriteLine("2. Vegetables and fruits");
                Console.WriteLine("3. Dry beans, peas, lentils and soya");
                Console.WriteLine("4. Chicken, fish, meat and eggs");
                Console.WriteLine("5. Milk and dairy products");
                Console.WriteLine("6. Fats and oil");
                Console.WriteLine("7. Liquids");

                int foodGroupSelection = int.Parse(Console.ReadLine());

                string foodGroup;

                switch (foodGroupSelection)
                {
                    case 1:
                        foodGroup = "Starchy foods";
                        break;
                    case 2:
                        foodGroup = "Vegetables and fruits";
                        break;
                    case 3:
                        foodGroup = "Dry beans, peas, lentils and soya";
                        break;
                    case 4:
                        foodGroup = "Chicken, fish, meat and eggs";
                        break;
                    case 5:
                        foodGroup = "Milk and dairy products";
                        break;
                    case 6:
                        foodGroup = "Fats and oil";
                        break;
                    case 7:
                        foodGroup = "Liquids";
                        break;
                    default:
                        Console.WriteLine("Invalid food group selection. Setting food group to 'Unknown'.");
                        foodGroup = "Unknown";
                        break;
                }

                Console.WriteLine("Input the number of calories: ");
                int calories = int.Parse(Console.ReadLine());

                Ingredients ingredient = new Ingredients(ingredientName, quantity, unit, foodGroup, calories);
                ingredients.Add(ingredient);
            }

            Console.WriteLine("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            List<string> steps = new List<string>();

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine("Enter step {0}: ", i + 1);
                string step = Console.ReadLine();
                steps.Add(step);
            }

            Recipes recipe = new Recipes(name, ingredients, steps);
            recipes.Add(recipe);

            CalorieCalculator calorieCalculator = new CalorieCalculator(name, ingredients, steps);
            int totalCalories = calorieCalculator.CalculateTotalCalories();

            Console.WriteLine($"Total Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: Total calories exceed 300!");
            }

            RecipeManager recipeManager = new RecipeManager();
        }




        public void DisplaySavedRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipe found. Please enter and save recipe first.");
            }
            else
            {
                Console.WriteLine("Saved Recipes:");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, recipes[i].name);
                }

                Console.WriteLine("Enter the number of the recipe to display or enter '0' to display all recipes: ");
                int selectedRecipeIndex = int.Parse(Console.ReadLine());

                if (selectedRecipeIndex >= 0 && selectedRecipeIndex <= recipes.Count)
                {
                    if (selectedRecipeIndex == 0)
                    {
                        recipes.Sort((r1, r2) => r1.name.CompareTo(r2.name));
                        foreach (Recipes recipe in recipes)
                        {
                            Console.WriteLine(recipe.ToString());
                        }
                    }
                    else
                    {
                        Recipes selectedRecipe = recipes[selectedRecipeIndex - 1];
                        Console.WriteLine(selectedRecipe.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Invalid recipe number. Please try again.");
                }
                foreach (Recipes recipe in recipes)
                {
                    Console.WriteLine(recipe.ToString());
                }
            }
        }



        public void ScaleRecipe()
        {
            Console.WriteLine("Enter the number of the recipe to scale: ");
            int selectedRecipeIndex = int.Parse(Console.ReadLine());

            if (selectedRecipeIndex >= 1 && selectedRecipeIndex <= recipes.Count)
            {
                Recipes selectedRecipe = recipes[selectedRecipeIndex - 1];

                Console.WriteLine("Enter the scale factor (0.5, 2, or 3) for recipe '{0}': ", selectedRecipe.name);
                double scaleFactor = double.Parse(Console.ReadLine());

                selectedRecipe.ScaleQuantities(scaleFactor);

                Console.WriteLine("Recipe '{0}' scaled successfully.", selectedRecipe.name);
            }
            else
            {
                Console.WriteLine("Invalid recipe number. Please try again.");
            }
        }
        


        public void ResetQuantities()
        {
            Console.WriteLine("Enter the number of the recipe to reset quantities: ");
            int selectedRecipeIndex = int.Parse(Console.ReadLine());

            if (selectedRecipeIndex >= 1 && selectedRecipeIndex <= recipes.Count)
            {
                Recipes selectedRecipe = recipes[selectedRecipeIndex - 1];

                selectedRecipe.ResetQuantities();

                Console.WriteLine("Quantities reset successfully for recipe '{0}'.", selectedRecipe.name);
            }
            else
            {
                Console.WriteLine("Invalid recipe number. Please try again.");
            }
        }

        public void ClearAllRecipeData()
        {
            recipes.Clear();
            Console.WriteLine("All recipe data cleared successfully.");
        }

    }
}

