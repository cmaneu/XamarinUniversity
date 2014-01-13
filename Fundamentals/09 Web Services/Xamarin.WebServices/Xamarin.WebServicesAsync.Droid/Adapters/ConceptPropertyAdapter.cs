using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace Xamarin.WebServicesAsync.Droid.Adapters
{
    public class SpeakersAdapter : BaseAdapter<Speaker>
    {
        private readonly Activity activity;
        private readonly List<Speaker> speakers;

        public SpeakersAdapter(Activity context, IEnumerable<Speaker> speakers)
        {
            this.speakers = speakers.ToList();
            activity = context;
        }

        public override int Count { get { return speakers.Count; } }

        public override Speaker this[int position] { get { return speakers[position]; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.speaker_row, null);

            var speaker = speakers[position];

            var speakerNameView = view.FindViewById<TextView>(Resource.Id.speakerNameTextView);
            speakerNameView.Text = speaker.Name;

			var sessionCountView = view.FindViewById<TextView>(Resource.Id.speakerCompanyTextView);
			sessionCountView.Text = speaker.Company;

            return view;
        }	
    }
}
