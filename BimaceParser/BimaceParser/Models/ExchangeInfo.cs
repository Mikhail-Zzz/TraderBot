using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BimaceParser.Models
{
    public class ExchangeInfo
    {
        [JsonProperty("symbols")]
        public Symbol[] Symbols { get; set; } 
    }
}
