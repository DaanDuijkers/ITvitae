using Phoneshop.Business;
using Phoneshop.Domain.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Phoneshop.Domain
{
    [ExcludeFromCodeCoverage]
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataContext dataContext;

        public Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<T> Create(T entity)
        {
            await this.dataContext.Set<T>().AddAsync(entity);
            await this.dataContext.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            this.dataContext.Remove(this.GetById(id));
            this.dataContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return this.dataContext.Set<T>();
        }

        public T GetById(int id)
        {
            return this.dataContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }
    }
}