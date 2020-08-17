using System.ComponentModel.DataAnnotations;

namespace AppleStoreStuff.Models
{
    public class AirPods
    {

        [Key]
        public int Id { get; set; }
        public string AirPodsModel { get; set; }
        public string WirelessCharging { get; set; }
        public int YearOfProduction { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int AmountOfProduct { get; set; }
    }
}
