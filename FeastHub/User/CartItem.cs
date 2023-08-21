namespace FeastHub
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int MenuId { get; set; }
        public int VendorId { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        public int UserId { get; set; }
        public CartItem CartItems { get; set; }
        // Other order details (e.g., user info, payment)
    }
}