using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using ListViewsInAndroid.Model;

namespace ListViewsInAndroid
{
	/// <summary>
	/// Demo 2: Custom adapter
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
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
			}

			var speaker = data[position];
			var text = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			text.Text = speaker.Name;

			return view;
		}
	}
}