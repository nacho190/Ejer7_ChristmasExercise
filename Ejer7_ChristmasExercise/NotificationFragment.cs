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

namespace Ejer7_ChristmasExercise
{
    class NotificationFragment : Android.Support.V4.App.Fragment
    {
        View v;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            v = inflater.Inflate(Resource.Layout.Notification, container, false);
            var milistview = v.FindViewById<ListView>(Resource.Id.listanoti);

            ListViewAdapterNoti adapter = new ListViewAdapterNoti(this.Context, ServicioLista.Instance.MyListnoti);
            milistview.Adapter = adapter;

            adapter.NotifyDataSetChanged();
           
            return v;
        }
    }
}