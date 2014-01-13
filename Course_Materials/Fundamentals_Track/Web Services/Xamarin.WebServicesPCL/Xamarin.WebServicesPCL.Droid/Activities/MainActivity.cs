using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Linq;
using Xamarin.WebServicesPCL.Core.Model;
using Android.Views.InputMethods;

namespace Xamarin.WebServicesPCL.Droid
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : ListActivity
	{
		EditText searchText;
		ProgressBar drugSearchProgressBar;
		Adapters.ConceptPropertyAdapter conceptPropertyAdapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			drugSearchProgressBar = FindViewById<ProgressBar> (Resource.Id.drugSearchProgressBar);

			searchText = FindViewById<EditText> (Resource.Id.drugSearchText);
			var clear = FindViewById<ImageButton> (Resource.Id.clearButton);
			var drugSearchButton = FindViewById<ImageButton> (Resource.Id.drugSearchButton);

			conceptPropertyAdapter = new Adapters.ConceptPropertyAdapter (this, Enumerable.Empty<ConceptProperty> ());
			ListView.Adapter = conceptPropertyAdapter;

			clear.Click += (sender, e) => {
				conceptPropertyAdapter.ConceptProperties.Clear();
				conceptPropertyAdapter.NotifyDataSetChanged();

				searchText.Text = String.Empty;
			};

			drugSearchButton.Click += async (sender, e) => {

				var imm = (InputMethodManager) GetSystemService(InputMethodService);
				if(imm.IsAcceptingText)// verify if the soft keyboard is open                         
					imm.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

				drugSearchProgressBar.Visibility = ViewStates.Visible;

				var restClient = new Core.RestClient();

				conceptPropertyAdapter.ConceptProperties.Clear();
				conceptPropertyAdapter.NotifyDataSetChanged();

				var searchResults = await restClient.GetDataAsyncAndAutoParse(searchText.Text);
				if(searchResults != null && searchResults.DrugGroup != null && searchResults.DrugGroup.ConceptGroup != null)
					conceptPropertyAdapter.ConceptProperties.AddRange(searchResults.DrugGroup.ConceptGroup.SelectMany(cg => cg.ConceptProperties ?? Enumerable.Empty<ConceptProperty>()));

				conceptPropertyAdapter.NotifyDataSetChanged();

				drugSearchProgressBar.Visibility = ViewStates.Gone;

				if(!conceptPropertyAdapter.ConceptProperties.Any())
					Toast.MakeText(this, "No matches found", ToastLength.Short);
			};
		}
	}
}


