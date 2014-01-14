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
	/// Demo 5: Add an index
	/// </summary>		
    public class SpeakersAdapter: BaseAdapter<Speaker>, ISectionIndexer
	{
        private readonly List<Speaker> data;
        private readonly Activity context;
		
		public SpeakersAdapter(Activity activity, IEnumerable<Speaker> speakers) 
		{
			data = speakers.OrderBy(s => s.Name).ToList();
			context = activity;

            // Setup the indexer support
            SetupIndex();
		}

        // Implement ISectionIndexer
		// -- ISectionIndexer --

        private string[] sections;
        private Java.Lang.Object[] sectionsObjects;
        private Dictionary<string, int> alphaIndex;

        /// <summary>
        /// Setup for ISectionIndexer
        /// </summary>
        private void SetupIndex()
        {
            alphaIndex = new Dictionary<string, int>();
            for (int i = 0; i < data.Count; i++) {
                var key = data[i].Name[0].ToString();  // first character of name
                if (!alphaIndex.ContainsKey(key)) 
                    alphaIndex.Add(key, i);
            }
            sections = new string[alphaIndex.Keys.Count];
            alphaIndex.Keys.CopyTo(sections, 0);
            sectionsObjects = new Java.Lang.Object[sections.Length];
            for (int i = 0; i < sections.Length; i++) {
                sectionsObjects[i] = new Java.Lang.String(sections[i]);
            }
        }

		public int GetPositionForSection(int section)
		{
			return alphaIndex[sections[section]];
		}

		public int GetSectionForPosition(int position)
		{
			int prevSection = 0; 
			for (int i = 0; i < sections.Length; i++) {
				if (GetPositionForSection(i) > position && prevSection <= position) { 
					prevSection = i; break; 
				}
				prevSection = i; 
			} 
			return prevSection; 
		}

		public Java.Lang.Object[] GetSections()
		{
			return sectionsObjects;
		}

		// -- END ISectionIndexer --

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
			if (view == null)
			{
				view = context.LayoutInflater.Inflate(Resource.Layout.speaker_row, null);
			}
			
			var speaker = data[position];
			
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
		
        private readonly Dictionary<string,WeakReference> _headshots = new Dictionary<string, WeakReference>();

		private Drawable GetHeadShot(string url) 
		{
            Drawable headshotDrawable = null;
            WeakReference wr;

            if (_headshots.TryGetValue(url, out wr)) {
                headshotDrawable = wr.Target as Drawable;
                if (headshotDrawable != null)
                    return headshotDrawable;
                else {
                    _headshots.Remove(url);
                }
            }

			try 
			{
				headshotDrawable = Drawable.CreateFromStream(context.Assets.Open(url), null);
                _headshots.Add(url, new WeakReference(headshotDrawable));
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

