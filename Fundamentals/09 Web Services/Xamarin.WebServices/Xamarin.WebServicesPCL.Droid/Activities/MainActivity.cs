using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Xamarin.WebServicesPCL.Droid
{
	[Activity (Label = "Xamarin.WebServices.Droid", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += async delegate {
				var client = new Core.RestClient();

				button.Text = (await client.GetDataAsyncAndAutoParse("aspirin")).DrugGroup.Name;
			};
		}
	}
}


