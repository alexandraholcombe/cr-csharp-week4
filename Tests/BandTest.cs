using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
    public class BandTest: IDisposable
    {
        public BandTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        //Delete everything between tests
        public void Dispose()
        {
            Band.DeleteAll();
        }

        //GetAll returns empty list if no bands
        [Fact]
        public void GetAll_ForNoBands_EmptyList()
        {
            //Arrange, Act, Assert
            List<Band> actualResult = Band.GetAll();
            List<Band> expectedResult = new List<Band>{};

            Assert.Equal(expectedResult, actualResult);
        }


        //Checks for bands table has zero rows at beginning of test
        [Fact]
        public void Test_ForNoRowsInBandsTable()
        {
            int actualResult = Band.GetAll().Count;
            int expectedResult = 0;

            Assert.Equal(expectedResult, actualResult);
        }

    }
}
