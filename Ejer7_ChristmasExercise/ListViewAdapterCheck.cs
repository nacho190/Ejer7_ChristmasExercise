using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Ejer7_ChristmasExercise
{

    class ListViewAdapterCheck : BaseAdapter<CheckBox>
    {
        public List<CheckBox> miItems;
        private Context miContext;
        CheckBox CheckBoxLista;
        SQLiteConnection db;
        public ListViewAdapterCheck(Context context, List<CheckBox> items)
        {
            miItems = items;
            miContext = context;
        }

        public override CheckBox this[int position]
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
                row = LayoutInflater.From(miContext).Inflate(Resource.Layout.ListaCheck, null, false);
            }
    
            CheckBoxLista = row.FindViewById<CheckBox>(Resource.Id.checkBox1);
            CheckBoxLista.Text = miItems[position].Text;
            CheckBoxLista.CheckedChange += Addnoti;
        

            return row;
        }

        public override void NotifyDataSetChanged()
        {
            base.NotifyDataSetChanged();
        }
        
        public void Addnoti(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "try.db3");
            db = new SQLiteConnection(dbPath);

            if (e.IsChecked)
            {
                ServicioLista.Instance.MyListnoti.Add(new Notification() { Fecha = DateTime.Now, Noti = $"{c.Text} esta marcado" });
                db.Insert(new Notification() { Fecha = DateTime.Now, Noti = $"{c.Text} esta marcado" });
            }
            else
            {
                ServicioLista.Instance.MyListnoti.Add(new Notification() { Fecha = DateTime.Now, Noti = $"{c.Text} esta desmarcado" });
                db.Insert(new Notification() { Fecha = DateTime.Now, Noti = $"{c.Text} esta desmarcado" });
            }
           
        }
        
    }
}