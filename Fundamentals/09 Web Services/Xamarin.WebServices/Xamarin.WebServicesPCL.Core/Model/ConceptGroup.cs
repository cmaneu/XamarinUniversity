using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Xamarin.WebServicesPCL.Core.Model
{

	public class ConceptGroup
    {

        [JsonProperty("tty")]
        public string Tty { get; set; }

        [JsonProperty("conceptProperties")]
        public ConceptProperty[] ConceptProperties { get; set; }
    }

}
