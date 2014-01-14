using Android.App;
using Android.OS;
using Android.Webkit;

namespace ListViewsInAndroid
{
	[Activity (Label = "About")]
	public class AboutActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			
			// set our layout to be the home screen
			this.SetContentView(Resource.Layout.about);
			
			var web = FindViewById<WebView>(Resource.Id.aboutwebview);
			web.LoadUrl("file:///android_asset/about.html");
		}
	}
}

