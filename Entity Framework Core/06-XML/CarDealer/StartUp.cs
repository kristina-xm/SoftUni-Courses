namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.DataAccess.Exporters;
    using CarDealer.DataAccess.Importers;
    using CarDealer.DTOs.Export;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class StartUp : PartsImporter
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

           // string inputXml = File.ReadAllText("../../../Datasets/sales.xml");

            string result = CarExporter.GetCarsWithDistance(context);

            Console.WriteLine(result);
            
        }
    }
}