using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace PhonewordAndroid
{
    // TODO: Step 6 - fix title
    // TODO: Step 7 - add icon
    [Activity(Label = "PhonewordAndroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int count = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // TODO: Step 1 - Remove the boilerplate code, lines 14, 25-32

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.TranslateButton);
            button.Click += delegate
            {
                button.Text = string.Format("{0} clicks!", count++);
            };

            // TODO: Step 2 - Locate the controls in our created view.
            /*
            // Get our UI controls from the loaded layout
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            Button callButton = FindViewById<Button>(Resource.Id.CallButton);
            */

            // TODO: Step 3 - Disable the "Call" button
//            callButton.Enabled = false;

            // TODO: Step 4 - Add code to translate number
            /*
            string translatedNumber = string.Empty;

            translateButton.Click += delegate
            {
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
            */

            // TODO: Step 5 - Add callButton event handler here
            /*
            callButton.Click += (sender, e) =>
            {
                // On "Call" button click, try to dial phone number.
                var callDialog = new AlertDialog.Builder(this);
                callDialog.SetMessage("Call " + translatedNumber + "?");
                callDialog.SetNeutralButton("Call", 
                    delegate
                    {
                        // Create intent to dial phone
                        var callIntent = new Intent(Intent.ActionCall);
                        callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
                        StartActivity(callIntent);
                    });
                callDialog.SetNegativeButton("Cancel", delegate
                {
                });

                // Show the alert dialog to the user and wait for response.
                callDialog.Show();
            };
            */
        }
    }
}


