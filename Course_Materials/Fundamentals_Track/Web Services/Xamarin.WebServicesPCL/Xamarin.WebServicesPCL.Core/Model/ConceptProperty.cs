using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Xamarin.WebServicesPCL.Core.Model
{

	public class ConceptProperty
    {

        [JsonProperty("rxcui")]
        public string Rxcui { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("synonym")]
        public string Synonym { get; set; }

        [JsonProperty("tty")]
        public string Tty { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("suppress")]
        public string Suppress { get; set; }

        [JsonProperty("umlscui")]
        public string Umlscui { get; set; }
    }

}
