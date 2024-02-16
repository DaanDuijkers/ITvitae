using Moq;
using Phoneshop.Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Phoneshop.Business.Tests
{
    public class TestPhoneGetAll : BasePhoneTests
    {
        [Fact]
        public void TestGetAllPhones()
        {
            List<Phone> phones = phoneService.GetAll().ToList();

            mockedIRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}