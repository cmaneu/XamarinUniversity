using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace ListViewsInAndroid
{
	/// <summary>
	/// This is a pre-built single-Speaker display screen, to demonstrate 
	/// starting a new activity with an Intent. It's not really part of the
	/// ListView training per se.
	/// </summary>
	[Activity (Label = "Session")]
	public class SessionActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.session_screen);

			var title = Intent.Extras.GetString ("Title");

			FindViewById<TextView> (Resource.Id.sessionTitleTextView).Text = title;
			// Exercise: populate the other fields :)
			// you could pass them all via PutString and GetString, 
			// or look up the Speaker data again from this method
		}
	}
}