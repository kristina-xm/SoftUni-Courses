using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DataAccess.Exporters
{
    public class CarExporter
    {
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = MapperInitialization.InitializeMapper();

            StringBuilder sb = new StringBuilder();

            ExportCarDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("cars");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, cars, namespaces);

            return sb.ToString().TrimEnd();

        }
    }
}
