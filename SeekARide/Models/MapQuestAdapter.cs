using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SeekARide.Models
{
    public class MapQuestAdapter : IMatchAdapter
    {
        LinkedList<Trip> databaseMatchedtrips;

        public MapQuestAdapter(LinkedList<Trip> trips)
        {
            this.databaseMatchedtrips = trips;
        }

        public LinkedList<MatchedTrip> getMatchedTrips(Trip newTrip)
        {
            string fromAddress = newTrip.From.StreetAddress + ", " + newTrip.From.City + ", " + newTrip.From.State + ", " + newTrip.From.ZipCode;
            // string toAddress = newTrip.To.StreetAddress + ", " + newTrip.To.City + ", " + newTrip.To.State + ", " + newTrip.To.ZipCode;


            LinkedList<MatchedTrip> mapMatchedTrips = new LinkedList<MatchedTrip>();
            foreach (Trip trip in databaseMatchedtrips)
            {
                string fromAddress2 = trip.From.StreetAddress + ", " + trip.From.City + ", " + trip.From.State + ", " + trip.From.ZipCode;
                //string to = trip.To.StreetAddress + ", " + trip.To.City + ", " + trip.To.State + ", " + trip.To.ZipCode;
                DateTime departime = trip.TravelDateTime;
                int timeSeconds = (int)(departime - new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
                MatchedTrip mapMatchedTrip = new MatchedTrip(trip.From, trip.To, trip.TripInformation, departime);
                mapMatchedTrip.distanceToCreator = getTime(fromAddress, fromAddress2, timeSeconds);
                if (mapMatchedTrip.distanceToCreator < 5000)
                    mapMatchedTrips.AddFirst(mapMatchedTrip);

            }

            return mapMatchedTrips;
        }

        private static int getTime(string origin, string destination, int time)
        {
            int current = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            if (current > time)
            {
                return -1;
                //return;
            }

            // Turn unix timestamp to formatted date and time
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(time).ToLocalTime();
            string date = dtDateTime.ToString("MM/dd/yyyy");
            string timeStr = dtDateTime.ToString("HH:mm");

            string url = @"http://www.mapquestapi.com/directions/v2/route?key=pdsGCXKpbyTxjkjL8i3Q9eQWP4bJUPRI&ambiguities=ignore&avoidTimedConditions=false&doReverseGeocode=true&outFormat=json&routeType=fastest&timeType=2&dateType=0&date="
             + date + "&localTime=" + timeStr + "&enhancedNarrative=false&locale=en_US&unit=k&from=" +
            origin + "&to=" + destination + "&drivingStyle=2&highwayEfficiency=21.0";

            var client = new WebClient();
            var result = client.DownloadData(url);

            var json = Encoding.UTF8.GetString(result);
            dynamic dynObj = JsonConvert.DeserializeObject(json);
            var res = dynObj.route;
            int distance = res.distance * 1000;
            return distance;
        }
    }
}