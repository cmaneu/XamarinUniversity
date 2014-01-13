using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace Xamarin.WebServicesAsync.Droid.Adapters
{
	public class ConceptPropertyAdapter : BaseAdapter<Model.ConceptProperty>
    {
		private readonly Activity activity;
		public List<Model.ConceptProperty> ConceptProperties {get; private set;}

		public ConceptPropertyAdapter(Activity context, IEnumerable<Model.ConceptProperty> conceptProperties)
		{
			this.ConceptProperties = conceptProperties.ToList();
			activity = context;
		}

		public override int Count { get { return ConceptProperties.Count; } }

		public override Model.ConceptProperty this[int position] { get { return ConceptProperties[position]; } }

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

			var conceptProperty = ConceptProperties[position];

			var name = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			name.Text = !String.IsNullOrEmpty(conceptProperty.Synonym) ? conceptProperty.Synonym : conceptProperty.Name;

			var rxcui = view.FindViewById<TextView>(Android.Resource.Id.Text2);
			rxcui.Text = !String.IsNullOrEmpty(conceptProperty.Synonym) ? conceptProperty.Name : String.Empty;

			return view;
		}
    }
}
