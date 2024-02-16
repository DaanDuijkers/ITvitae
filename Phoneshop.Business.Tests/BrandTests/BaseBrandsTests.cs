using Moq;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business.Tests.BrandTests
{
    public class BaseBrandsTests
    {
        protected IBrandService brandService;
        protected Mock<IRepository<Brand>> mockedIRepository;
        protected Mock<ILogger> mockedILogger;
        protected Mock<ICache> mockedICache;

        public BaseBrandsTests()
        {
            this.mockedIRepository = new Mock<IRepository<Brand>>();
            this.mockedILogger = new Mock<ILogger>();
            this.mockedICache = new Mock<ICache>();

            this.brandService = new BrandService(this.mockedIRepository.Object, this.mockedILogger.Object, this.mockedICache.Object);
        }
    }
}