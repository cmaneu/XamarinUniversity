using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Xamarin.WebServicesPCL.Core.Model
{

	public class DrugGroup
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("conceptGroup")]
        public ConceptGroup[] ConceptGroup { get; set; }
    }

}
