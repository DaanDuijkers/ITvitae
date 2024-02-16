using Moq;
using Phoneshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Phoneshop.Business.Tests.BrandTests
{
    public class TestBrandCreate : BaseBrandsTests
    {
        [Fact]
        public async void TestCreatingPhone()
        {
            Brand test = await brandService.Create(new Brand(1,
                "test"
                )
                );

            mockedIRepository.Verify(x => x.Create(It.IsAny<Brand>()), Times.Once);
        }

        [Fact]
        public async void TestCreatingPhoneReturnValue()
        {
            mockedIRepository.Setup(x => x.Create(It.IsAny<Brand>())).Returns<Brand>(x => Task.FromResult(x));

            Brand test = await brandService.Create(new Brand(1,
                "test"
                )
                );

            Assert.Equal("test", test.Name);
        }

        [Fact]
        public async Task TestCreatingPhoneWithNull()
        {
            mockedIRepository.Setup(x => x.Create(It.IsAny<Brand>())).Returns((Task<Brand> x) => x);

            await Assert.ThrowsAsync<ArgumentNullException>(() => brandService.Create(null));
        }


        [Fact]
        public async Task TestCreatingTwoBrandsWithTheSameName()
        {
            mockedIRepository.Setup(x => x.GetAll()).Returns(new List<Brand> { new Brand("test") }.AsQueryable());

            await Assert.ThrowsAsync<ArgumentException>(() => brandService.Create(new Brand("test")));
        }
    }
}