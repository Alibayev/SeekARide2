using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeekARide.Models
{
    public interface IMatchAdapter
    {
        LinkedList<MatchedTrip> getMatchedTrips(Trip newTrip);
    }
}