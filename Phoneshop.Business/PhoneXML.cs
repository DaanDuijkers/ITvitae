using Phoneshop.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Phoneshop.Business.Phones
{
    public class PhoneXML
    {
        public static IEnumerable<Phone> GetAll(string xml)
        {
            xml = xml ?? throw new ArgumentNullException(nameof(xml));

            List<Phone> phones = new();

            int stock = 0;
            string type = string.Empty;
            string description = string.Empty;
            string brandName = string.Empty;
            double price = 0;

            using (XmlReader reader = XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(xml))))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "Brand":
                                if (reader.Read())
                                {
                                    brandName = Convert.ToString(reader.Value);
                                }
                                break;
                            case "Type":
                                if (reader.Read())
                                {
                                    type = Convert.ToString(reader.Value);
                                }
                                break;
                            case "Price":
                                if (reader.Read())
                                {
                                    price = Convert.ToDouble(reader.Value);
                                }
                                break;
                            case "Description":
                                if (reader.Read())
                                {
                                    description = Convert.ToString(reader.Value);
                                }
                                break;
                            case "Stock":
                                if (reader.Read())
                                {
                                    stock = Convert.ToInt32(reader.Value);
                                }
                                break;
                        }
                    }

                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == "Phone")
                        {
                            phones.Add(new Phone(new Brand(brandName), type, description, price, stock));
                        }
                    }
                }
            }

            return phones;
        }
    }
}