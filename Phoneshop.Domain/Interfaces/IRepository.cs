using System.Linq;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        Task<T> Create(T entity);
        void Delete(int id);
    }
}