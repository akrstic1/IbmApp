using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace IbmApp.Model
{
    [XmlRoot("catalog")]
    public class Catalog
    {
        [XmlElement("book")]
        public List<Book> Books;

        public static Catalog SeedCatalogFromXml()
        {
            XmlSerializer reader = new XmlSerializer(typeof(Catalog));
            StreamReader file = new StreamReader(@"../IbmApp.Model/Dataset/books.xml");
            Catalog overview = (Catalog)reader.Deserialize(file);
            file.Close();

            return overview;
        }
    }
}
