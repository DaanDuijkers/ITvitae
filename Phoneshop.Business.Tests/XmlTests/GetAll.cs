using Phoneshop.Business.Phones;
using Phoneshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Phoneshop.Business.Tests.XmlTests
{
    public class GetAll
    {

        [Fact]
        public void TestGetAll()
        {
            List<Phone> output = PhoneXML.GetAll("<Phones></Phones>").ToList();
            Assert.Empty(output);
        }

        [Fact]
        public void TestGetAllNullException()
        {
            Assert.Throws<ArgumentNullException>(() => PhoneXML.GetAll(null));
        }

        [Fact]
        public void TestGetAllPhones()
        {
            string xml = "<Phones>\r\n\t" +
                "<Phone>\r\n\t\t" +
                    "<Brand>Apple</Brand>\r\n\t\t" +
                    "<Type>iPhone 12 Pro 128GB Zwart</Type>\r\n\t\t" +
                    "<Price>1028</Price>\r\n\t\t" +
                    "<Description>description</Description>\r\n\t\t" +
                    "<Stock>17</Stock>\r\n\t" +
                 "</Phone>" +
                 "<Phone>\r\n\t\t" +
                    "<Brand>OnePlus</Brand>\r\n\t\t" +
                    "<Type>Nord 2 128GB Grijs</Type>\r\n\t\t" +
                    "<Price>439</Price>\r\n\t\t" +
                    "<Description>description</Description>\r\n\t\t" +
                    "<Stock>4</Stock>\r\n\t" +
                 "</Phone>\r\n" +
              "</Phones>";

            List<Phone> output = PhoneXML.GetAll(xml).ToList();
            Assert.Equal("Apple", output[0].Brand.Name);
        }
    }
}