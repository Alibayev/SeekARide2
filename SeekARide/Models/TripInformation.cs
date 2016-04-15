using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeekARide.Models {
	public class TripInformation {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TripInformationId { get; set; }
		public virtual User Owner { get; set; }
		public virtual ICollection<User> Users {get; set; }
		public int Capacity { get; set; }
	}
}