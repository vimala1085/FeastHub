namespace FeastHub
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Other properties
        public List<Menu> Menus { get; set; }
        public List<OperatingHours> OperatingHours { get; set; }
    }
    
}