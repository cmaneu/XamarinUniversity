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
//		private const string 
//			RestServiceBaseAddress = "http://rxnav.nlm.nih.gov/REST/",
//			AcceptHeaderApplicationJson = "application/json";
//
//		private HttpClient CreateRestClient(){
//			var client = new HttpClient(){ BaseAddress = new Uri(RestServiceBaseAddress) };
//
//			client.DefaultRequestHeaders.Accept.Add (MediaTypeWithQualityHeaderValue.Parse(AcceptHeaderApplicationJson));
//
//			return client;
//		} 

		//TODO: 6 - Call the web service and retrieve data
//		public async Task<IEnumerable<Model.ConceptProperty>> GetDataAsync(){
//			using (var client = CreateRestClient ()) {
//				var getDataResponse = await client.GetAsync ("drugs?name=aspirin", HttpCompletionOption.ResponseContentRead);
//
//				if (!getDataResponse.IsSuccessStatusCode)
//					return Enumerable.Empty<Model.ConceptProperty> ();
//
//				var jsonResponse = JsonValue.Load(await getDataResponse.Content.ReadAsStreamAsync ());
//
//				return JsonToConceptProperty (jsonResponse);
//			}
//		}

		//TODO: 7 - Convert JSON into model objects
//		private IEnumerable<Model.ConceptProperty> JsonToConceptProperty(JsonValue json)
//		{
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
//		}
	}
}

