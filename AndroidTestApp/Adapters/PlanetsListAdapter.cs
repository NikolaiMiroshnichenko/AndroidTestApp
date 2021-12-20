using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidTestApp.Models;
using AndroidTestApp.Viewholder;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidTestApp.Adapters
{
    public class PlanetsListAdapter : RecyclerView.Adapter
    {
        private readonly LayoutInflater _inflater;
        private readonly List<Planet> _planets;

        public override int ItemCount => _planets.Count;

        public PlanetsListAdapter(Context context, List<Planet> planets)
        {
            _planets = planets;
            _inflater = LayoutInflater.From(context);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = _inflater.Inflate(Resource.Layout.planet_item, parent, false);
            return new PlanetViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Planet planet = _planets.ElementAt(position);
            var planetVH = (PlanetViewHolder)holder;
            planetVH.NameTextView.Text = planet.Name;
            planetVH.TerrainTextView.Text = planet.Terrain;
            planetVH.PoppulationTextView.Text = planet.Population;
        }
    }
}