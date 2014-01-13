using System.Linq;
using System.Threading.Tasks;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Xamarin.WebServicesAsync.Droid.Activities
 {
	[Activity(Label = "@string/activity_json_label")]
	public class JsonActivity : ListActivity {
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

			PrepareActivityAsync();
		}

		private async Task PrepareActivityAsync(){
			adapter.ConceptProperties.Clear ();
			adapter.NotifyDataSetInvalidated ();

			var restClient = new Client.RestClient ();

			adapter.ConceptProperties.AddRange (await restClient.GetDataAsync ());
			adapter.NotifyDataSetChanged ();
		}
	}
}
