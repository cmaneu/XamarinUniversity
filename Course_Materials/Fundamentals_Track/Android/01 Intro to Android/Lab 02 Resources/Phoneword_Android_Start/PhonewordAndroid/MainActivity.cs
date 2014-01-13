using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PhonewordAndroid
{
    [Activity(Label = "Phoneword Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // TODO: Step 2 - add phone numbers collection
        //static readonly List<string> _phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            string translatedNumber = string.Empty;

            // Get our UI controls from the loaded layout
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            Button callButton = FindViewById<Button>(Resource.Id.CallButton);

            callButton.Enabled = false;
            
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

            // TODO: Step 1 - handle the Call History button
            /*
            Button CallHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);
            CallHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(CallHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", _phoneNumbers);
                StartActivity(intent);
            };
            */

            // On "Call" button click, try to dial phone number.
            callButton.Click += (sender, e) =>
            {
                var callDialog = new AlertDialog.Builder(this)
                    .SetMessage("Call " + translatedNumber + "?")
                    .SetNeutralButton("Call", delegate {
                        // TODO: Step 3a - add dialed number to list of called numbers.
                        //_phoneNumbers.Add(translatedNumber);
                        // TODO: Step 3b - enable the Call History button
                        //CallHistoryButton.Enabled = true;

                        var callIntent = new Intent(Intent.ActionCall);
                        callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
                        StartActivity(callIntent);
                    })
                    .SetNegativeButton("Cancel", delegate
                {
                });

                callDialog.Show();
            };
        }
    }
}


