namespace CarDealer.DataAccess.Importers
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using System.Collections.Generic;
    using System.Linq;
    public class SalesImporter
    {
        public static string ImportSales(CarDealerContext context, string inputXml)
        {

            IMapper mapper = MapperInitialization.InitializeMapper();

            XMLHelper helper = new XMLHelper();

            ImportSaleDto[] saleDtos = helper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            ICollection<Sale> validSales = new HashSet<Sale>();

            ICollection<int> carIds = context.Cars.Select(c => c.Id).ToArray();

            foreach (var saleDto in saleDtos)
            {
                if (!saleDto.CarId.HasValue ||
                    !carIds.Any(id => id == saleDto.CarId.Value))
                {
                    continue;
                }

                Sale sale = mapper.Map<Sale>(saleDto);

                validSales.Add(sale);

            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }
    }
}
