using Moq;
using System.IO;
using Xunit;

namespace Phoneshop.Business.Tests.FileloggerTests
{
    public class TestFileloggerWarning
    {
        private Mock<StreamWriter> mockedStreamWriter;
        private FileLogger logger;

        [Fact]
        public void TestGoingThroughFileloggerWarning()
        {
            this.mockedStreamWriter = new Mock<StreamWriter>("test2");
            this.logger = new FileLogger(this.mockedStreamWriter.Object);

            logger.Warning("Test");

            mockedStreamWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void TestGivingNullToFileloggerWarning()
        {
            this.mockedStreamWriter = new Mock<StreamWriter>("test4");
            this.logger = new FileLogger(this.mockedStreamWriter.Object);

            logger.Warning(null);

            mockedStreamWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}