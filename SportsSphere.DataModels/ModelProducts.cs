using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsSphere.DataModels
{
    // Represents a product available in the system.
    public class Product
    {
        // Unique identifier for each product.
        public int ProductID { get; set; }

        // Identifier for the category to which the product belongs.
        public int CategoryID { get; set; }

        // The name of the product.
        public string? ProductName { get; set; }

        // The price of the product.
        public decimal Price { get; set; }

        // The available quantity of the product in stock.
        public int StockQuantity { get; set; }

        // Reference to an image associated with the product.
        public string? ProductImageReference { get; set; }

        // A brief description of the product.
        public string? Description { get; set; }

        // The brand or manufacturer of the product.
        public string? Brand { get; set; }
    }
}
