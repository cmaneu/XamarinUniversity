using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using Android.Widget;
using ListViewsInAndroid.Model;

namespace ListViewsInAndroid
{
	/// <summary>
	/// Demo 3: Row styles
	/// </summary>
	public class SpeakersAdapter: BaseAdapter<Speaker>
	{
		private readonly List<Speaker> data;
		private readonly Activity context;

		public SpeakersAdapter(Activity activity, IEnumerable<Speaker> speakers) 
		{
			data = speakers.OrderBy(s => s.Name).ToList();
			context = activity;
		}

		public override long GetItemId(int position)
		{
			return position;
		}
		
        public override Speaker this[int index]
		{
			get { return data[index]; }
		}
		
        public override int Count
		{
			get { return data.Count; }
		}
		
        public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			
            if (view == null) {
                //TODO: Demo3 - Step 1 - Comment out each type in turn and run the application to see different styles
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
//              view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
//				view = context.LayoutInflater.Inflate(Android.Resource.Layout.TwoLineListItem, null);
//				view = context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
			}

			var speaker = data[position];

            // Attempt to populate the first TextView - this should be present on all
            // the available styles.
            TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            if (textView != null)
                textView.Text = speaker.Name;

            // Try the Detail item TextView -- this is not available in every style.
            // Specifically, this will not work in SimpleListItem1 or ActivityListItem
            textView = view.FindViewById<TextView>(Android.Resource.Id.Text2);
            if (textView != null)
                textView.Text = speaker.Company;

            // Populate the image if available; this is only available in ActivityListItem.
            ImageView imageView = view.FindViewById<ImageView>(Android.Resource.Id.Icon);
            if (imageView != null)
                imageView.SetImageDrawable (GetHeadShot (speaker.HeadshotUrl));

			return view;
		}

		/// <summary>
		/// Helper to load images
		/// </summary>
		private Drawable GetHeadShot(string url) 
		{
			Drawable headshotDrawable = null;
			try 
			{
				headshotDrawable = Drawable.CreateFromStream(context.Assets.Open(url), null);
			}
			catch (Exception ex) 
			{
				Log.Debug (GetType().FullName, "Error getting headshot for " + url + ", " + ex.ToString ());
				headshotDrawable = null;
			}
			return headshotDrawable;
		}
	}
}