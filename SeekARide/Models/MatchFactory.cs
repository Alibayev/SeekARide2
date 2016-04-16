using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeekARide.DataAccess;
namespace SeekARide.Models
{
    public class MatchFactory : IAbstractFactory
    {
        private static MatchFactory factory = new MatchFactory();

        public MatchFactory() { }

        public static MatchFactory getInstance() { return factory; }

        public IMatchAdapter getMatchAdapter(DateTime departureTime)
        {
            LinkedList<Trip> driverTrips = readDb(departureTime);
            IMatchAdapter adapter = new AdapterProxy(driverTrips);

            return adapter;
        }

        private static LinkedList<Trip> readDb(DateTime departureTime)
        {
            LinkedList<Trip> list = new LinkedList<Trip>();
            CarpoolContext db = new CarpoolContext();
            var trips = from trip in db.Trips
                        where trip.TravelDateTime.AddHours(1)> departureTime
                        && departureTime > trip.TravelDateTime 
                        && trip.TripInformation.Capacity<4
                        select trip; 
            foreach (var a in trips)
            {
                Location from = new Location(a.From.StreetAddress, a.From.City, a.From.State, a.From.ZipCode);
                Location to = new Location(a.To.StreetAddress, a.To.City, a.To.State, a.To.ZipCode);
                DateTime time = a.TravelDateTime;
                Trip trip = new Trip(from, to, time,a.Type,a.TripInformation);
                list.AddFirst(trip);

            }
            return list;



            // string[] lines = System.IO.File.ReadAllLines(@"C:\Users\sgpy\Documents\GitHub\carpool-master\CarPoolDemo\db.txt");

            //  foreach (string line in lines)
            // {
            //      string[] item = line.Split('\t');
            //      Trip trip = new Trip(item[0].Trim(), item[1].Trim(), item[2].Trim(), item[3].Trim(), item[4].Trim(), item[5].Trim());
            //      list.AddFirst(trip);
            //  }
            // return list;
        }

    }
}