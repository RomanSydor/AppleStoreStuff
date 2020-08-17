using System.ComponentModel.DataAnnotations;

namespace AppleStoreStuff.Models
{
    public class IPhone
    {
        [Key]
        public int Id { get; set; }
        public string IPhoneModel { get; set; }
        public string Memory { get; set; }
        public int Weight { get; set; }
        public string ScreenType { get; set; }
        public float ScreenSize { get; set; }
        public string UhdRecording { get; set; }
        public int BatteryCapacity { get; set; }
        public string Processor { get; set; }
        public int Ram { get; set; }
        public string MainCamera { get; set; }
        public int FrontCamera { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int AmountOfProduct { get; set; }
    }
}
