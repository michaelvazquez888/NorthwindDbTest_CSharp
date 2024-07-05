using Newtonsoft.Json;
using System;

namespace NorthwindDbTest_CSharp.Models
{
    [Serializable]
    public class Address
    {
        [JsonConverter(typeof(NullableStringConverter))]
        public string Street { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string City { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string Region { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string PostalCode { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string Country { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string Phone { get; set; }
    }
}