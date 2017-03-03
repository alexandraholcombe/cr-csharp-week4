using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
    public class Band
    {
        private int _id;
        private string _name;

        public Band(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        //Does some stuff involving equals who knows what
        public override bool Equals(System.Object otherBand)
        {
            if(!(otherBand is Band))
            {
                return false;
            }
            else
            {
                Band newBand = (Band) otherBand;
                bool idEquality = (this.GetId() == newBand.GetId());
                bool nameEquality = (this.GetName() == newBand.GetName());

                return (idEquality && nameEquality);
            }
        }

        //Delete all rows in the bands table
        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM bands;", conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //Output all rows in bands table to List
        public static List<Band> GetAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM bands ORDER BY name;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<Band> allBands = new List<Band>{};

            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);

                Band newBand = new Band(name, id);
                allBands.Add(newBand);
            }

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return allBands;
        }

        //Saves instances to databasejj
        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO bands (name) OUTPUT INSERTED.id VALUES (@BandName);", conn);
            cmd.Parameters.Add(new SqlParameter("@BandName", this.GetName()));
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }
        }

        //Finds instance in database
        public static Band Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM bands WHERE id = @BandId;", conn);
            cmd.Parameters.Add(new SqlParameter("@BandId", id.ToString()));

            SqlDataReader rdr = cmd.ExecuteReader();

            int foundId = 0;
            string foundName = null;

            while(rdr.Read())
            {
                foundId = rdr.GetInt32(0);
                foundName = rdr.GetString(1);
            }
            Band foundBand = new Band(foundName, foundId);

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return foundBand;
        }

        //Adds row to join table joining band and venue
        public void AddVenue(Venue venue)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues (band_id, venue_id) VALUES (@BandId, @VenueId);", conn);
            cmd.Parameters.Add(new SqlParameter("@VenueId", venue.GetId()));
            cmd.Parameters.Add(new SqlParameter("@BandId", this.GetId()));

            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        //Returns list with all rows matching venue id from join table
        public List<Venue> GetVenues()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT venues.* FROM bands JOIN bands_venues ON(bands.id = bands_venues.band_id) JOIN venues ON(bands_venues.venue_id = venues.id) WHERE bands.id = @BandId ORDER BY name;", conn);
            cmd.Parameters.Add(new SqlParameter("@BandId", this.GetId()));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<Venue> allVenues = new List<Venue>{};

            while(rdr.Read())
            {
                int venueId = rdr.GetInt32(0);
                string venueName = rdr.GetString(1);

                Venue newVenue = new Venue(venueName, venueId);
                allVenues.Add(newVenue);
            }

            if (rdr != null)
            {
                rdr.Close();
            }

            if (conn != null)
            {
                conn.Close();
            }
            return allVenues;
        }


    }
}
