using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SeekARide.Models
{
    public class AdapterProxy : IMatchAdapter
    {
        LinkedList<Trip> driverTrips;

        public AdapterProxy(LinkedList<Trip> driverTrips)
        {
            this.driverTrips = driverTrips;
        }

        public LinkedList<MatchedTrip> getMatchedTrips(Trip newTrip)
        {
            IMatchAdapter adapter;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://map.google.com");
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                adapter = new GoogleAdapter(driverTrips);
            } catch (WebException e)
            {
                adapter = new MapQuestAdapter(driverTrips);
            }
            return adapter.getMatchedTrips(newTrip);
        }
    }
}