using Android.App;
using Android.OS;

namespace AndroidSample.ActivityCase
{
    [Activity(Label = "VGSCollectActivity")]
    public class VGSCollectActivity : Activity
    {
        public const int USER_SCAN_REQUEST_CODE = 0x7;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_collect_demo);
        }
    }
}
