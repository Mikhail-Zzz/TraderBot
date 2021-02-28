using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BimaceParser.Models
{
    public class RecentTradesInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("qty")]
        public double Quantity { get; set; }
        [JsonProperty("time")]
        public double Time { get; set; }

    }
}
