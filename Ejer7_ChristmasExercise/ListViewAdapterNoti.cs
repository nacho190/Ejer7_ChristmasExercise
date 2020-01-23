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
    class ListViewAdapterNoti : BaseAdapter<Notification>
    {
        public List<Notification> miItems;
        private Context miContext;

        public ListViewAdapterNoti(Context context, List<Notification> items)
        {
            miItems = items;
            miContext = context;
        }

        public override Notification this[int position]
        {
            get { return miItems[position]; }
        }

        public override int Count
        {
            get { return miItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(miContext).Inflate(Resource.Layout.ListaNoti, null, false);
            }

            TextView textViewDate = row.FindViewById<TextView>(Resource.Id.fecha);
            textViewDate.Text = ""+miItems[position].Fecha;
            TextView textViewNoti = row.FindViewById<TextView>(Resource.Id.noti);
            textViewNoti.Text = miItems[position].Noti;

            return row;
        }

        public override void NotifyDataSetChanged()
        {
            base.NotifyDataSetChanged();
        }


    }
}