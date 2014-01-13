using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.WebServicesPCL.Core.Model;

namespace Xamarin.WebServicesPCL.Droid
{
	class ConceptPropertyAdapter: BaseAdapter<ConceptProperty>
	{
		private readonly Activity activity;
		private readonly List<Core.Model.ConceptProperty> conceptProperties;

		public ConceptPropertyAdapter(Activity context, IEnumerable<ConceptProperty> conceptProperties)
		{
			this.conceptProperties = conceptProperties.ToList();
			activity = context;
		}

		public override int Count { get { return conceptProperties.Count; } }

		public override ConceptProperty this[int position] { get { return conceptProperties[position]; } }

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

			var conceptProperty = conceptProperties[position];

			var rxcui = view.FindViewById<TextView>(Android.Resource.Id.Text1);

			rxcui.Text = conceptProperty.Rxcui;

			var name = view.FindViewById<TextView>(Android.Resource.Id.Text2);
			name.Text = conceptProperty.Name;

			return view;
		}
	}
}

