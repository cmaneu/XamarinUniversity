using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Xamarin.WebServicesPCL.Core
{
	public class RestClient
	{
		private const string 
		RestServiceBaseAddress = "http://rxnav.nlm.nih.gov/REST/",
			AcceptHeaderApplicationJson = "application/json";
		
		private HttpClient CreateRestClient(){
			var client = new HttpClient(){ BaseAddress = new Uri(RestServiceBaseAddress) };

			client.DefaultRequestHeaders.Accept.Add (MediaTypeWithQualityHeaderValue.Parse(AcceptHeaderApplicationJson));

			return client;
		} 

		public async Task<Model.RxNormData> GetDataAsyncAndAutoParse(String name){
			if (String.IsNullOrEmpty (name))
				throw new ArgumentNullException ("name");

			using (var client = CreateRestClient ()) {
				var getDataResponse = await client.GetAsync (String.Format ("drugs?name={0}", name), HttpCompletionOption.ResponseContentRead);

				return getDataResponse.IsSuccessStatusCode 
					? await Newtonsoft.Json.JsonConvert.DeserializeObjectAsync<Model.RxNormData> (await getDataResponse.Content.ReadAsStringAsync ()) 
					: default(Model.RxNormData);
			}
		}
	}
}

