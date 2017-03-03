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

            SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
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

    }
}
