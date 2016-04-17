using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeekARide.Models {
	public class AddressBook {
		[Key, ForeignKey("User")]
		public virtual int UserId { get; set; }
		public virtual ICollection<Location> Locations { get; set; }
		public virtual User User { get; set; }
	}
}