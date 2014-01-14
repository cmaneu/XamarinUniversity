using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace ListViewsInAndroid
{
    [Activity (Label = "ListView.Demo6", MainLauncher = true, Icon="@drawable/ic_launcher")]			
	public class MenuActivity : ListActivity
	{
		string[] items;
		
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            // Setup the main menu
			items = new string[] { "Sessions", "Speakers", "About" };
			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
		}
		
		/// <summary>
		/// Demonstrates how to handle a row click
		/// </summary>
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            // Process the selection
            Intent nextScreen = null;
            switch (position)
            {
                case 0:
                    nextScreen = new Intent(this, typeof(SessionsActivity));
                    break;
                case 1:
                    nextScreen = new Intent(this, typeof(SpeakersActivity));
                    break;
                case 2:
                    nextScreen = new Intent(this, typeof(AboutActivity));
                    break;
            }

            if (nextScreen != null) {
                StartActivity(nextScreen);
            }
        }
	}
}