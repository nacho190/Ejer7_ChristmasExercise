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
    class ServicioLista
    {

        private static ServicioLista _instance = new ServicioLista();

        protected ServicioLista()
        {

        }

        public static ServicioLista Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServicioLista();
                }
                return _instance;
            }
        }

        public List<CheckBox> MyList = new List<CheckBox>();
        public List<Notification> MyListnoti = new List<Notification>();
    }
}