using Phoneshop.Domain.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Phoneshop.Domain
{
    [ExcludeFromCodeCoverage]
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand() { }

        public Brand(string name)
        {
            this.Name = name;
        }

        public Brand(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static explicit operator Brand(Task<Brand> v)
        {
            throw new NotImplementedException();
        }
    }
}