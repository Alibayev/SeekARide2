using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeekARide.Models {
	public class User {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string CellPhone { get; set; }
		public string Password { get; set; }

		public virtual ICollection<TripInformation> TripInformations { get; set; } 
	}
}