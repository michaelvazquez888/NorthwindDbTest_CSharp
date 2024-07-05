using Newtonsoft.Json;
using NorthwindDbTest_CSharp.Extensions;
using System;
using System.Collections.Generic;

namespace NorthwindDbTest_CSharp.Models
{
    [Serializable]
    public class Order
    {
        public int Id { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public decimal Freight { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string ShipName { get; set; }
        public Address ShipAddress { get; set; }
        public List<OrderDetails> Details { get; set; }
    }

    [Serializable]
    public class OrderDetails
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}