# HolidaySearchExercise
Taking the two JSON files of flights and hotels as source data provide a basic holiday search feature. The first search result should be the best value holiday we can provide, based on the customers requirements.  

**Example:**    

Departing from: Manchester Airport (MAN)  
Traveling to: Malaga Airport (AGP)  
Departure Date: 2023/07/01  
Duration: 7 nights  

Expected result:  
Flight Id 2 and Hotel Id 9  
  
  
**Requirements**    
1. Source file in JSON for flight data:  
SAMPLE FLIGHT OBJECT  
{  
  "id": 1,  
  "airline": "First Class Air",  
  "from": "MAN",  
  "to": "TFS",  
  "price": 470,  
  "departure_date": "2023-07-01"  
}  
  
2. Source file in JSON for hotel data:   
SAMPLE HOTEL OBJECT  
{  
  "id": 1,  
  "name": "Iberostar Grand Portals Nous",  
  "arrival_date": "2022-11-05",  
  "price_per_night": 100,  
  "local_airports": ["TFS"],  
  "nights": 7  
}  
  
The JSONParser class takes the filepath for FlightData.json AND HotelData.json and deserializes each to return a list of Flight AND Hotel objects
  
**To use the SearchHoliday class:**  
1. Instantiate a new SearchHoliday with 4 required parameters:  
  a. string departingFrom (using an option from Airport enum)  
  b. string travellingTo (using an option from Airport enum)  
  c. string departureDate (YY-MM-DD)  
  d. int duration (in number of days)  
    
**Example:**  new SearchHoliday(Airports.MAN.ToString(), Airports.AGP.ToString(), "2023-07-01", 7)  

SearchHolidays.GetBestValueHoliday() returns a Tuple<Flight, Hotel>  
If there are multiple matches, the objects having lowest price is returned in the tuple.  
  


