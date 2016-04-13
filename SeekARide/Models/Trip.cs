using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeekARide.Models {
	public class Trip {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TripId { get; set; }
		public DateTime TravelDateTime { get; set; }
		public virtual Location From { get; set; }
		public virtual Location To { get; set; }
		public TripType Type { get; set; }

	}
}