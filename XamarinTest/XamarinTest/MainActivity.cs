using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Android.Database;

namespace XamarinTest
{
    [Activity(Label = "XamarinTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : TabActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            CreateTab(typeof(ContactActivity), "contacts", "Contacts");
            CreateTab(typeof(ImageActivity), "image", "Images");
            CreateTab(typeof(DBActivity), "db", "DB");
            CreateTab(typeof(ChangeImageActivity), "changeImage", "Change images");
        }

        [Activity]
        public class ContactActivity : Activity
        {
            string[] names;

            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                TextView textview = new TextView(this);
                textview.Text = "This is the get contacts tab";
                SetContentView(textview);
            }

        }

        [Activity]
        public class ImageActivity : Activity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                TextView textview = new TextView(this);
                textview.Text = "This is the get images tab";
                SetContentView(textview);
            }
        }

        [Activity]
        public class DBActivity : Activity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                TextView textview = new TextView(this);
                textview.Text = "This is the DB tab";
                SetContentView(textview);
            }
        }

        [Activity]
        public class ChangeImageActivity : Activity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                TextView textview = new TextView(this);
                textview.Text = "This is the change image tab";
                SetContentView(textview);
            }
        }

        private void CreateTab(Type activityType, string tag, string label)
        {
            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.SetClass(this, typeof(ContactsView));

            var spec = TabHost.NewTabSpec(tag);
            spec.SetIndicator(label);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }
    }
}

