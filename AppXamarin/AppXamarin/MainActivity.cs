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

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            vp = FindViewById<ViewPager>(Resource.Id.viewPager);
            vp.Adapter = new AwesomeFragmentAdapter(SupportFragmentManager);
        }
    }

    public class AwesomeFragmentAdapter : FragmentPagerAdapter
    {
        List<string> items = new List<string>();

        public AwesomeFragmentAdapter(Android.Support.V4.App.FragmentManager fm): base(fm)
        {
            items.Add("1 page");
            items.Add("2 page");
            items.Add("3 page");
            items.Add("4 page");
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            Android.Support.V4.App.Fragment fr = new Android.Support.V4.App.Fragment();
            switch (position)
            {
                case 0:
                    fr = new FirstFragment();
                    break;
                case 1:
                    fr = new SecondFragment();
                    break;
                case 2:
                    fr = new ThirdFragment();
                    break;
                case 3:
                    fr = new FourthFragment();
                    break;
            }
            return fr;
        }
    }

    public class FirstFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Contacts, container, false);
            return view;
        }
    }

    public class SecondFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Collection, container, false);
            return view;
        }
    }

    public class ThirdFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.DB, container, false);
            return view;
        }
    }

    public class FourthFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Image, container, false);
            return view;
        }
    }


}

