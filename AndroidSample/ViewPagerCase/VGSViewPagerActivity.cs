
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

namespace AndroidSample.ViewPagerCase
{
    [Activity(Label = "VGSViewPagerActivity")]
    public class VGSViewPagerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_viewpager_collect_demo);

            // Create your application here
        }
    }
}
