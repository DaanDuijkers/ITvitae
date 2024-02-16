using Moq;
using System.IO;
using Xunit;

namespace Phoneshop.Business.Tests.FileloggerTests
{
    public class TestFileloggerInformation
    {
        private Mock<StreamWriter> mockedStreamWriter;
        private FileLogger logger;

        public TestFileloggerInformation()
        {
            this.mockedStreamWriter = new Mock<StreamWriter>("test3");

            this.logger = new FileLogger(this.mockedStreamWriter.Object);
        }

        [Fact]
        public void TestGoingThroughFileloggerInformation()
        {
            logger.Information("Test");

            mockedStreamWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}