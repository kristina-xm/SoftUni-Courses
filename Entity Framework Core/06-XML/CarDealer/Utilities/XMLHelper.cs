namespace CarDealer.Utilities
{
    using CarDealer.DTOs.Export;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using System.Text;
    using System.Xml.Serialization;

    public class XMLHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer serializer =
                new XmlSerializer(typeof(T), xmlRoot);


            using StringReader streamReader = new StringReader(inputXml);

            T dtos =
                (T)serializer.Deserialize(streamReader);

            return dtos;
        }

        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer serializer =
                new XmlSerializer(typeof(T[]), xmlRoot);


            using StringReader streamReader = new StringReader(inputXml);

            T[] dtos =
                (T[])serializer.Deserialize(streamReader);

            return dtos;
        }

        public string Serialize<T>(T obj, string rootName)
        {
            
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute(rootName);

            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }

        public string Serialize<T>(T[] obj, string rootName)
        {

            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute(rootName);

            XmlSerializer serializer = new XmlSerializer(typeof(T[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
