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
	/// Demo 2: Use a custom adapter
	/// </summary>
    [Activity (Label = "ListView.Demo2", MainLauncher = true, Icon="@drawable/ic_launcher")]			
	public class SpeakersActivity : ListActivity 
    {
        //TODO: Demo2 - Step 1 - Add Speaker adapter
//		SpeakersAdapter adapter;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            var items = new string[] { "Miguel de Icaza", "Nat Friedman", "Bart Decrem", "Scott Hanselman" };
            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);

            //TODO: Demo2 - Step 2 - assign the adapter
//            adapter = new SpeakersAdapter(this, Speakers.GetSpeakerData());
//            ListAdapter = adapter;
		}

		/// <summary>
		/// Demonstrates how to handle a row click
		/// </summary>
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
            //TODO: Demo2 - Step 3 - use adapter to get correct speaker object
//            var t = adapter[position].Name;
//            Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
		}
	}
}

