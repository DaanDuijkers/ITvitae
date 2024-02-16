using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoneshop.Business
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> repository;
        private readonly ILogger logger;
        private readonly ICache cache;

        public BrandService(IRepository<Brand> repository, ILogger logger, ICache cache)
        {
            this.repository = repository;
            this.logger = logger;
            this.cache = cache;
        }

        public async Task<Brand> Create(Brand brand)
        {
            if (repository.GetAll().Any(x => x.Name == brand.Name))
            {
                ArgumentException exception = new("Deze brand is al geregistreerd");
                this.logger.Error(exception.ToString());
                throw exception;
            }

            if (brand != null)
            {
                Brand created = await this.repository.Create(brand);
                logger.Information($"{brand.Name} was added");
                return created;
            }
            else
            {
                ArgumentNullException exception = new("U hebt geen brand opgegeven");
                logger.Error(exception.ToString());
                throw exception;
            }
        }

        public Task Delete(int id)
        {
            if (id > 0)
            {
                Brand brand = GetById(id).Result;
                repository.Delete(id);
                logger.Information($"{brand.Name} was deleted");
            }
            else
            {
                ArgumentOutOfRangeException exception = new("Deze brand is niet geregistreerd");
                logger.Error(exception.ToString());
                throw exception;
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await cache.GetOrCreate("brands", () => Task.Run(() => repository.GetAll().ToList()));
        }

        public async Task<Brand> GetById(int id)
        {
            return await cache.GetOrCreate("brands", () => Task.Run(() => repository.GetById(id)));
        }
    }
}