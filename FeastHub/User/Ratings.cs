namespace FeastHub
{
    public class Ratings
    {
        public int RatingsId { get; set; }
        public int VendorId { get; set; }
        public int MenuId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
        public string Review { get; set; }

        // Other properties
    }
}