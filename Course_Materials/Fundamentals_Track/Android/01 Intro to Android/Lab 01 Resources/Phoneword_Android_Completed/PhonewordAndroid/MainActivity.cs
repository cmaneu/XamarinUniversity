using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PhonewordAndroid
{
    [Activity(Label = "Phoneword Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // TODO: Step 1 - Add code to translate number

            string translatedNumber = string.Empty;

            // Get our UI controls from the loaded layout
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            Button callButton = FindViewById<Button>(Resource.Id.CallButton);

            callButton.Enabled = false;
            
            translateButton.Click += delegate
            {
                // *** SHARED CODE ***
                translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (String.IsNullOrWhiteSpace(translatedNumber)) {
                    callButton.Text = "Call";
                    callButton.Enabled = false;
                }
                else {
                    callButton.Text = "Call " + translatedNumber;
                    callButton.Enabled = true;
                }
            };

            // TODO: Step 2 - Add callButton event handler here

            // On "Call" button click, try to dial phone number.
            callButton.Click += (object sender, EventArgs e) =>
            {
                var callDialog = new AlertDialog.Builder(this)
                    .SetMessage("Call " + translatedNumber + "?")
                    .SetNeutralButton("Call", 
                        delegate {
                            var callIntent = new Intent(Intent.ActionCall);
                            callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
                            StartActivity(callIntent);
                           })
                    .SetNegativeButton("Cancel", delegate {});

                callDialog.Show();
            };
        }
    }
}


