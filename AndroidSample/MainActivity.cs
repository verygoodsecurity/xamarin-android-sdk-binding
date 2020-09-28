using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Com.Verygoodsecurity.Vgscollect.Widget;
using Com.Verygoodsecurity.Vgscollect.Core;
using Com.Verygoodsecurity.Vgscollect.Core.Model.Network;
using Android.Util;
using static Android.Views.View;
using Android.Views;
using Com.Verygoodsecurity.Vgscollect.Core.Storage;
using Com.Verygoodsecurity.Vgscollect.Core.Model.State;
using System.Text;
using System.Collections.Generic;
using Android.Content;
using Com.Verygoodsecurity.Api.Cardio;
using Java.Util;

namespace AndroidSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IVgsCollectResponseListener, IOnClickListener,
        IOnFieldStateChangeListener
    {
        private const int USER_SCAN_REQUEST_CODE = 0x7;
        private string TAG = "VGSCollect";

        private TextView stateView;
        private TextView responseView;

        private VGSCardNumberEditText cardNumber;
        private CardVerificationCodeEditText cvcField;
        private PersonNameEditText personName;
        private ExpirationDateEditText expDate;

        private VGSCollect collect;

        protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            initVGSCollect();
            initViews();
            bindFields();
            Log.Info(TAG, "Inited");
        }

        private void initVGSCollect()
        {
            collect = new VGSCollect(this, "tntpszqgikn", Com.Verygoodsecurity.Vgscollect.Core.Environment.Sandbox);
            collect.AddOnResponseListeners(this);
            collect.AddOnFieldStateChangeListener(this);
        }

        private void initViews()
        {
            stateView = this.FindViewById<TextView>(Resource.Id.statesView);
            responseView = this.FindViewById<TextView>(Resource.Id.responseView);

            cardNumber = this.FindViewById<VGSCardNumberEditText>(Resource.Id.cardNumberField);
            cvcField = this.FindViewById<CardVerificationCodeEditText>(Resource.Id.cardCVCField);
            personName = this.FindViewById<PersonNameEditText>(Resource.Id.cardHolderField);
            expDate = this.FindViewById<ExpirationDateEditText>(Resource.Id.cardExpDateField);

            Button submitBtn = this.FindViewById<Button>(Resource.Id.submitBtn);
            submitBtn.SetOnClickListener(this);

            Button scanBtn = this.FindViewById<Button>(Resource.Id.scanBtn);
            scanBtn.SetOnClickListener(this);
        }

        private void bindFields()
        {
            collect.BindView(cardNumber);
            collect.BindView(cvcField);
            collect.BindView(personName);
            collect.BindView(expDate);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.submitBtn)
            {
                submitData();
            }
            else if (v.Id == Resource.Id.scanBtn)
            {
                scanData();
            }
        }

        private void scanData()
        {
            var scanSettingsMap = new HashMap();
            scanSettingsMap.PutIfAbsent(cardNumber.FieldName, ScanActivity.CardNumber);
            scanSettingsMap.PutIfAbsent(expDate.FieldName, ScanActivity.CardExpDate);
            scanSettingsMap.PutIfAbsent(personName.FieldName, ScanActivity.CardHolder);
            scanSettingsMap.PutIfAbsent(cvcField.FieldName, ScanActivity.CardCvc);

            var intent = new Intent(this, typeof(ScanActivity));
            intent.PutExtra(ScanActivity.ScanConfiguration, scanSettingsMap);

            StartActivityForResult(intent, USER_SCAN_REQUEST_CODE);
        }

        private void submitData()
        {
            VGSRequest request = new VGSRequest.VGSRequestBuilder().
                SetPath("/post").
                SetMethod(HTTPMethod.Post).
                Build();

            collect.AsyncSubmit(request);
        }

        public void OnResponse(VGSResponse response)
        {
            if (response.Code > 300)
            {
                string responseStr = "code: " + response.Code + ", message: " + ((VGSResponse.ErrorResponse)response).LocalizeMessage;
                printResponse(responseStr);
                Log.Info(TAG, "error. "+responseStr);
            }
            else
            {
                string responseStr = "code: " + response.Code + ", response: " + ((VGSResponse.SuccessResponse)response).RawResponse;
                printResponse(responseStr);
                Log.Info(TAG, "success. " + responseStr);
            }

        }

        private void printResponse(string responseStr)
        {
            responseView.Text = responseStr;
        }

        public void OnStateChange(FieldState state)
        {
            printFieldsStates(state);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            
            // stateView.Text = data.Extras
            collect.OnActivityResult(requestCode, (int) resultCode, data);
        }

        private void printFieldsStates(FieldState activeFieldState)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("activeView: ")
                .Append(activeFieldState.FieldName)
                .Append("\n\n");
            IList<FieldState> states = collect.AllStates;
            for (int i = 0; i < states.Count; i++)
            {
                FieldState currentState = states[i];
                builder.Append("JsonName:").Append(currentState.FieldName).Append("\n")
                    .Append("Type:").Append(currentState.FieldType).Append("\n")
                    .Append("is valid:").Append(currentState.IsValid).Append("\n")
                    .Append("is empty:").Append(currentState.IsEmpty).Append("\n")
                    .Append("focus:").Append(currentState.HasFocus).Append("\n")
                    .Append("is requared:").Append(currentState.IsRequired).Append("\n")
                    .Append("\n");
            }

            stateView.Text = builder.ToString();

        }
    }
}