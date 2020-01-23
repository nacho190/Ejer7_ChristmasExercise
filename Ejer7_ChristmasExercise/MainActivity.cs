using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;

namespace Ejer7_ChristmasExercise
{
    [Activity(Label = "Regalitos", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            navigation.SelectedItemId = Resource.Id.navigation_dashboard;
            // Load the first fragment on creation
            LoadFragment(Resource.Id.navigation_dashboard);
        }
        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
        void LoadFragment(int id)
        {
            Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.navigation_home:
                    ChangeFragment(new HomeFragment(), "home");
                    break;
                case Resource.Id.navigation_dashboard:
                    ChangeFragment(new DashboardFragment(), "dashboard");
                    break;
                case Resource.Id.navigation_notifications:
                    ChangeFragment(new NotificationFragment(), "notification");
                    break;
            }

            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }
        public void ChangeFragment(Fragment fragment, string tagFragmentName)//metodo para evitar reiniciar las pestañas cuando se navega
        {

            FragmentManager mFragmentManager = SupportFragmentManager;
            FragmentTransaction fragmentTransaction = mFragmentManager.BeginTransaction();

            Fragment currentFragment = mFragmentManager.PrimaryNavigationFragment;
            if (currentFragment != null)
            {
                fragmentTransaction.Hide(currentFragment);
            }

            Fragment fragmentTemp = mFragmentManager.FindFragmentByTag(tagFragmentName);
            if (fragmentTemp == null)
            {
                fragmentTemp = fragment;
                fragmentTransaction.Add(Resource.Id.content_frame, fragmentTemp, tagFragmentName);
            }
            else
            {
                fragmentTransaction.Show(fragmentTemp);
            }

            fragmentTransaction.SetPrimaryNavigationFragment(fragmentTemp);
            fragmentTransaction.SetReorderingAllowed(true);
            fragmentTransaction.CommitNowAllowingStateLoss();
        }

    }
}

