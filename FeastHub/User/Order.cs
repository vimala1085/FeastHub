using System.ComponentModel.DataAnnotations;

namespace FeastHub
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public List<int> CartItem { get; set; }
        // Other order details (e.g., user info, payment)
    }
    

}