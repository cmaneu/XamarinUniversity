using System;

using Android.App;
using Android.Content;
using Android.OS;

namespace EvolveLite
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : TabActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            CreateTab(typeof(SpeakersActivity), "speakers", Resource.String.activity_speakers_label, Resource.Drawable.ic_tab_speakers);
            CreateTab(typeof(SessionsActivity), "sessions", Resource.String.activity_sessions_label, Resource.Drawable.ic_tab_sessions);
            CreateTab(typeof(AboutActivity), "about", Resource.String.activity_about_label, Resource.Drawable.ic_tab_about);
        }

        private void CreateTab(Type activityType, string tag, int labelId, int drawableId)
        {
            // Load the icon resource as a drawable 
            var drawableIcon = Resources.GetDrawable(drawableId);

            // Load the string resource for the label
            var label = Resources.GetString(labelId);

            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);

            var spec = TabHost.NewTabSpec(tag);
            spec.SetIndicator(label, drawableIcon);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }

    }
}
