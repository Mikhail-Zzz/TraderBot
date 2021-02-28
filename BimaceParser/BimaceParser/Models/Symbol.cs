using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BimaceParser.Models
{
    public class Symbol
    {
        [JsonProperty("symbol")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
