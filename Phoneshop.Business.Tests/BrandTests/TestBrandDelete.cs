using Moq;
using Phoneshop.Domain;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Phoneshop.Business.Tests.BrandTests
{
    public class TestBrandDelete : BaseBrandsTests
    {
        public async Task<Brand> NewBrand()
        {
            return await brandService.Create(new Brand(1,
                "test"
                )
                );
        }

        [Fact]
        // Delete does two things:
        //  Brand brand = GetById(id).Result;
        // repository.Delete(id);
        // Delete(id) 
        // GetById now uses the cache. So needs to be set up properly
        public void TestGoingThroughDeletingBrand()
        {
            mockedICache.Setup(x => x.GetOrCreate<Brand>("brands", It.IsAny<Func<Task<Brand>>>())).Returns(Task.FromResult(new Brand { Name = "Test" }));
            brandService.Delete(1);

            mockedIRepository.Verify(x => x.Delete(1), Times.Once);
        }

        [Fact]
        public async Task TestThrowingExceptionForDeletingPhoneThatDoesNotExist()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => brandService.Delete(0));
        }
    }
}