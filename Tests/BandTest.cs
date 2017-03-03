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

        //Checks if EqualOverride is working whatever that does because it clearly does not do what I thought it was doing before
        [Fact]
        public void EqualOverride_BandNamesAreSame_true()
        {
            //Arrange, Act
            Band firstBand = new Band("Pajama Funnel");
            Band secondBand = new Band("Pajama Funnel");

            //Assert
            Assert.Equal(firstBand, secondBand);
        }

        //Checks if instances are saved to database
        [Fact]
        public void Save_ForBand_SavesToDatabase()
        {
            //Arrange
            Band newBand = new Band("Pajama Funnel");

            //Act
            newBand.Save();

            //Assert
            List<Band> actualResult = Band.GetAll();
            List<Band> expectedResult = new List<Band>{newBand};
        }

        //Checks that database id is assigned when saved to db
        [Fact]
        public void Save_ForBand_AssignsDatabaseId()
        {
            //Arrange
            Band testBand = new Band("Pajama Funnel");

            //Act
            testBand.Save();
            Band savedBand = Band.GetAll()[0];

            //Assert
            Assert.Equal(testBand, savedBand);
        }

        //Checks that GetAll method works for multiple instances
        [Fact]
        public void GetAll_ForMultipleBands_ReturnsListWithAllBands()
        {
            //Arrange
            Band firstBand = new Band("Pajama Funnel");
            Band secondBand = new Band("Allergy of Warm");
            firstBand.Save();
            secondBand.Save();

            //Act, Assert
            List<Band> actualResult = Band.GetAll();
            List<Band> expectedResult = new List<Band> {secondBand, firstBand};

            Assert.Equal(expectedResult, actualResult);
        }

        //Checks that Find method finds correct band in databasejj
        [Fact]
        public void Find_ForBand_FindsBandInDatabase()
        {
            //Arrange
            Band testBand = new Band("Pajama Funnel");
            testBand.Save();

            //Act, Assert
            Band foundBand = Band.Find(testBand.GetId());
            Assert.Equal(testBand, foundBand);
        }

        //Checks that venue is added to list of band's venues
        [Fact]
        public void AddVenue_ForVenueAndBand_AddsRowToJoinTable()
        {
            //Arrange
            Venue testVenue = new Venue("The Station");
            testVenue.Save();

            Band testBand = new Band("Pajama Funnel");
            testBand.Save();

            //Act
            testBand.AddVenue(testVenue);

            //Assert
            List<Venue> actualResult = testBand.GetVenues();
            List<Venue> expectedResult = new List<Venue>{testVenue};

            Assert.Equal(expectedResult, actualResult);
        }

        //Checks that all added bands are returned to list of venue's bands
        [Fact]
        public void GetVenues_ForBand_ReturnsListOfVenues()
        {
            //Arrange
            Band testBand = new Band("Pajama Funnel");
            firstBand.Save();

            Venue firstVenue = new Venue("The Station");
            firstVenue.Save();

            Venue secondVenue = new Venue("Club Fiber");
            secondVenue.Save();

            //Act
            testBand.AddVenue(firstVenue);
            testBand.AddVenue(secondVenue);

            //Assert
            List<Venue> actualResult = testBand.GetVenues();
            List<Venue> expectedResult = new List<Venue> {secondVenue, firstVenue};

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
