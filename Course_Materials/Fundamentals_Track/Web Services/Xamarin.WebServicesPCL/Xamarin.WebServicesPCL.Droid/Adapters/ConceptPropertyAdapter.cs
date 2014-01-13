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

namespace Xamarin.WebServicesPCL.Droid.Adapters
{
	class ConceptPropertyAdapter: BaseAdapter<ConceptProperty>
	{
		private readonly Activity activity;
		public List<Core.Model.ConceptProperty> ConceptProperties {get; private set;}

		public ConceptPropertyAdapter(Activity context, IEnumerable<ConceptProperty> conceptProperties)
		{
			this.ConceptProperties = conceptProperties.ToList();
			activity = context;
		}

		public override int Count { get { return ConceptProperties.Count; } }

		public override ConceptProperty this[int position] { get { return ConceptProperties[position]; } }

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

