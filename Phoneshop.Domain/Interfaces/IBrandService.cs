using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface IBrandService
    {
        Task<Brand> Create(Brand brand);
        Task Delete(int id);
        Task<IEnumerable<Brand>> GetAll();
        Task<Brand> GetById(int id);
    }
}