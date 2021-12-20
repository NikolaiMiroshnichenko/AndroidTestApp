using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidTestApp.Models;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidTestApp.Viewholder
{
    public class PlanetViewHolder: RecyclerView.ViewHolder
    {
        public TextView NameTextView { get; internal set; }
        public TextView TerrainTextView { get; internal set; }
        public TextView PoppulationTextView { get; internal set; }

        public PlanetViewHolder(View view) : base(view)
        {
            NameTextView = (TextView)view.FindViewById(Resource.Id.nameTextView);
            TerrainTextView = (TextView)view.FindViewById(Resource.Id.terrainTextView);
            PoppulationTextView = (TextView)view.FindViewById(Resource.Id.populationTextView);
        }
    }
}