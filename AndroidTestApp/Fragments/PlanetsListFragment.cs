using Android.OS;
using Android.Views;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndroidTestApp.Adapters;
using AndroidTestApp.Models;
using AndroidX.RecyclerView.Widget;
using System.Net.Http;
using ModernHttpClient;
using AndroidTestApp.RestApi;

namespace AndroidTestApp.Fragments
{
    public class PlanetsListFragment: AndroidX.Fragment.App.Fragment
    {
        private List<Planet> _planets;
        private IPlanetsApi _planetsApi;
        private PlanetsListAdapter _adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            _planets = new List<Planet>();
            base.OnCreate(savedInstanceState);
            InitializeRestServices();
            InitializePlanets();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Activity.Title = "Second (planets list) page";
            var  view =    inflater.Inflate(Resource.Layout.planets_list, container, false);
            var recycler = view.FindViewById<RecyclerView>(Resource.Id.planetsRecycler);
            _adapter = new PlanetsListAdapter(Activity, _planets);
            recycler.SetLayoutManager(new LinearLayoutManager(Activity));
            recycler.SetAdapter(_adapter);
            return view;
        }

        public override void OnResume()
        {
            if (Activity is MainActivity activity)
            {
                activity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }
            base.OnResume();
        }

        private void InitializeRestServices()
        {
            var client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri("https://swapi.dev/api")
            };
            _planetsApi = RestService.For<IPlanetsApi>(client);
        }

        private void InitializePlanets()
        {
            Task.Run(async () =>
            {
                try
                {
                    _planets.Clear();
                    _planets.AddRange((await _planetsApi.GetPlanets()).Results);
                    Activity.RunOnUiThread(() => _adapter.NotifyDataSetChanged());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            );           
        }
    }
}