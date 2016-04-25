using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using SeekARide.DataAccess;

namespace SeekARide.Models
{
    public class GoogleAdapter : IMatchAdapter
    {
        LinkedList<Trip> databaseMatchedtrips;

        public GoogleAdapter(LinkedList<Trip> trips)
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
               int timeSeconds=(int) (departime- new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
                MatchedTrip mapMatchedTrip = new MatchedTrip(trip.From, trip.To, trip.TripInformation, departime);
                mapMatchedTrip.distanceToCreator = Math.Round(getTime(fromAddress, fromAddress2, timeSeconds)/1610.0,2);
                mapMatchedTrip.toAddress = trip.To;
                if (mapMatchedTrip.distanceToCreator<500)
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

            string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + origin +
              "&destination=" + destination + "&departure_time=" + time + "&key=AIzaSyBO9khwJBKM4II1pxZT89ItprSLiYj9eho";
            var client = new WebClient();
            var result = client.DownloadData(url);
            //Console.Write(result);
            string result2 = System.Text.Encoding.UTF8.GetString(result);
           // System.IO.File.WriteAllText(@"D:\path.txt", result2);
            var json = Encoding.UTF8.GetString(result);
            dynamic dynObj = JsonConvert.DeserializeObject(json);
            var res = dynObj.routes[0].legs[0];
            //string s = "Distance: " + res.distance.value + "             Duration: " + res.duration.value + "             Duration in traffic: " + res.duration_in_traffic.value;
           // int trafficTime = res.duration_in_traffic.value;
            //  int durationTime = res.duration.value;
            int distance = res.distance.value;
            Console.WriteLine(distance);
            System.IO.File.WriteAllText(@"D:\path.txt", distance+"");
            return distance;
        }

        /* private static string GetMap(string origin, string destination, string time)
         {
             DateTime myTime = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm",
             System.Globalization.CultureInfo.InvariantCulture).AddHours(6);
             TimeSpan span = (myTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
             int timestamp = (int)span.TotalSeconds;
             int current = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
             if (current > timestamp)
             {
                 return "this is past time. plz use future time";
                 //return;
             }

             string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + origin +
                 "&destination=" + destination + "&departure_time=" + timestamp + "&key=AIzaSyBO9khwJBKM4II1pxZT89ItprSLiYj9eho";
             var client = new WebClient();
             var result = client.DownloadData(url);

             var json = Encoding.UTF8.GetString(result);
             dynamic dynObj = JsonConvert.DeserializeObject(json);
             var res = dynObj.routes[0].legs[0];
             string s = "Distance: " + res.distance.text + "             Duration: " + res.duration.text + "             Duration in traffic: " + res.duration_in_traffic.text;
             return s;
         }*/


    }
}