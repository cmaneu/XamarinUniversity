using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.Linq;

namespace Xamarin.WebServicesAsync.Droid.Activities
 {
	
	[Activity(Label = "@string/activity_soap_label")]
	public class SoapActivity : ListActivity
    {
		//TODO: 3 - Create an activity to consume the data
		Adapters.ConceptPropertyAdapter adapter;

		protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			SetContentView (Resource.Layout.list_with_spinner);

			adapter = new Adapters.ConceptPropertyAdapter(this, Enumerable.Empty<Model.ConceptProperty>());
			ListView.Adapter = adapter;
        }

		protected override void OnResume ()
		{
			base.OnResume ();

			PrepareActivityAsync ();
		}

		//TODO: 4 - Call the services using async and update the UI with the results
		public async Task PrepareActivityAsync(){
			adapter.ConceptProperties.Clear ();
			adapter.NotifyDataSetInvalidated ();

			var soapClient = new Client.SoapClient ();

			adapter.ConceptProperties.AddRange (await soapClient.GetDataAsync ());
			adapter.NotifyDataSetChanged ();
		}
    }
}
