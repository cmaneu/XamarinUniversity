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
	/// Demo 4: Custom row layout
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

		/// <summary>
		/// CUSTOM ROW STYLE !!
		/// </summary>
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			if (view == null) {
                // inflate the custom AXML layout
                view = context.LayoutInflater.Inflate(Resource.Layout.speaker_row, null);
			}
			
			var speaker = data[position];

            // Set the UI controls in the custom view
			var imageView = view.FindViewById<ImageView>(Resource.Id.headshotImageView);
			var headshot = GetHeadShot(speaker.HeadshotUrl);
			imageView.SetImageDrawable(headshot);
			
			var speakerNameView = view.FindViewById<TextView>(Resource.Id.speakerNameTextView);
			speakerNameView.Text = speaker.Name;
			
			var companyNameTextView = view.FindViewById<TextView> (Resource.Id.companyNameTextView);
			companyNameTextView.Text = speaker.Company;
			
			var twitterHandleView = view.FindViewById<TextView>(Resource.Id.twitterTextView);
			twitterHandleView.Text = "@" + speaker.TwitterHandle;
			
			return view;
		}
		
		private Drawable GetHeadShot(string url) 
		{
			Drawable headshotDrawable = null;
			try  {
				headshotDrawable = Drawable.CreateFromStream(context.Assets.Open(url), null);
			} catch (Exception ex)  {
				Log.Debug (GetType().FullName, "Error getting headshot for " + url + ", " + ex.ToString ());
				headshotDrawable = null;
			}
			return headshotDrawable;
		}
	}
}

