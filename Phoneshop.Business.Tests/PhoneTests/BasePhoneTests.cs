using Moq;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business.Tests
{
    public class BasePhoneTests
    {
        public IPhoneService phoneService;
        public Mock<IRepository<Phone>> mockedIRepository;
        public Mock<ILogger> mockILogger;

        public BasePhoneTests()
        {
            this.mockedIRepository = new Mock<IRepository<Phone>>();
            this.mockILogger = new Mock<ILogger>();

            this.phoneService = new PhoneService(this.mockedIRepository.Object, this.mockILogger.Object);
        }
    }
}