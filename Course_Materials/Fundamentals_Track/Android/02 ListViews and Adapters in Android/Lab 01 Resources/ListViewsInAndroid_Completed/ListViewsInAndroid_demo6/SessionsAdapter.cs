using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using ListViewsInAndroid.Model;

namespace ListViewsInAndroid 
{
	public class SessionsAdapter: BaseAdapter<Session> 
	{
        private readonly List<Session> data;
        private readonly Activity context;
		
		public SessionsAdapter(Activity activity, IEnumerable<Session> sessions) 
		{
			data = sessions.OrderBy(s => s.Title).ToList();
			context = activity;
		}

		public override long GetItemId(int position)
		{
			return position;
		}
		
		public override Session this[int index]
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
			var speakerNameView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			speakerNameView.Text = speaker.Title;

			return view;
		}
	}
}