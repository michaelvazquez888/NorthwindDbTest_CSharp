using Newtonsoft.Json;

namespace NorthwindDbTest_CSharp.Models
{
    public class Customer
    {
        [JsonConverter(typeof(NullableStringConverter))]
        public string Id { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string CompanyName { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string ContactName { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string ContactTitle { get; set; }
        public Address Address { get; set; }
    }
}