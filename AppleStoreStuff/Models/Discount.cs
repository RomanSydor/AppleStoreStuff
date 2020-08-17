using System;
using System.ComponentModel.DataAnnotations;

namespace AppleStoreStuff.Models
{
    public class Discount
    {
        [Key]
        public string Id { get; set; }
        public float Amount { get; set; }
        public string Value { get; set; }
        public DateTime? AvailableTill { get; set; }
        public bool IsUsed { get; set; }
    }
}
