using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            //Implement the static mapper here after Judge exercises

            var context = new CarDealerContext();
            string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");

            string result = ImportSuppliers(context, inputJson);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] suppliersDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson)!;

            ICollection<Supplier> validatedSuppliers = new HashSet<Supplier>();

            foreach (var supplierDto in suppliersDtos)
            {
                Supplier supplier = mapper.Map<Supplier>(supplierDto);

                validatedSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validatedSuppliers);

            context.SaveChanges();

            return $"Successfully imported {validatedSuppliers.Count}.";
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}