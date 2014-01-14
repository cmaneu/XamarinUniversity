using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace ListViewsInAndroid
{
	/// <summary>
	/// Demo 5: Add an index and fast-scrolling
	/// </summary>
    [Activity (Label = "ListView.Demo5", MainLauncher = true, Icon="@drawable/ic_launcher")]			
	public class Speakers5Activity : ListActivity
	{
		SpeakersAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
        	base.OnCreate(bundle);

            adapter = new SpeakersAdapter(this, Speakers.GetSpeakerData());
        	ListView.Adapter = adapter;

            // Enable fast scrolling
        	ListView.FastScrollEnabled = true;
        }

		/// <summary>
		/// Demonstrates how to handle a row click
		/// </summary>
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			var speakerName = adapter[position].Name;
			Toast.MakeText(this, "You selected the speaker " + speakerName + ".", ToastLength.Short).Show();
		}
	}
}

