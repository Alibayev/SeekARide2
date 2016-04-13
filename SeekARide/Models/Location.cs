using System.ComponentModel.DataAnnotations.Schema;

namespace SeekARide.Models {
	public class Location {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int LocationId { get; set; }
		public string StreetAddress { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public string ZipCode { get; set; }
	}
}