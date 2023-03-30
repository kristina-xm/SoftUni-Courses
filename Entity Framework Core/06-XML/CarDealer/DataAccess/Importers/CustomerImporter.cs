namespace CarDealer.DataAccess.Importers
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using System.Collections.Generic;
    public class CustomerImporter
    {
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = MapperInitialization.InitializeMapper();

            XMLHelper helper = new XMLHelper();

            ImportCustomerDto[] customersDtos = helper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = new HashSet<Customer>();

            foreach (var custDto in customersDtos)
            {
                if (string.IsNullOrEmpty(custDto.Name) || string.IsNullOrEmpty(custDto.BirthDate))
                {
                    continue;
                }

                Customer customer = mapper.Map<Customer>(custDto);

                validCustomers.Add(customer);
            }
            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }
    }
}
