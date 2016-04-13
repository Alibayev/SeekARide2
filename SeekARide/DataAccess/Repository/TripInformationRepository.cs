using SeekARide.Models;

namespace SeekARide.DataAccess.Repository {
	public class TripInformationRepository : Repository<Trip> {
		public void Add(Trip t, int userId) {
			Add(t);
			TripInformation tripInformation = new TripInformation();
			tripInformation.Trip = t;
			tripInformation.Users.Add(new UserRepository().GetById(userId));
			Context.Set<TripInformation>().Add(tripInformation);
			Context.SaveChanges();
		}
	}
}