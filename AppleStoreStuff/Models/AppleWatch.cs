using System.ComponentModel.DataAnnotations;

namespace AppleStoreStuff.Models
{
    public class AppleWatch
    {
        [Key]
        public int Id { get; set; }
        public string AppleWatchModel { get; set; }
        public int ScreenSize { get; set; }
        public string Cellular { get; set; }
        public string Gps { get; set; }
        public string Color { get; set; }
        public string HousingMaterial { get; set; }
        public string StrapType { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int AmountOfProduct { get; set; }
    }
}
