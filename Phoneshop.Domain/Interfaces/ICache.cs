using System;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface ICache
    {
        Task<T> GetOrCreate<T>(string key, Func<Task<T>> createItem);
        void Delete(string key);
    }
}