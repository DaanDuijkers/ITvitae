using Moq;
using System.IO;
using Xunit;

namespace Phoneshop.Business.Tests.FileloggerTests
{
    public class TestFileloggerError
    {
        protected Mock<StreamWriter> mockedStreamWriter;
        protected FileLogger logger;

        public TestFileloggerError()
        {
            this.mockedStreamWriter = new Mock<StreamWriter>("test1");

            this.logger = new FileLogger(this.mockedStreamWriter.Object);
        }

        [Fact]
        public void TestGoThroughLoggerError()
        {
            logger.Error("Test");

            mockedStreamWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}