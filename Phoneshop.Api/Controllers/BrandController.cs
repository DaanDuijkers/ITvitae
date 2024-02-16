using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;
        private readonly IPhoneService phoneService;

        public BrandController(IBrandService brandService, IPhoneService phoneService)
        {
            this.brandService = brandService;
            this.phoneService = phoneService;
        }

        [HttpGet]
        [Route("HttpGet/GetBrand")]
        public IActionResult Get(int id)
        {
            Brand? brand = this.brandService.GetById(id).Result;

            if (brand != null)
            {
                return Ok(brand);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("HttpGet/GetAllBrands")]
        public IActionResult GetAll()
        {
            List<Brand> brands = this.brandService.GetAll().Result.ToList();

            if (brands != null || brands?.Count == 0)
            {
                return Ok(brands);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("HttpPost/CreateBrand")]
        public async Task<IActionResult> Create(string name)
        {
            if (name != string.Empty)
            {
                try
                {
                    return Ok(await brandService.Create(new Brand(name)));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Vul astublieft een naam in");
            }
        }

        [HttpDelete]
        [Route("HttpDelete/DeleteBrand")]
        public string Delete(int id)
        {
            try
            {
                Brand? brand = this.brandService.GetAll().Result.FirstOrDefault(x => x.Id == id);
                this.brandService.Delete(id);

                foreach (Phone p in phoneService.GetAll().Where(x => x.Id == id))
                {
                    this.phoneService.Delete(p.Id);
                }

                return $"{brand?.Name} was gedelete";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}