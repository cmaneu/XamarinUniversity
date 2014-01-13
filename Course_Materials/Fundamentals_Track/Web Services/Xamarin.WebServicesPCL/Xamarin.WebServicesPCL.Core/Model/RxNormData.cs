using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Xamarin.WebServicesPCL.Core.Model
{
	public class RxNormData
    {
        [JsonProperty("drugGroup")]
        public DrugGroup DrugGroup { get; set; }
    }

}
