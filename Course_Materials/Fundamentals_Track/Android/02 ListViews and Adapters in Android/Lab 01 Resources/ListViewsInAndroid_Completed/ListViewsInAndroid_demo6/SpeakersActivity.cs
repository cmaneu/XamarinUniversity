using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace ListViewsInAndroid
{
	/// <summary>
	/// Demo 5: Add an index and fast-scrolling
	/// </summary>
	[Activity (Label = "Speakers", Icon="@drawable/ic_launcher")]			
	public class SpeakersActivity : ListActivity
	{
        private SpeakersAdapter adapter;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            adapter = new SpeakersAdapter(this, Speakers.GetSpeakerData());
			ListView.Adapter = adapter;
			ListView.FastScrollEnabled = true;
		}

		/// <summary>
		/// Demonstrates how to handle a row click
		/// </summary>
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			var speakerName = adapter[position].Name;
			var intent = new Intent(this, typeof(SpeakerActivity));
			intent.PutExtra("Name", speakerName);
			StartActivity(intent);
		}
	}
}

