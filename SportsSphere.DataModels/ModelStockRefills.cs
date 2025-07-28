using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsSphere.DataModels
{
    // Represents a stock refill operation for a product.
    public class StockRefill
    {
        // Unique identifier for each stock refill operation.
        public int RefillID { get; set; }

        // Identifier for the product to which the stock refill operation applies.
        public int ProductID { get; set; }

        // The quantity added to the product's stock during the refill operation.
        public int QuantityAdded { get; set; }
    }
}
