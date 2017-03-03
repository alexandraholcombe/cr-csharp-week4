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

            Get["/bands/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>(){};
                Band newBand = Band.Find(parameters.id);
                List<Venue> allVenues = Venue.GetAll();
                List<Venue> bandVenues = newBand.GetVenues();
                model.Add("band", newBand);
                model.Add("venues", allVenues);
                model.Add("bandVenues", bandVenues);
                return View["band.cshtml", model];
            };

            Post["/bands/{id}"] = parameters => {
                Venue newVenue = Venue.Find(Request.Form["venue"]);
                Band newBand = Band.Find(parameters.id);
                newBand.AddVenue(newVenue);
                Dictionary<string, object> model = new Dictionary<string, object>(){};
                List<Venue> allVenues = Venue.GetAll();
                List<Venue> bandVenues = newBand.GetVenues();
                model.Add("band", newBand);
                model.Add("venues", allVenues);
                model.Add("bandVenues", bandVenues);
                return View["band.cshtml", model];
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

            Get["/venues/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>(){};
                Venue newVenue = Venue.Find(parameters.id);
                List<Band> allBands = Band.GetAll();
                List<Band> venueBands = newVenue.GetBands();
                model.Add("venue", newVenue);
                model.Add("bands", allBands);
                model.Add("venueBands", venueBands);
                return View["venue.cshtml", model];
            };

            Post["/venues/{id}"] = parameters => {
                Venue newVenue = Venue.Find(parameters.id);
                Band newBand = Band.Find(Request.Form["band"]);
                newVenue.AddBand(newBand);
                Dictionary<string, object> model = new Dictionary<string, object>(){};
                List<Band> allBands = Band.GetAll();
                List<Band> venueBands = newVenue.GetBands();
                model.Add("venue", newVenue);
                model.Add("bands", allBands);
                model.Add("venueBands", venueBands);
                return View["venue.cshtml", model];
            };

            Patch["/venues/{id}"] = parameters => {
                Venue newVenue = Venue.Find(parameters.id);
                newVenue.Update(Request.Form["venue"]);
                Dictionary<string, object> model = new Dictionary<string, object>(){};
                List<Band> allBands = Band.GetAll();
                List<Band> venueBands = newVenue.GetBands();
                model.Add("venue", newVenue);
                model.Add("bands", allBands);
                model.Add("venueBands", venueBands);
                return View["venue.cshtml", model];
            };

            Get["/venues/{id}/edit"] = parameters => {
                Venue newVenue = Venue.Find(parameters.id);
                return View["editvenue.cshtml", newVenue];
            };
        }
    }
}
