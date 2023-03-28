namespace CarDealer.Utilities
{
    using CarDealer.DTOs.Import;
    using System.Xml.Serialization;

    public class XMLHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer serializer =
                new XmlSerializer(typeof(T), xmlRoot);


            StringReader streamReader = new StringReader(inputXml);

            T dtos =
                (T)serializer.Deserialize(streamReader);

            return dtos;
        }

        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer serializer =
                new XmlSerializer(typeof(T[]), xmlRoot);


            StringReader streamReader = new StringReader(inputXml);

            T[] dtos =
                (T[])serializer.Deserialize(streamReader);

            return dtos;
        }
    }
}
