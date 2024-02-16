using Moq;
using Phoneshop.Domain;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Phoneshop.Business.Tests.PhoneTests
{
    public class TestPhoneDelete : BasePhoneTests
    {
        public Task<Phone> NewPhone()
        {
            return phoneService.Create(new Phone(1,
                new Brand(1,
                    "test"),
                1,
                "test",
                "bla, bla, bla",
                1,
                1
                )
                );
        }

        [Fact]
        public void TestDeletingCreatedPhone()
        {
            mockedIRepository.Setup(x => x.Delete(It.IsAny<int>()));
            phoneService.Delete(1);
            mockedIRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void TestDeletingPhoneThatDoesNotExist()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => phoneService.Delete(0));
        }

        [Fact]
        public void TestRunningThoughDeletingThatDoesNotExist()
        {
            mockedIRepository.Verify(x => x.Delete(0), Times.Never);
        }
    }
}