﻿using Newtonsoft.Json;
using System;

namespace NorthwindDbTest_CSharp.Models
{
    [Serializable]
    public class Supplier
    {
        public int Id { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string CompanyName { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string ContactName { get; set; }
        [JsonConverter(typeof(NullableStringConverter))]
        public string ContactTitle { get; set; }
        public Address Address { get; set; }
    }
}