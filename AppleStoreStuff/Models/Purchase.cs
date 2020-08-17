using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppleStoreStuff.Models
{

    [JsonObject]

    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field can't be empty.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field can't be empty.")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field can't be empty.")]
        [Display(Name = "Phone")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Field can't be empty.")]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        //[IsRepeat]  TODO create repeat check validation!!!
        [Display(Name = "Promo code")]
        public string PromoCode { get; set; } = null;
        public float PromoAmount { get; set; }
        public string PromoValue { get; set; }

        public DateTime Date { get; set; }

        public float TotalPrice { get; set; }

        [JsonProperty]
        public string BoughtProds { get; set; }
    }
}
