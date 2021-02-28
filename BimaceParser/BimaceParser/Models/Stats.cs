using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BimaceParser.Models
{
    public class Stats
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("lastPrice")]
        public string LastPrice { get; set; }

        [JsonProperty("priceChange")]
        public string PriceChange { get; set; }

        [JsonProperty("highPrice")]
        public string HighPrice { get; set; }

        [JsonProperty("lowPrice")]
        public string LowPrice { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("quoteVolume")]
        public string QuoteVolume { get; set; }

    }
}
