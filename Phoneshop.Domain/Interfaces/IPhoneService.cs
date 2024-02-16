using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface IPhoneService
    {
        Task<Phone> Create(Phone phone);
        void Delete(int id);
        IEnumerable<Phone> GetAll();
        IEnumerable<Phone> Search(string info);
    }
}