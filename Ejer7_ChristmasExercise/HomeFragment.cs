using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util.Zip;

namespace Ejer7_ChristmasExercise
{
    class HomeFragment : Android.Support.V4.App.Fragment
    {
         View v;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            v = inflater.Inflate(Resource.Layout.Home, container, false);
            var milistview = v.FindViewById<ListView>(Resource.Id.ListaCasa);

            ListViewAdapterCheck adapter = new ListViewAdapterCheck(this.Context, ServicioLista.Instance.MyList);
            milistview.Adapter = adapter;

            adapter.NotifyDataSetChanged();
            
           
            return v;
        }

    }
}