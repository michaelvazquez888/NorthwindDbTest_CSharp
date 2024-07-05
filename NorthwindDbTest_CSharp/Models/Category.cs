using Newtonsoft.Json;
using System;

namespace NorthwindDbTest_CSharp.Models
{
    [Serializable]
    public class Category
    {
        public int Id { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string Name { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string Description { get; set; }
    }
}