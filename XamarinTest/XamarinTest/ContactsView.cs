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
using Android.Provider;
using Android.Database;

namespace XamarinTest
{
    [Activity]
    class ContactsView: ListActivity
    {
        string[] names;
        const string ACTION_NEW_TABSELECTED = "NEWTABSELECTED";
        MainActivityBroadcast broadcastRecv;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContactsView);

            broadcastRecv = new MainActivityBroadcast();
            
            RegisterReceiver(broadcastRecv,
                 new IntentFilter(ACTION_NEW_TABSELECTED));

            broadcastRecv.actionRecv += OnBroadCastReceived;
        }

        private void OnBroadCastReceived(Context arg1, Intent arg2)
        {
            if (arg2 != null)
            {
                names = new string[4] { "Ivan", "Bogdan", "Vlad", "David" };
                ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.ContactsView, names);
            }
        }

        [Android.Runtime.Register("setAdapter", "(Landroid/widget/ListAdapter;)V", "GetSetAdapter_Landroid_widget_ListAdapter_Handler")]
        private void GetAddress()
        {
            var uri = ContactsContract.Contacts.ContentUri;

            string[] projection = { ContactsContract.Contacts.InterfaceConsts.Id, ContactsContract.Contacts.InterfaceConsts.DisplayName };

            var cursor = ManagedQuery(uri, projection, null, null, null);

            var contactList = new List<string>();

            if (cursor.MoveToFirst())
            {
                do
                {
                    contactList.Add(cursor.GetString(
                            cursor.GetColumnIndex(projection[1])));
                } while (cursor.MoveToNext());
            }

            //names = new string[4] { "Ivan", "Bogdan", "Vlad", "David" };
            //SetContentView(Resource.Layout.Main);
            //ListView lv = FindViewById<ListView>(Resource.Id.listView1);
            //lv.Adapter = new ArrayAdapter<string>(this, Resource.Id.tabcontent, names);
            //lv.ItemClick += OnListItemClick;
        }

        //private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        //{
        //    var listView = sender as ListView;
        //    var t = names[e.Position];
        //    Android.Widget.Toast.MakeText(this, t.ToString(), Android.Widget.ToastLength.Short).Show();
        //}

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            Toast.MakeText(this, names[position],
            ToastLength.Short).Show();
        }

        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(broadcastRecv, new IntentFilter(ACTION_NEW_TABSELECTED));
        }

        protected override void OnPause()
        {
            base.OnPause();
            UnregisterReceiver(broadcastRecv);
        }

    }
}