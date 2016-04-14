using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using SeekARide.DataAccess.Repository;
using SeekARide.Models;

namespace SeekARide.Authorization {
	public sealed class UserAccountsManager {
		private static volatile UserAccountsManager instance;
		private static object syncRoot = new Object();
		private UserRepository _repo;

		private UserAccountsManager() { _repo = new UserRepository(); }

		public static UserAccountsManager Instance {
			get {
				if (instance == null) {
					lock (syncRoot) {
						if (instance == null)	
							instance = new UserAccountsManager();
					}
				}
				return instance;
			}
		}

		public bool Login(string email, string pwd) {
			User user = _repo.GetUserByEmail(email);
			string decryptedPwd = Encryption.Decrypt(user.Password);

			if (pwd == decryptedPwd) {
				SetUser(user);
				return true;
			}

			return false;
		}

		public User CurrentUser => (User) HttpContext.Current.Session["__user"];

		public void Register(User user) {
			user.Password = Encryption.Encrypt(user.Password);
			_repo.CreateUser(user);
		}

		private void SetUser(User user) {
			HttpContext.Current.Session.Add("__user", user);
		}

		public void SignOut() {
			SetUser(null);
		}
	}
}

