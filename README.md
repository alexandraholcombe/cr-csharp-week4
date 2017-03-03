# Band Tracker Application

#### _Track bands and the venues at which they've played_

#### By _**Alexandra Holcombe**_

## Description

User can create bands and venues, then list which bands have played at venues, or which venues a band has played at.  

***

## Setup/Installation Requirements

#### Create Databases
* In `SQLCMD`:  
        `> CREATE DATABASE band_tracker`  
        `> GO`  
        `> USE band_tracker`  
        `> GO`  
        `> CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));`  
        `> CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255));`  
        `> CREATE TABLE band_venues (id INT IDENTITY(1,1), band_id INT, venue_id INT);`  
        `> GO`  

* Requires DNU, DNX, MSSQL, and Mono
* Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

***

## Specifications

### Band Class
================  

**The DeleteAll method for the Band class will delete all rows from the bands table.**
* Example Input: none
* Example Output: nothing

**The GetAll method for the Band class will return an empty list if there are no entries in the Band table.**
* Example Input: N/A, automatically loads on home page
* Example Output: empty list

**The Equals method for the Band class will return true if the Band in local memory matches the Band pulled from the database.**
* Example Input:  
        > Local: "Pajama Funnel", id is 10  
        > Database: "Pajama Funnel", id is 10  
* Example Output: `true`

**The Save method for the Band class will save new Bands to the database.**
* Example Input:  
\> New band: "Pajama Funnel"
* Example Output: no return value

**The Save method for the Band class will assign an id to each new instance of the Band class.**
* Example Input:  
\> New band: "Pajama Funnel", `local id: 0`  
* Example Output:  
\> "Pajama Funnel", `database-assigned id`  

**The GetAll method for the Band class will return all band entries in the database in the form of a list.**
* Example Input:  
        > "Pajama Funnel", id is 10  
        > "Allergy of Warm", id is 11  
* Example Output: `{Pajama Funnel object}, {Allergy of Warm object}`

**The Find method for the Band class will return the Band as defined in the database.**
* Example Input: "Pajama Funnel"
* Example Output: "Pajama Funnel", `database-assigned id`

### Venue class
================

**The DeleteAll method for the Venue class will delete all rows from the clients table.**
* Example Input: none
* Example Output: nothing

**The GetAll method for the Venue class will return an empty list if there are no entries in the Venue table.**
* Example Input: N/A, automatically loads on home page
* Example Output: empty list

**The Equals method for the Venue class will return true if the Venue in local memory matches the Venue pulled from the database.**
* Example Input:  
        > Local: "The Station", id is 10  
        > Database: "The Station", id is 10  
* Example Output: `true`

**The Save method for the Venue class will save new Venues to the database.**
* Example Input:  
\> New client: "The Station"
* Example Output: no return value

**The Save method for the Venue class will assign an id to each new instance of the Venue class.**
* Example Input:  
\> New band: "The Station",`local id: 0`  
* Example Output:  
\> "The Station", `database-assigned id`  

**The GetAll method for the Venue class will return all venue entries in the database in the form of a list.**
* Example Input:  
        > "The Station", id is 10  
        > "Club Fiber", id is 11  
* Example Output: `{The Station object}, {Club Fiber object}`

**The Find method for the Venue class will return the Venue as defined in the database.**
* Example Input: "The Station"
* Example Output: "The Station", `database-assigned id`

**The Update method for the Venue class will return the Venue with the new name.**
* Example Input: "Club Fibur", id is 10
* Example Output: "Club Fiber", id is 10

**The Delete method for the Venue class will return a list of Venues without the deleted Venue.**
* Example Input: "Club Fiber"
* Example Output: "The Station, H20, The Answer"


### Band && Venue Classes
=========================  

**The GetBands method for the Venue class will return a list of all rows in bands_venues with the given venue_id.**
* Example Input: "The Station"
* Example Output: `{List of bands that have played at The Station}`

**The GetVenues method for the Band class will return a list of all rows in bands_venues with the given band_id.**
* Example Input: "Pajama Funnel"
* Example Output: `{List of venues at which Pajama Funnel has played}`

### User Interface
===================  

* A user can add a band.
* A user can add a venue.
* A user can view a band's page, which will show a list of the venues at which the band has played.
* On the band's page, the user can add a venue at which a band has played.
* A user can view a venue's page, which will show a list of bands that have played at that venue.
* On the venue's page, a user can add a band that has played at the venue.
* On the venue's page, a user can update the name of the venue.
* On the venue's page, a user can delete a venue.

***

## Support and contact details

Please contact Allie Holcombe at alexandra.holcombe@gmail.com with any questions, concerns, or suggestions.

***

## Technologies Used

This web application uses:
* Nancy
* Mono
* DNVM
* C#
* Razor
* MSSQL & SSMS
* All band names generated at [BandNameMaker.com](http://www.bandnamemaker.com/)
* All venue names generated at [Nightclub Name Generator](http://fantasynamegenerators.com/nightclub-names.php)

***

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Alexandra Holcombe_**
