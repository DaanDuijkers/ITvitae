using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoneshop.Business
{
    public class PhoneService : IPhoneService
    {
        private readonly IRepository<Phone> repository;
        private readonly ILogger logger;

        public PhoneService(IRepository<Phone> repository, ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Phone> Create(Phone phone)
        {
            if (repository.GetAll().Any(x => x.Type == phone.Type && x.BrandId == phone.BrandId))
            {
                ArgumentException exception = new($"{phone.FullName} is al geregistreerd");
                logger.Error(exception.ToString());
                throw exception;
            }

            if (phone != null)
            {
                Phone created = await this.repository.Create(phone);
                logger.Information($"{phone.FullName} was added");
                return created;
            }
            else
            {
                ArgumentNullException exception = new("U heeft geen telefoon opgegeven");
                logger.Error(exception.ToString());
                throw exception;
            }
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                this.repository.Delete(id);
                logger.Information($"Phone was deleted");
            }
            else
            {
                ArgumentOutOfRangeException exception = new($"Telefoon is niet geregistreerd");
                logger.Error(exception.ToString());
                throw exception;
            }
        }

        public IEnumerable<Phone> GetAll()
        {
            return this.repository.GetAll().Include(x => x.Brand);
        }

        public Phone GetByID(int id)
        {
            return this.repository.GetById(id);
        }

        public IEnumerable<Phone> Search(string info)
        {
            List<Phone> phones = this.GetAll().Where(
                x => x.FullName.ToLower().Contains(info.ToLower()) ||
                x.Brand.Name.ToLower().Contains(info.ToLower()) ||
                x.Type.ToLower().Contains(info.ToLower()) ||
                x.Description.ToLower().Contains(info.ToLower())
                ).ToList();

            if (phones.Count == 0)
            {
                this.logger.Warning($"No search results for: {info}");
            }
            else
            {
                this.logger.Information($"Search results of {info} were found");
            }

            return phones;
        }
    }
}