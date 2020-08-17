using System.ComponentModel.DataAnnotations;

namespace AppleStoreStuff.Models
{
    public class Mac
    {
        [Key]
        public int Id { get; set; }
        public string MacModel { get; set; }
        public string Type { get; set; }
        public string Memory { get; set; }
        public float ScreenSize { get; set; }
        public string Processor { get; set; }
        public int KernelsAmount { get; set; }
        public int Ram { get; set; }
        public string SsdCapacity { get; set; }
        public string DriveCapacity { get; set; }
        public string VideoCard { get; set; }
        public int YearOfProduction { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int AmountOfProduct { get; set; }
    }
}
