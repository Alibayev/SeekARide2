using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SeekARide.Models
{
    public class MatchedTrip
    {

        public virtual TripInformation TripInformation { get; set; }
        public Location fromAddress { get; set; }
        public Location toAddress { get; set; }
        public DateTime departureTime { get; set; }
     //   public string departureStringTime { get; set; }
      //  public string pickupTime { get; set; }
      //  public int distance { get; set; }
       // public int durationTime { get; set; }
       // public int trafficTime { get; set; }
        //public int timeDifference { get; set; }
        public int distanceToCreator { get; set; }
        public MatchedTrip(Location fromAddress, Location toAddress, TripInformation tripInfo, DateTime departureTime)
        {
            this.fromAddress = fromAddress;
            this.toAddress = toAddress;
            this.TripInformation = tripInfo;
            this.departureTime = departureTime;
        }
      


        public MatchedTrip()
        {

        }
    }
}