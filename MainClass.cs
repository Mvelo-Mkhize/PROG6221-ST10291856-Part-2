using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_ST10291856_Part_2
{
    class MainClass
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to my Recipe Application!");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. Enter And Save Recipe");
                Console.WriteLine("2. Display Saved Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear All Recipe Data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Select Your Choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipeManager.EnterAndSaveRecipe();
                        break;
                    case 2:
                        recipeManager.DisplaySavedRecipes();
                        break;
                    case 3:
                        recipeManager.ScaleRecipe();
                        break;
                    case 4:
                        recipeManager.ResetQuantities();
                        break;

                    case 5:
                        recipeManager.ClearAllRecipeData();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("------------------------------------");
            }
        }
    }
}
