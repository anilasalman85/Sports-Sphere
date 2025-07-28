using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsSphere.DataModels
{
    // Represents a category to which products belong.
    public class ProductCategory
    {
        // Unique identifier for each product category.
        public int CategoryID { get; set; }

        // The name of the product category.
        public string? CategoryName { get; set; }

        // Reference to an image associated with the product category.
        public string? CategoryImageReference { get; set; }
    }
}
