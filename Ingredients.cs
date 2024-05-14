using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace PROG6221_ST10291856_Part_2
{
    class Ingredients
    {
        public string name;
        public double quantity;
        public string unit;
        public int calories;
        public string foodGroup { get; set; }

        public Ingredients(string name, double quantity, string unit, string foodGroup, int calories)
        {
            this.name = name;
            this.quantity = quantity;
            this.unit = unit;
            this.calories = calories;
            this.foodGroup = foodGroup;
        }


        public void ScaleQuantity(double scaleFactor)
        {
            quantity *= scaleFactor;
        }

        public void ResetQuantity()
        {
            // Implement your logic to reset the quantity back to the original value
        }

        public override string ToString()
        {
            return name + ": " + quantity + " " + unit;
        }
    }
}
