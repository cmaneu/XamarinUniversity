using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using ListViewsInAndroid.Model;

namespace ListViewsInAndroid
{
	/// <summary>
	/// Demo 3: Row styles
	/// </summary>
    [Activity (Label = "ListView.Demo3", MainLauncher = true, Icon="@drawable/ic_launcher")]			
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

