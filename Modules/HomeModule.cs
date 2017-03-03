using Nancy;
using System;
using System.Collections.Generic;
using BandTracker.Objects;

namespace BandTracker
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml"];
            };

            Get["/bands"] = _ => {
                List<Band> allBands = Band.GetAll();
                return View["bands.cshtml", allBands];
            };

            Get["/venues"] = _ => {
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };

            Get["/bands/new"] = _ => {
                return View["newband.cshtml"];
            };

            Post["/bands"] = _ => {
                Band newBand = new Band(Request.Form["band-name"]);
                newBand.Save();
                List<Band> allBands = Band.GetAll();
                return View["bands.cshtml", allBands];
            };

            Get["/venues/new"] = _ => {
                return View["newvenue.cshtml"];
            };

            Post["/venues"] = _ => {
                Venue newVenue = new Venue(Request.Form["venue-name"]);
                newVenue.Save();
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };
        }
    }
}
