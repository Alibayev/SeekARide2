using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeekARide.Models;

namespace SeekARide.DataAccess.Repository {
	public class LocationRepository :Repository<Location> {
		public LocationRepository(CarpoolContext contextIn = null) : base(contextIn) {
			
		}

		public void AddLocation(Location loc) {
			Add(loc);
			Context.SaveChanges();
		}
	}
}