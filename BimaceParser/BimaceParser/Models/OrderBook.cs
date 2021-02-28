using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BimaceParser.Models
{
    public class OrderBook
    {
        [JsonProperty("bids")]
        public double[][] Bids { get; set; }
        [JsonProperty("asks")]
        public double[][] Asks { get; set; }
    }
}
