using System.Linq;

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


}
