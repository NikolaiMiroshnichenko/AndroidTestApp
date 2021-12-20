using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidTestApp.Fragments;
using AndroidX.AppCompat.App;
using System;

namespace AndroidTestApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _navigationButton;
        private LinearLayout _rootMainPageLayout;   
        private Android.Support.V7.Widget.Toolbar _toolbar;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            _toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);    
            SetContentView(Resource.Layout.activity_main);
            _navigationButton = FindViewById<Button>(Resource.Id.navgationButton);
            _rootMainPageLayout = FindViewById<LinearLayout>(Resource.Id.rootMainPageLayot);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (_toolbar!=null)
            {
                _toolbar.NavigationClick += ToolbarClick;
            }
     
            _navigationButton.Click += NavigateToList;
        }

        protected override void OnStop()
        {
            _navigationButton.Click -= NavigateToList; 
            if (_toolbar != null)
            {
                _toolbar.NavigationClick -= ToolbarClick;
            }
            base.OnStop();
        }

        private void NavigateToList(object sender, EventArgs e)
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.rootMainPageLayot, new PlanetsListFragment());
            transaction.Commit();
        }

        private void ToolbarClick(object sender, EventArgs e)
        {
            OnBackPressed();
        }
    }
}