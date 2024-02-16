using Microsoft.AspNetCore.Mvc;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System.Text.RegularExpressions;
using ValidationExtensions;

namespace Phoneshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService phoneService;
        private readonly IBrandService brandService;

        public PhoneController(IPhoneService phoneService, IBrandService brandService)
        {
            this.phoneService = phoneService;
            this.brandService = brandService;
        }

        [HttpGet]
        [Route("HttpGet/GetPhones")]
        public IActionResult GetPhones()
        {
            List<Phone> phones = this.phoneService.GetAll().ToList();
            return Ok(phones);
        }

        [HttpGet]
        [Route("HttpGet/Get")]
        public IActionResult Get(int id)
        {
            Phone? phone = this.phoneService.GetAll().FirstOrDefault(x => x.Id == id);

            if (phone != null)
            {
                return Ok(phone);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("HttpPost/Create")]
        public async Task<IActionResult> Create(string brandName, string type, string description, double price, int stock)
        {
            if (brandName != string.Empty &&
                type != string.Empty &&
                description != string.Empty
                )
            {
                try
                {
                    foreach (string phoneNumber in description.ExtractEmails())
                    {
                        description = Regex.Replace(description, phoneNumber, new string('*', phoneNumber.Length));
                    }

                    Brand brand = brandService.GetAll().Result.FirstOrDefault(x => x.Name.ToLower() == brandName.ToLower()) ?? await this.brandService.Create(new Brand(brandName));

                    return Ok(this.phoneService.Create(new Phone(brand.Id, brand, type, description, price, stock)));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Vul astublieft de alle data in");
            }
        }
    }
}