using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.Linq;

namespace Xamarin.WebServicesAsync.Droid.Activities
 {
	
	[Activity(Label = "XML")]
	public class XmlActivity : ListActivity
    {
		Adapters.ConceptPropertyAdapter adapter;

		protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			SetContentView (Resource.Layout.list_with_spinner);
        }

		protected override void OnResume ()
		{
			base.OnResume ();

			adapter = new Adapters.ConceptPropertyAdapter(this, Enumerable.Empty<Model.ConceptProperty>());
			ListView.Adapter = adapter;

			PrepareActivityAsync ();
		}

		public async Task PrepareActivityAsync(){
			adapter.ConceptProperties.Clear ();
			adapter.NotifyDataSetInvalidated ();

			var soapClient = new Client.SoapClient ();

			adapter.ConceptProperties.AddRange (await soapClient.GetDataAsync ());
			adapter.NotifyDataSetChanged ();
		}
    }
}
