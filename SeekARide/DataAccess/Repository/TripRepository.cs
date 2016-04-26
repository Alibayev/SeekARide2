using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SeekARide.Models;

namespace SeekARide.DataAccess.Repository {
	public class TripRepository : Repository<Trip> {
		public void AddTrip(NewPostingViewModel viewModel, User user) {
			using (Context) {
				Location to = new Location();
				to.StreetAddress = viewModel.StreetAddressDestination;
				to.City = viewModel.CityDestination;
				to.State = viewModel.StateDestination;
				to.ZipCode = viewModel.ZipDestination;

				Location from = new Location();
				from.StreetAddress = viewModel.StreetAddressOrigin;
				from.City = viewModel.CityOrigin;
				from.State = viewModel.StateOrigin;
				from.ZipCode = viewModel.ZipOrigin;

				Trip trip = new Trip();
				trip.To = to;
				trip.From = from;
				trip.TravelDateTime = viewModel.DateTime;
				trip.Type = viewModel.TripType;

				TripInformation tripInformation = new TripInformation();
				tripInformation.Capacity = viewModel.TripType == TripType.LookingForPassengers ? 3 : 1;
				trip.TripInformation = tripInformation;
				using (CarpoolContext context = new CarpoolContext()) {
					user = context.Users.Single(x => x.UserId == user.UserId);
					trip.TripInformation.Owner = user;
          context.Trips.Add(trip);
					AddressBook addressBook = context.AddressBooks.SingleOrDefault(x => x.UserId == user.UserId);
					bool isNewAddressBook = addressBook == null;
          if (viewModel.AddOriginToAddressBook) {
	          if (addressBook == null) {
							addressBook = new AddressBook() { User = user, UserId = user.UserId, Locations = new List<Location>()};
						}
						addressBook.Locations.Add(from);
					}
					if (viewModel.AddDestinationToAddressBook) {
						if (addressBook == null) {
							addressBook = new AddressBook() { User = user, UserId = user.UserId, Locations = new List<Location>() };
						}
						addressBook.Locations.Add(to);
					}
					if (viewModel.AddOriginToAddressBook || viewModel.AddDestinationToAddressBook) {
						if (isNewAddressBook) {
							context.AddressBooks.Add(addressBook);
						}
						else {
							context.Set<AddressBook>().Attach(addressBook);
							context.Entry(addressBook).State = EntityState.Modified;
						}
					}
					context.SaveChanges();
				}
			}

		}

		public IList<Trip> GetAllActiveTrips() {
			return Model.Where(x => x.TravelDateTime > DateTime.Now).OrderByDescending(x=>x.TripId).ToList();
		} 
	}

	public class TripInformationRepository : Repository<TripInformation> {
		public TripInformationRepository(CarpoolContext contextIn = null) : base(contextIn) {
			
		}

		public void AddTripInformation(TripInformation trip) {
			Add(trip);
			Context.SaveChanges();
		}
        public void UpdateTripInformation(TripInformation tripInfo)
        {
            Update(tripInfo);
            Context.SaveChanges();
        }
	}
}