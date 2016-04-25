using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeekARide.Models
{
    public class Trip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TripId { get; set; }
        public DateTime TravelDateTime { get; set; }
        public virtual Location From { get; set; }
        public virtual Location To { get; set; }
        public TripType Type { get; set; }
        public virtual TripInformation TripInformation { get; set; }

        public Trip(Location From, Location To, DateTime TravelDateTime, TripType type, TripInformation tripInfo)
        {
            this.From = From;
            this.To = To;
            this.TravelDateTime = TravelDateTime;
            this.Type = type;
            this.TripInformation = tripInfo;
        }

        public Trip(Location From, Location To, DateTime TravelDateTime)
        {
            this.From = From;
            this.To = To;
            this.TravelDateTime = TravelDateTime;
        }

		public string GetTripType() {
			if (Type == TripType.LookingForPassengers) {
				return "Looking for Passengers";
			}

			return "Looking for Driver";
		}
		public Trip() {

        }

    }
}