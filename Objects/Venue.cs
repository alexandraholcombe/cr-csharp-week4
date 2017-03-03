using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
    public class Venue
    {
        private int _id;
        private string _name;

        public Venue(string name, int id = 0)
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
        public override bool Equals(System.Object otherVenue)
        {
            if(!(otherVenue is Venue))
            {
                return false;
            }
            else
            {
                Venue newVenue = (Venue) otherVenue;
                bool idEquality = (this.GetId() == newVenue.GetId());
                bool nameEquality = (this.GetName() == newVenue.GetName());

                return (idEquality && nameEquality);
            }
        }

        //Delete all rows in the venues table
        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //Output all rows in venues table to List
        public static List<Venue> GetAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM venues ORDER BY name;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<Venue> allVenues = new List<Venue>{};

            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);

                Venue newVenue = new Venue(name, id);
                allVenues.Add(newVenue);
            }

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return allVenues;
        }

        //Saves instances to databasejj
        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO venues (name) OUTPUT INSERTED.id VALUES (@VenueName);", conn);
            cmd.Parameters.Add(new SqlParameter("@VenueName", this.GetName()));
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
        public static Venue Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM venues WHERE id = @VenueId;", conn);
            cmd.Parameters.Add(new SqlParameter("@VenueId", id.ToString()));

            SqlDataReader rdr = cmd.ExecuteReader();

            int foundId = 0;
            string foundName = null;

            while(rdr.Read())
            {
                foundId = rdr.GetInt32(0);
                foundName = rdr.GetString(1);
            }
            Venue foundVenue = new Venue(foundName, foundId);

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return foundVenue;
        }

        //Changes name column of venue row in database
        public void Update(string newName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE venues SET name = @NewVenueName OUTPUT INSERTED.name WHERE id = @VenueId;", conn);
            cmd.Parameters.Add(new SqlParameter("@NewVenueName", newName));
            cmd.Parameters.Add(new SqlParameter("@VenueId", this.GetId()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._name = rdr.GetString(0);
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

        //Adds row to join table joining band and venue
        public void AddBand(Band band)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues (band_id, venue_id) VALUES (@BandId, @VenueId);", conn);
            cmd.Parameters.Add(new SqlParameter("@BandId", band.GetId()));
            cmd.Parameters.Add(new SqlParameter("@VenueId", this.GetId()));

            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        //Returns list with all rows matching venue id from join table
        public List<Band> GetBands()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT bands.* FROM venues JOIN bands_venues ON(venues.id = bands_venues.venue_id) JOIN bands ON(bands_venues.band_id = bands.id) WHERE venues.id = @VenueId;", conn);
            cmd.Parameters.Add(new SqlParameter("@VenueId", this.GetId()));

            SqlDataReader rdr = cmd.ExecuteReader();

            List<Band> allBands = new List<Band>{};

            while(rdr.Read())
            {
                int bandId = rdr.GetInt32(0);
                string bandName = rdr.GetString(1);

                Band newBand = new Band(bandName, bandId);
                allBands.Add(newBand);
            }

            if (rdr != null)
            {
                rdr.Close();
            }

            if (conn != null)
            {
                conn.Close();
            }
            return allBands;
        }

        //Deletes row from venue table
        public void Delete()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM venues WHERE id = @VenueId;", conn);
            cmd.Parameters.Add(new SqlParameter("@VenueId", this.GetId()));
            cmd.ExecuteNonQuery();
            conn.Close();
        }



    }
}
