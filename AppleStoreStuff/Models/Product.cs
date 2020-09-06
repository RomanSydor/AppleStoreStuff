using Newtonsoft.Json;

namespace AppleStoreStuff.Models
{
    [JsonObject]
    public class Product
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string TableName { get; set; }
        [JsonProperty]
        public int ProductId { get; set; }
        [JsonProperty]
        public string ProductName { get; set; }
        [JsonProperty]
        public string Color { get; set; }
        [JsonProperty]
        public float? ScreenSize { get; set; }
        [JsonProperty]
        public string Memory { get; set; }
        [JsonProperty]
        public int Amount { get; set; }
        [JsonProperty]
        public float Price { get; set; }
        [JsonProperty]
        public float TotalPrice { get; set; }
    }
}
