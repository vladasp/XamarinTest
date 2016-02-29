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
    public class MyFragmentAdapter : FragmentPagerAdapter
    {
        List<string> items = new List<string>();

        public MyFragmentAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
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
}