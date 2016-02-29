using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;

namespace AppXamarin
{
    [Activity(Label = "AppXamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        private ViewPager vp;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            vp = FindViewById<ViewPager>(Resource.Id.viewPager);
            vp.Adapter = new MyFragmentAdapter(SupportFragmentManager);
        }
    }
}

