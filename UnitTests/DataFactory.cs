using System;
using System.Collections.Generic;
using System.Linq;
using RecursiveObjectComparerTool.Models;

namespace UnitTests
{
    public static class DataFactory
    {
        private static readonly Random Rand = new Random();

        public static ContactList GetContactList(int size)
        {
            var cl = new ContactList { Contacts = GetPeople(size) };

            return cl;
        }

        public static List<Person> GetPeople(int number)
        {
            if (number < 1) number = 1;
            if (number > 10) number = 10;

            var peeps = People.Take(number).ToList();
            foreach (var peep in peeps)
            {
                peep.Addresses = GetAddresses(Rand.Next(minValue: 1, maxValue: 3));
                peep.ContactMethods = GetContactInfo(Rand.Next(minValue: 1, maxValue: 5));
            }
            return peeps;
        }

        public static List<Address> GetAddresses(int number)
        {
            if (number < 1) number = 1;

            return Enumerable.Range(1, number)
                .Select(i => Places[Rand.Next(0, Places.Count)])
                .Select(place => new Address
                {
                    AddressLine1 = $"{Rand.Next()} {Nouns.RandomNoun} {_streetTypes[Rand.Next(0, _streetTypes.Count)]}",
                    AddressLine2 = "",
                    Country = "USA",
                    City = place.City,
                    PostCode = Rand.Next(10000, 99999).ToString(),
                    State = place.State
                })
                .ToList();
        }

        public static List<ContactMethod> GetContactInfo(int number)
        {
            if (number < 1) number = 1;

            var _return = new List<ContactMethod>();
            foreach (var i in Enumerable.Range(1, number))
            {
                _return.Add(new ContactMethod
                {
                    Info = $"{Rand.Next()}{Nouns.RandomNoun}",
                    Method = (ContactMethods)Rand.Next(0, 7)
                });
            }

            return _return;
        }

        private static readonly List<Person> People = new List<Person>
        {
            new Person{FirstName = "Mae", LastName = "Jemison"},
            new Person{FirstName = "Annie", LastName = "Easley"},
            new Person{FirstName = "Katherine", LastName = "Johnson"},
            new Person{FirstName = "Grace", LastName = "Hopper"},
            new Person{FirstName = "Chrisanthi", LastName = "Avgerou"},
            new Person{FirstName = "Ada", LastName = "Lovelace"},
            new Person{FirstName = "Maryam", LastName = "Mirzakhani"},
            new Person{FirstName = "Hedy", LastName = "Lamaar"},
            new Person{FirstName = "Shirley Ann", LastName = "Jackson"},
            new Person{FirstName = "Jane", LastName = "Goodall"}
        };

