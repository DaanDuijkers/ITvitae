using Phoneshop.Domain.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Phoneshop.Domain
{
    [ExcludeFromCodeCoverage]
    public class Phone : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Type { get; set; }
        public string FullName => $"{this.Brand.Name} {this.Type}";
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Phone() { }

        public Phone(Brand brand, string type, string description, double price, int stock)
        {
            this.Brand = brand;
            this.Type = type;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
        }

        public Phone(int id, int brandId, string type, string description, double price, int stock)
        {
            this.Id = id;
            this.BrandId = brandId;
            this.Type = type;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
        }

        public static explicit operator Phone(Task<Phone> v)
        {
            throw new NotImplementedException();
        }

        public Phone(int id, Brand brand, int brandId, string type, string description, double price, int stock)
        {
            this.Id = id;
            this.Brand = brand;
            this.BrandId = brandId;
            this.Type = type;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
        }

        public Phone(int brandId, Brand brand, string type, string description, double price, int stock)
        {
            this.BrandId = brandId;
            this.Brand = brand;
            this.Type = type;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
        }
    }
}