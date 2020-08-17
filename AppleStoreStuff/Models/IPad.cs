using System.ComponentModel.DataAnnotations;

namespace AppleStoreStuff.Models
{
    public class IPad
    {
        [Key]
        public int Id { get; set; }
        public string IPadModel { get; set; }
        public string TypeOfModel { get; set; }
        public string Memory { get; set; }
        public string Type { get; set; } // Wi-Fi, LTE
        public string ScreenType { get; set; }
        public float ScreenSize { get; set; }
        public string Processor { get; set; }
        public int Ram { get; set; }
        public string MainCamera { get; set; }
        public int FrontCamera { get; set; }
        public int YearOfProduction { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int AmountOfProduct { get; set; }
    }
}
