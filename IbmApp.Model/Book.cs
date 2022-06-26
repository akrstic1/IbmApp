using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace IbmApp.Model
{
    public class Book
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public string Genre { get; set; }

        [XmlElement("price")]
        public float Price { get; set; }

        [XmlElement("publish_date", DataType = "date")]
        public DateTime PublishDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }
        public string RentedBy { get; set; }

        public static List<Book> SeedBooksFromXml()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("catalog"));
            StreamReader file = new StreamReader(@"../IbmApp.Model/Dataset/books.xml");
            List<Book> overview = (List<Book>)reader.Deserialize(file);
            file.Close();

            return overview;
        }
    }
}
