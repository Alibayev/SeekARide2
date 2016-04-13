using System.Data.Entity;
using System.Linq;

namespace SeekARide.DataAccess.Repository {
	public class Repository<T> : IRepository<T> where T : class {
		DbContext context;
		DbSet<T> dbSet;
		public DbSet<T> Model => dbSet;
        public DbContext Context => context;

		public Repository() {
			this.context = new CarpoolContext();
			this.dbSet = context.Set<T>();
		}

		public void Add(T model) {
			dbSet.Add(model);
		}

		public void Update(T model) {
			dbSet.Attach(model);
			context.Entry(model).State = EntityState.Modified;
		}

		public void Delete(T model) {
			if (context.Entry(model).State == EntityState.Detached) {
				dbSet.Attach(model);
			}
			dbSet.Remove(model);
		}

		public T GetById(object id) {
			return dbSet.Find(id);
		}

		public IQueryable List {
			get {
				return dbSet;
			}
		}
	}
}
