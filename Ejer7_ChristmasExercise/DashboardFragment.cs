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
using Environment = System.Environment;

namespace Ejer7_ChristmasExercise
{
    class DashboardFragment : Android.Support.V4.App.Fragment
    {
        View v;
        EditText EditTextCheckName;
        SQLiteConnection db;
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            v = inflater.Inflate(Resource.Layout.Dashboard, container, false);
            ServicioLista.Instance.MyListnoti.Clear();
            ServicioLista.Instance.MyList.Clear();

            Button addButton = v.FindViewById<Button>(Resource.Id.AddButton);
            EditTextCheckName = v.FindViewById<EditText>(Resource.Id.NombreRegalo);
            addButton.Click += AddCheckBox;
            Connectionbd();
            Add();
            return v;
        }

        void AddCheckBox(object sender, EventArgs e)
        {
      
            CheckBox c = new CheckBox(this.Context){ Text = EditTextCheckName.Text };
            CheckName cn = new CheckName() { nombre = EditTextCheckName.Text};
            if (EditTextCheckName.Text != "")
            {
            ServicioLista.Instance.MyList.Add(c);
           
            Toast.MakeText(Application.Context, $"Regalo {EditTextCheckName.Text} ha sido añadido", ToastLength.Short).Show();
            Notification n = new Notification() { Fecha = DateTime.Now, Noti = "Has añadido el regalo " + EditTextCheckName.Text };
            ServicioLista.Instance.MyListnoti.Add(n);
                db.Insert(n);
                db.Insert(cn);
            }

        }
        void Add()//añado a las listas el contenido de la base de datos
        {

            foreach (var i in db.Table<Notification>())
            {
                ServicioLista.Instance.MyListnoti.Add(i);
            }
            foreach (var i in db.Table<CheckName>())
            {
                ServicioLista.Instance.MyList.Add(new CheckBox(this.Context) { Text =i.nombre});
            }

        }
        void Connectionbd()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "try.db3");
            db = new SQLiteConnection(dbPath);

            db.CreateTable<Notification>();
            db.CreateTable<CheckName>();

        }
    }
}