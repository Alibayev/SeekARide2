using System.Linq;
using SeekARide.Models;

namespace SeekARide.DataAccess.Repository
{
    public interface IRepository<T>
    {

        IQueryable List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(object Id);

    }

	public interface IUserRepository : IRepository<User> {
	}


}
