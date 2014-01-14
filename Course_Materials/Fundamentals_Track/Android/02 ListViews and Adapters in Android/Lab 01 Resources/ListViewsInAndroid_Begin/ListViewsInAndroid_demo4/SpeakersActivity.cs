using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ListViewsInAndroid.Model;

namespace ListViewsInAndroid
{
	/// <summary>
	/// Demo 4: Custom row layout
	/// </summary>
    [Activity (Label = "ListView.Demo4", MainLauncher = true, Icon="@drawable/ic_launcher")]			
	public class SpeakersActivity : ListActivity
	{
		private SpeakersAdapter adapter;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            adapter = new SpeakersAdapter(this, Speakers.GetSpeakerData());
			ListView.Adapter = adapter;
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