        private static readonly List<CityState> Places = new List<CityState>
        {
            new CityState {City = "Los Angeles", State = "California"},
            new CityState {City = "Chicago", State = "Illinois"},
            new CityState {City = "Houston", State = "Texas"},
            new CityState {City = "Phoenix", State = "Arizona"},
            new CityState {City = "Philadelphia", State = "Pennsylvania"},
            new CityState {City = "San Antonio", State = "Texas"},
            new CityState {City = "San Diego", State = "California"},
            new CityState {City = "Dallas", State = "Texas"},
            new CityState {City = "San Jose", State = "California"},
            new CityState {City = "Austin", State = "Texas"},
            new CityState {City = "Jacksonville", State = "Florida"},
            new CityState {City = "San Francisco", State = "California"},
            new CityState {City = "Columbus", State = "Ohio"},
            new CityState {City = "Indianapolis", State = "Indiana"},
            new CityState {City = "Fort Worth", State = "Texas"},
            new CityState {City = "Charlotte", State = "North Carolina"},
            new CityState {City = "Seattle", State = "Washington"},
            new CityState {City = "Denver", State = "Colorado"},
            new CityState {City = "El Paso", State = "Texas"},
            new CityState {City = "Washington", State = "District of Columbia"},
            new CityState {City = "Boston", State = "Massachusetts"},
            new CityState {City = "Detroit", State = "Michigan"},
            new CityState {City = "Nashville", State = "Tennessee"},
            new CityState {City = "Memphis", State = "Tennessee"},
            new CityState {City = "Portland", State = "Oregon"},
            new CityState {City = "Oklahoma City", State = "Oklahoma"},
            new CityState {City = "Las Vegas", State = "Nevada"},
            new CityState {City = "Louisville", State = "Kentucky"},
            new CityState {City = "Baltimore", State = "Maryland"},
            new CityState {City = "Milwaukee", State = "Wisconsin"},
            new CityState {City = "Albuquerque", State = "New Mexico"},
            new CityState {City = "Tucson", State = "Arizona"},
            new CityState {City = "Fresno", State = "California"},
            new CityState {City = "Sacramento", State = "California"},
            new CityState {City = "Mesa", State = "Arizona"},
            new CityState {City = "Kansas City", State = "Missouri"},
            new CityState {City = "Atlanta", State = "Georgia"},
            new CityState {City = "Long Beach", State = "California"},
            new CityState {City = "Colorado Springs", State = "Colorado"},
            new CityState {City = "Raleigh", State = "North Carolina"},
            new CityState {City = "Miami", State = "Florida"},
            new CityState {City = "Virginia Beach", State = "Virginia"},
            new CityState {City = "Omaha", State = "Nebraska"},
            new CityState {City = "Oakland", State = "California"},
            new CityState {City = "Minneapolis", State = "Minnesota"},
            new CityState {City = "Tulsa", State = "Oklahoma"},
            new CityState {City = "Arlington", State = "Texas"},
            new CityState {City = "New Orleans", State = "Louisiana"},
            new CityState {City = "Wichita", State = "Kansas"},
            new CityState {City = "Cleveland", State = "Ohio"},
            new CityState {City = "Tampa", State = "Florida"},
            new CityState {City = "Bakersfield", State = "California"},
            new CityState {City = "Aurora", State = "Colorado"},
            new CityState {City = "Honolulu", State = "Hawaii"},
            new CityState {City = "Anaheim", State = "California"},
            new CityState {City = "Santa Ana", State = "California"},
            new CityState {City = "Corpus Christi", State = "Texas"},
            new CityState {City = "Riverside", State = "California"},
            new CityState {City = "Lexington", State = "Kentucky"},
            new CityState {City = "St. Louis", State = "Missouri"},
            new CityState {City = "Stockton", State = "California"},
            new CityState {City = "Pittsburgh", State = "Pennsylvania"},
            new CityState {City = "Saint Paul", State = "Minnesota"},
            new CityState {City = "Cincinnati", State = "Ohio"},
            new CityState {City = "Anchorage", State = "Alaska"},
            new CityState {City = "Henderson", State = "Nevada"},
            new CityState {City = "Greensboro", State = "North Carolina"},
            new CityState {City = "Plano", State = "Texas"},
            new CityState {City = "New CityStateark", State = "New Jersey"},
            new CityState {City = "Lincoln", State = "Nebraska"},
            new CityState {City = "Toledo", State = "Ohio"},
            new CityState {City = "Orlando", State = "Florida"},
            new CityState {City = "Chula Vista", State = "California"},
            new CityState {City = "Irvine", State = "California"},
            new CityState {City = "Fort Wayne", State = "Indiana"},
            new CityState {City = "Jersey City", State = "New Jersey"},
            new CityState {City = "Durham", State = "North Carolina"},
            new CityState {City = "St. Petersburg", State = "Florida"},
            new CityState {City = "Laredo", State = "Texas"},
            new CityState {City = "Buffalo", State = "New York"},
            new CityState {City = "Madison", State = "Wisconsin"},
            new CityState {City = "Lubbock", State = "Texas"},
            new CityState {City = "Chandler", State = "Arizona"},
            new CityState {City = "Scottsdale", State = "Arizona"},
            new CityState {City = "Glendale", State = "Arizona"},
            new CityState {City = "Reno", State = "Nevada"},
            new CityState {City = "Norfolk", State = "Virginia"},
            new CityState {City = "Winston–Salem", State = "North Carolina"},
            new CityState {City = "North Las Vegas", State = "Nevada"},
            new CityState {City = "Irving", State = "Texas"},
            new CityState {City = "Chesapeake", State = "Virginia"},
            new CityState {City = "Gilbert", State = "Arizona"},
            new CityState {City = "Hialeah", State = "Florida"},
            new CityState {City = "Garland", State = "Texas"},
            new CityState {City = "Fremont", State = "California"},
            new CityState {City = "Baton Rouge", State = "Louisiana"},
            new CityState {City = "Richmond", State = "Virginia"},
            new CityState {City = "Boise", State = "Idaho"},
            new CityState {City = "San Bernardino", State = "California"},
            new CityState {City = "Spokane", State = "Washington"},
            new CityState {City = "Des Moines", State = "Iowa"},
            new CityState {City = "Modesto", State = "California"},
            new CityState {City = "Birmingham", State = "Alabama"},
            new CityState {City = "Tacoma", State = "Washington"},
            new CityState {City = "Fontana", State = "California"},
            new CityState {City = "Rochester", State = "New York"},
            new CityState {City = "Oxnard", State = "California"},
            new CityState {City = "Moreno Valley", State = "California"},
            new CityState {City = "Fayetteville", State = "North Carolina"},
            new CityState {City = "Aurora", State = "Illinois"},
            new CityState {City = "Glendale", State = "California"},
            new CityState {City = "Yonkers", State = "New York"},
            new CityState {City = "Huntington Beach", State = "California"},
            new CityState {City = "Montgomery", State = "Alabama"},
            new CityState {City = "Amarillo", State = "Texas"},
            new CityState {City = "Little Rock", State = "Arkansas"},
            new CityState {City = "Akron", State = "Ohio"},
            new CityState {City = "Columbus", State = "Georgia"},
            new CityState {City = "Augusta", State = "Georgia"},
            new CityState {City = "Grand Rapids", State = "Michigan"},
            new CityState {City = "Shreveport", State = "Louisiana"},
            new CityState {City = "Salt Lake City", State = "Utah"},
            new CityState {City = "Huntsville", State = "Alabama"},
            new CityState {City = "Mobile", State = "Alabama"},
            new CityState {City = "Tallahassee", State = "Florida"},
            new CityState {City = "Grand Prairie", State = "Texas"},
            new CityState {City = "Overland Park", State = "Kansas"},
            new CityState {City = "Knoxville", State = "Tennessee"},
            new CityState {City = "Port St. Lucie", State = "Florida"},
            new CityState {City = "Worcester", State = "Massachusetts"},
            new CityState {City = "Brownsville", State = "Texas"},
            new CityState {City = "Tempe", State = "Arizona"},
            new CityState {City = "Santa Clarita", State = "California"},
            new CityState {City = "New CityStateport new CityStates", State = "Virginia"},
            new CityState {City = "Cape Coral", State = "Florida"},
            new CityState {City = "Providence", State = "Rhode Island"},
            new CityState {City = "Fort Lauderdale", State = "Florida"},
            new CityState {City = "Chattanooga", State = "Tennessee"},
            new CityState {City = "Rancho Cucamonga", State = "California"},
            new CityState {City = "Oceanside", State = "California"},
            new CityState {City = "Santa Rosa", State = "California"},
            new CityState {City = "Garden Grove", State = "California"},
            new CityState {City = "Vancouver", State = "Washington"},
            new CityState {City = "Sioux Falls", State = "South Dakota"},
            new CityState {City = "Ontario", State = "California"},
            new CityState {City = "McKinney", State = "Texas"},
            new CityState {City = "Elk Grove", State = "California"},
            new CityState {City = "Jackson", State = "Mississippi"},
            new CityState {City = "Pembroke Pines", State = "Florida"},
            new CityState {City = "Salem", State = "Oregon"},
            new CityState {City = "Springfield", State = "Missouri"},
            new CityState {City = "Corona", State = "California"},
            new CityState {City = "Eugene", State = "Oregon"},
            new CityState {City = "Fort Collins", State = "Colorado"},
            new CityState {City = "Peoria", State = "Arizona"},
            new CityState {City = "Frisco", State = "Texas"},
            new CityState {City = "Cary", State = "North Carolina"},
            new CityState {City = "Lancaster", State = "California"},
            new CityState {City = "Hayward", State = "California"},
            new CityState {City = "Palmdale", State = "California"},
            new CityState {City = "Salinas", State = "California"},
            new CityState {City = "Alexandria", State = "Virginia"},
            new CityState {City = "Lakewood", State = "Colorado"},
            new CityState {City = "Springfield", State = "Massachusetts"},
            new CityState {City = "Pasadena", State = "Texas"},
            new CityState {City = "Sunnyvale", State = "California"},
            new CityState {City = "Macon", State = "Georgia"},
            new CityState {City = "Pomona", State = "California"},
            new CityState {City = "Hollywood", State = "Florida"},
            new CityState {City = "Kansas City", State = "Kansas"},
            new CityState {City = "Escondido", State = "California"},
            new CityState {City = "Clarksville", State = "Tennessee"},
            new CityState {City = "Joliet", State = "Illinois"},
            new CityState {City = "Rockford", State = "Illinois"},
            new CityState {City = "Torrance", State = "California"},
            new CityState {City = "Naperville", State = "Illinois"},
            new CityState {City = "Paterson", State = "New Jersey"},
            new CityState {City = "Savannah", State = "Georgia"},
            new CityState {City = "Bridgeport", State = "Connecticut"},
            new CityState {City = "Mesquite", State = "Texas"},
            new CityState {City = "Killeen", State = "Texas"},
            new CityState {City = "Syracuse", State = "New York"},
            new CityState {City = "McAllen", State = "Texas"},
            new CityState {City = "Pasadena", State = "California"},
            new CityState {City = "Bellevue", State = "Washington"},
            new CityState {City = "Fullerton", State = "California"},
            new CityState {City = "Orange", State = "California"},
            new CityState {City = "Dayton", State = "Ohio"},
            new CityState {City = "Miramar", State = "Florida"},
            new CityState {City = "Thornton", State = "Colorado"},
            new CityState {City = "West Valley City", State = "Utah"},
            new CityState {City = "Olathe", State = "Kansas"},
            new CityState {City = "Hampton", State = "Virginia"},
            new CityState {City = "Warren", State = "Michigan"},
            new CityState {City = "Midland", State = "Texas"},
            new CityState {City = "Waco", State = "Texas"},
            new CityState {City = "Charleston", State = "South Carolina"},
            new CityState {City = "Columbia", State = "South Carolina"},
            new CityState {City = "Denton", State = "Texas"},
            new CityState {City = "Carrollton", State = "Texas"},
            new CityState {City = "Surprise", State = "Arizona"},
            new CityState {City = "Roseville", State = "California"},
            new CityState {City = "Sterling Heights", State = "Michigan"},
            new CityState {City = "Murfreesboro", State = "Tennessee"},
            new CityState {City = "Gainesville", State = "Florida"},
            new CityState {City = "Cedar Rapids", State = "Iowa"},
            new CityState {City = "Visalia", State = "California"},
            new CityState {City = "Coral Springs", State = "Florida"},
            new CityState {City = "New Haven", State = "Connecticut"},
            new CityState {City = "Stamford", State = "Connecticut"},
            new CityState {City = "Thousand Oaks", State = "California"},
            new CityState {City = "Concord", State = "California"},
            new CityState {City = "Elizabeth", State = "New Jersey"},
            new CityState {City = "Lafayette", State = "Louisiana"},
            new CityState {City = "Kent", State = "Washington"},
            new CityState {City = "Topeka", State = "Kansas"},
            new CityState {City = "Simi Valley", State = "California"},
            new CityState {City = "Santa Clara", State = "California"},
            new CityState {City = "Athens", State = "Georgia"},
            new CityState {City = "Hartford", State = "Connecticut"},
            new CityState {City = "Victorville", State = "California"},
            new CityState {City = "Abilene", State = "Texas"},
            new CityState {City = "Norman", State = "Oklahoma"},
            new CityState {City = "Vallejo", State = "California"},
            new CityState {City = "Berkeley", State = "California"},
            new CityState {City = "Round Rock", State = "Texas"},
            new CityState {City = "Ann Arbor", State = "Michigan"},
            new CityState {City = "Fargo", State = "North Dakota"},
            new CityState {City = "Columbia", State = "Missouri"},
            new CityState {City = "Allentown", State = "Pennsylvania"},
            new CityState {City = "Evansville", State = "Indiana"},
            new CityState {City = "Beaumont", State = "Texas"},
            new CityState {City = "Odessa", State = "Texas"},
            new CityState {City = "Wilmington", State = "North Carolina"},
            new CityState {City = "Arvada", State = "Colorado"},
            new CityState {City = "Independence", State = "Missouri"},
            new CityState {City = "Provo", State = "Utah"},
            new CityState {City = "Lansing", State = "Michigan"},
            new CityState {City = "El Monte", State = "California"},
            new CityState {City = "Springfield", State = "Illinois"},
            new CityState {City = "Fairfield", State = "California"},
            new CityState {City = "Clearwater", State = "Florida"},
            new CityState {City = "Peoria", State = "Illinois"},
            new CityState {City = "Rochester", State = "Minnesota"},
            new CityState {City = "Carlsbad", State = "California"},
            new CityState {City = "Westminster", State = "Colorado"},
            new CityState {City = "West Jordan", State = "Utah"},
            new CityState {City = "Pearland", State = "Texas"},
            new CityState {City = "Richardson", State = "Texas"},
            new CityState {City = "Downey", State = "California"},
            new CityState {City = "Miami Gardens", State = "Florida"},
            new CityState {City = "Temecula", State = "California"},
            new CityState {City = "Costa Mesa", State = "California"},
            new CityState {City = "College Station", State = "Texas"},
            new CityState {City = "Elgin", State = "Illinois"},
            new CityState {City = "Murrieta", State = "California"},
            new CityState {City = "Gresham", State = "Oregon"},
            new CityState {City = "High Point", State = "North Carolina"},
            new CityState {City = "Antioch", State = "California"},
            new CityState {City = "Inglewood", State = "California"},
            new CityState {City = "Cambridge", State = "Massachusetts"},
            new CityState {City = "Lowell", State = "Massachusetts"},
            new CityState {City = "Manchester", State = "New Hampshire"},
            new CityState {City = "Billings", State = "Montana"},
            new CityState {City = "Pueblo", State = "Colorado"},
            new CityState {City = "Palm Bay", State = "Florida"},
            new CityState {City = "Centennial", State = "Colorado"},
            new CityState {City = "Richmond", State = "California"},
            new CityState {City = "Ventura", State = "California"},
            new CityState {City = "Pompano Beach", State = "Florida"},
            new CityState {City = "North Charleston", State = "South Carolina"},
            new CityState {City = "Everett", State = "Washington"},
            new CityState {City = "Waterbury", State = "Connecticut"},
            new CityState {City = "West Palm Beach", State = "Florida"},
            new CityState {City = "Boulder", State = "Colorado"},
            new CityState {City = "West Covina", State = "California"},
            new CityState {City = "Broken Arrow", State = "Oklahoma"},
            new CityState {City = "Clovis", State = "California"},
            new CityState {City = "Daly City", State = "California"},
            new CityState {City = "Lakeland", State = "Florida"},
            new CityState {City = "Santa Maria", State = "California"},
            new CityState {City = "Norwalk", State = "California"},
            new CityState {City = "Sandy Springs", State = "Georgia"},
            new CityState {City = "Hillsboro", State = "Oregon"},
            new CityState {City = "Green Bay", State = "Wisconsin"},
            new CityState {City = "Tyler", State = "Texas"},
            new CityState {City = "Wichita Falls", State = "Texas"},
            new CityState {City = "Lewisville", State = "Texas"},
            new CityState {City = "Burbank", State = "California"},
            new CityState {City = "Greeley", State = "Colorado"},
            new CityState {City = "San Mateo", State = "California"},
            new CityState {City = "El Cajon", State = "California"},
            new CityState {City = "Jurupa Valley", State = "California"},
            new CityState {City = "Rialto", State = "California"},
            new CityState {City = "Davenport", State = "Iowa"},
            new CityState {City = "League City", State = "Texas"},
            new CityState {City = "Edison", State = "New Jersey"},
            new CityState {City = "Davie", State = "Florida"},
            new CityState {City = "Las Cruces", State = "New Mexico"},
            new CityState {City = "South Bend", State = "Indiana"},
            new CityState {City = "Vista", State = "California"},
            new CityState {City = "Woodbridge", State = "New Jersey"},
            new CityState {City = "Renton", State = "Washington"},
            new CityState {City = "Lakewood", State = "New Jersey"},
            new CityState {City = "San Angelo", State = "Texas"},
            new CityState {City = "Clinton", State = "Michigan"}
        };

        private static readonly List<string> _streetTypes = new List<string>
        {
            "Alley",
            "Avenue",
            "Boulevard",
            "Crescent",
            "Court",
            "Drive",
            "Highway",
            "Lane",
            "Place",
            "Road",
            "Route",
            "Street",
            "Woonerf",
            "Way",
            "Parkway",
            "Turnpike"
        };

        private class CityState
        {
            public string City { get; set; }
            public string State { get; set; }
        }
    }
}
