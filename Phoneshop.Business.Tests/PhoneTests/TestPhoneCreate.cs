using Moq;
using Phoneshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Phoneshop.Business.Tests
{
    public class TestPhoneCreate : BasePhoneTests
    {
        public TestPhoneCreate() : base() { }

        [Fact]
        public void TestCreatingPhone()
        {
            Task<Phone> test = phoneService.Create(new Phone(1,
                new Brand("test"),
                "test",
                "bla, bla, bla",
                1,
                1
                )
                );

            mockedIRepository.Verify(x => x.Create(It.IsAny<Phone>()), Times.Once);
        }

        [Fact]
        public void TestCreatingPhoneReturnValue()
        {
            mockedIRepository.Setup(x => x.Create(It.IsAny<Phone>())).Returns<Phone>(x => Task.FromResult(x));

            Task<Phone> test = phoneService.Create(new Phone(1,
                new Brand("test"),
                "test",
                "bla, bla, bla",
                1,
                1
                )
                );

            Assert.Equal("test", test.Result.Type);
        }

        [Fact]
        public void TestCreatingPhoneThrowsNullException()
        {
            mockedIRepository.Setup(x => x.Create(It.IsAny<Phone>())).Returns((Task<Phone> x) => x);

            Assert.ThrowsAsync<ArgumentNullException>(() => phoneService.Create(null));
        }

        [Fact]
        public void TestCreatingTwoPhonesWithTheSameName()
        {
            mockedIRepository.Setup(x => x.GetAll()).Returns(new List<Phone> { new Phone(1, new Brand("test"), "test", "bla, bla, bla", 1, 1) }.AsQueryable());

            Assert.ThrowsAsync<ArgumentException>(() => phoneService.Create(new Phone(1, new Brand("test"), "test", "bla, bla, bla", 1, 1)));
        }
    }
}