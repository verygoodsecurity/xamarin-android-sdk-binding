using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using System.Collections.Generic;
using Android.Content;
using AndroidSample.ActivityCase;
using AndroidSample.FragmentCase;
using AndroidSample.ViewPagerCase;
using static AndroidSample.Resource;

namespace AndroidSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class StartActivity : AppCompatActivity, IOnClickListener
    {
        public const string VAULT_ID = "user_vault_id";
        public const string ENVIROMENT = "user_env";
        public const string PATH = "user_path";
        
        protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);
            SetContentView(Layout.activity_start);

            SetupSpiner();
            SetupUI();
        }

        private void SetupUI()
        {
            FindViewById<EditText>(Id.userVault).Text = GetString(Resource.String.user_vault_id_hint);
            FindViewById<EditText>(Id.userPath).Text = GetString(Resource.String.user_endpoint_hint);
            
            FindViewById<Button>(Id.startWithActivityBtn).SetOnClickListener(this);
            FindViewById<Button>(Id.startWithFragmentBtn).SetOnClickListener(this);
            FindViewById<Button>(Id.startWithViewPagerBtn).SetOnClickListener(this);
        }

        private void SetupSpiner()
        {
            List<string> items = new List<string>
            {
                "SANDBOX", "LIVE"
            };

            var spinnerArrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
            spinnerArrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Spinner? spinner = FindViewById<Spinner>(Id.environmentSpinner);
            spinner.Adapter = spinnerArrayAdapter;
            spinner.SetSelection(0);

        }

        public void OnClick(View v)
        {
            StartActivity(GetIntent(v));
        }

        private Intent GetIntent(View v)
        {
            switch (v.Id)
            {
                case Id.startWithActivityBtn:
                    return PrepareIntent(typeof(VGSCollectActivity));
                case Id.startWithFragmentBtn:
                    return PrepareIntent(typeof(VGSCollectFragmentActivity));
                case Id.startWithViewPagerBtn:
                    return PrepareIntent(typeof(VGSViewPagerActivity));
            }
            
            throw new ArgumentException($"No action found for {v}");
        }
        
        
        private Intent PrepareIntent(Type type) {
            var intent = new Intent(this, type);

            intent.PutExtra(VAULT_ID, FindViewById<EditText>(Id.userVault).Text)
                  .PutExtra(PATH, FindViewById<EditText>(Id.userPath).Text)
                  .PutExtra(ENVIROMENT, FindViewById<Spinner>(Id.environmentSpinner).SelectedItemPosition);


            return intent;
        }
    }
}