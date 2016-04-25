using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SeekARide.Models
{
    public class AdapterProxy : IMatchAdapter
    {
        LinkedList<Trip> datbaseMatchedTrips;

        public AdapterProxy(LinkedList<Trip> datbaseMatchedTrips)
        {
            this.datbaseMatchedTrips = datbaseMatchedTrips;
        }

        public LinkedList<MatchedTrip> getMatchedTrips(Trip newTrip)
        {
            IMatchAdapter adapter;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://map.google.com");
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                adapter = new GoogleAdapter(datbaseMatchedTrips);
            } catch (WebException e)
            {
                adapter = new MapQuestAdapter(datbaseMatchedTrips);
            }
            return adapter.getMatchedTrips(newTrip);
        }
    }
}