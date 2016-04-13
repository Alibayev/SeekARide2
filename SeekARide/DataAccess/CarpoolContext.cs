using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SeekARide.Models;

namespace SeekARide.DataAccess {
	public class CarpoolContext : DbContext {
		public CarpoolContext() : base("CarpoolContext")
        {
			Database.SetInitializer<CarpoolContext>(null);
		}

		public DbSet<User> Users { get; set; }
		public DbSet<TripInformation> TripInformations { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<Location> Locations { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}