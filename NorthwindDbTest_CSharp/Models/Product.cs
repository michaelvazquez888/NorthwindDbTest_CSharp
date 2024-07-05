using Newtonsoft.Json;
using System;

namespace NorthwindDbTest_CSharp.Models
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string Name { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
    }
}