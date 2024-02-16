using Phoneshop.Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Phoneshop.Business.Tests.PhoneTests
{
    public class TestPhoneSearch : BasePhoneTests
    {
        public TestPhoneSearch() : base() { }

        [Fact]
        public void TestSearchForPhones()
        {
            mockedIRepository.Setup(x => x.GetAll()).Returns(new List<Phone>() { new Phone(1, new Brand(1, "test"), 1, "test", "test", 1, 1) }.AsQueryable());
            List<Phone> phones = phoneService.Search("test").ToList();

            Assert.Single(phones);
        }

        [Fact]
        public void TestSearchForPhonesThatDoesNotExist()
        {
            List<Phone> phones = phoneService.Search("test").ToList();

            Assert.Empty(phones);
        }
    }
}