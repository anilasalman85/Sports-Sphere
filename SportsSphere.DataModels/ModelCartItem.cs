// CartItemModel.cs
namespace SportsSphere.DataModels
{
    // Represents an item in a user's shopping cart.
    public class CartItemModel
    {
        // Unique identifier for each cart item.
        public int CartItemId { get; set; }

        // Identifier for the product associated with the cart item.
        public int ProductId { get; set; }

        // Quantity of the product in the cart item.
        public int Quantity { get; set; }
    }
}