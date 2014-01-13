using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Json;

namespace Xamarin.WebServicesAsync.Droid.Client
{
	public class RestClient
	{


		//TODO: 5 - Create a REST client
//		private HttpClient CreateRestClient(){
//		} 

		//TODO: 6 - Call the web service and retrieve data
//		public async Task<IEnumerable<Model.ConceptProperty>> GetDataAsync(){
//		}

		//TODO: 7 - Convert JSON into model objects
		private IEnumerable<Model.ConceptProperty> JsonToConceptProperty(JsonValue json)
		{
//			var conceptProperties = new List<Model.ConceptProperty>();
//
//			if(json != null && json.ContainsKey("drugGroup")){
//				var drugGroup = json ["drugGroup"];
//
//				if (drugGroup != null && drugGroup.ContainsKey("conceptGroup")){
//					foreach (JsonValue conceptGroup in drugGroup["conceptGroup"]) {
//						if(conceptGroup.ContainsKey("conceptProperties")){
//							foreach (JsonValue conceptProperty in conceptGroup["conceptProperties"]) {
//								conceptProperties.Add(
//									new Model.ConceptProperty(){
//									});
//							}
//						}
//					}
//				}
//			}
//
//			return conceptProperties.OrderBy(cp => cp.Synonym);
		}
	}
}

