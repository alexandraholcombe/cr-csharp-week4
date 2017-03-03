using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
    public class VenueTest: IDisposable
    {
        public VenueTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }


        //GetAll returns empty list if no venues
        [Fact]
        public void GetAll_ForNoVenues_EmptyList()
        {
            //Arrange, Act, Assert
            List<Venue> actualResult = Venue.GetAll();
            List<Venue> expectedResult = new List<Venue>{};

            Assert.Equal(expectedResult, actualResult);
        }

        //Checks for venues table has zero rows at beginning of test
        [Fact]
        public void Test_ForNoRowsInVenuesTable()
        {
            int actualResult = Venue.GetAll().Count;
            int expectedResult = 0;

            Assert.Equal(expectedResult, actualResult);
        }

        //Checks if EqualOverride is working whatever that does because it clearly does not do what I thought it was doing before
        [Fact]
        public void EqualOverride_VenueNamesAreSame_true()
        {
            //Arrange, Act
            Venue firstVenue = new Venue("The Station");
            Venue secondVenue = new Venue("The Station");

            //Assert
            Assert.Equal(firstVenue, secondVenue);
        }

        //Checks if instances are saved to database
        [Fact]
        public void Save_ForVenue_SavesToDatabase()
        {
            //Arrange
            Venue newVenue = new Venue("The Station");

            //Act
            newVenue.Save();

            //Assert
            List<Venue> actualResult = Venue.GetAll();
            List<Venue> expectedResult = new List<Venue>{newVenue};
        }

        //Checks that database id is assigned when saved to db
        [Fact]
        public void Save_ForVenue_AssignsDatabaseId()
        {
            //Arrange
            Venue testVenue = new Venue("The Station");

            //Act
            testVenue.Save();
            Venue savedVenue = Venue.GetAll()[0];

            //Assert
            Assert.Equal(testVenue, savedVenue);
        }

        //Checks that GetAll method works for multiple instances
        [Fact]
        public void GetAll_ForMultipleVenues_ReturnsListWithAllVenues()
        {
            //Arrange
            Venue firstVenue = new Venue("The Station");
            Venue secondVenue = new Venue("Club Fiber");
            firstVenue.Save();
            secondVenue.Save();

            //Act, Assert
            List<Venue> actualResult = Venue.GetAll();
            List<Venue> expectedResult = new List<Venue> {secondVenue, firstVenue};

            Assert.Equal(expectedResult, actualResult);
        }

        //Checks that Find method finds correct venue in databasejj
        [Fact]
        public void Find_ForVenue_FindsVenueInDatabase()
        {
            //Arrange
            Venue testVenue = new Venue("The Station");
            testVenue.Save();

            //Act, Assert
            Venue foundVenue = Venue.Find(testVenue.GetId());
            Assert.Equal(testVenue, foundVenue);
        }

        //Checks that Update method changes name of Venue
        [Fact]
        public void Update_ForVenueName_ReturnsVenueWithNewNameSameId()
        {
            //Arrange
            Venue testVenue = new Venue("Club Fibur");
            testVenue.Save();

            //Act
            string newName = "Club Fiber";
            testVenue.Update(newName);

            //Assert
            string actualResult = testVenue.GetName();
            string expectedResult = newName;

            Assert.Equal(expectedResult, actualResult);            
        }

        //Delete everything between tests
        public void Dispose()
        {
            Venue.DeleteAll();
        }
    }
}
