using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeekARide.Models {
	public class NewPostingViewModel {
		[Required]
		[Display(Name = "Date of Travel")]
		public DateTime DateTime { get; set; }
		[Display(Name = "Time of Travel")]
		public DateTime Time { get; set; }

		[Display(Name = "Type of the Trip")]
		public TripType TripType { get; set; }

		[Required]
		[Display(Name = "Street Address of Origin")]
		public string StreetAddressOrigin { get; set; }

		[Required]
		[Display(Name = "City of Origin")]
		public string CityOrigin { get; set; }

		[Required]
		[Display(Name = "State of Origin")]
		public string StateOrigin { get; set; }
		[Required]
		[Display(Name = "Zip code of Origin")]
		public string ZipOrigin { get; set; }
		[Display(Name = "Add to Address Book?")]
		public bool AddOriginToAddressBook { get; set; }
		[Required]
		[Display(Name = "Street Address of Destination")]
		public string StreetAddressDestination { get; set; }

		[Required]
		[Display(Name = "City of Destination")]
		public string CityDestination { get; set; }

		[Required]
		[Display(Name = "State of Destination")]
		public string StateDestination { get; set; }
		[Required]
		[Display(Name = "Zip code of Destination")]
		public string ZipDestination { get; set; }
		[Display(Name = "Add to Address Book?")]
		public bool AddDestinationToAddressBook { get; set; }
	}
}
