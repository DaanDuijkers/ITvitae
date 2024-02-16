using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Phoneshop.Domain;
using Xunit;

namespace Phoneshop.Business.Tests.BrandTests
{
    public class TestBrandGetAll : BaseBrandsTests
    {
        [Fact]
        // fix: this is a GetAllBrands, not a GetAllPhones-test.
        // Also: Kenji would change  naming into something like
        // When_GetAllIsCalled_Should_CallGetOrCreateFromCache
        public void TestGetAllBrands()
        {
            // problem: GetAll 
            brandService.GetAll();

            mockedICache.Verify(x => x.GetOrCreate(It.IsAny<string>(),
                It.IsAny<Func<Task<List<Brand>>>>()), Times.Once);
        }
    }
}