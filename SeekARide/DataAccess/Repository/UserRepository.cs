using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeekARide.DataAccess.Repository;
using SeekARide.Models;

namespace SeekARide.DataAccess.Repository {
	public class UserRepository : Repository<User> {
		public UserRepository() : base() {
		}

		public void CreateUser(User user) {
			Add(user);
			Context.SaveChanges();
		}
	}
}
