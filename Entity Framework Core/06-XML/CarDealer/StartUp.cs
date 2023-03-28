namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using Castle.DynamicProxy.Generators;
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");

            string result = ImportSuppliers(context, inputXml);

            Console.WriteLine(result);
            
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            
            XMLHelper helper= new XMLHelper();

            ImportSupplierDto[] suppliersDtos = helper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var supplierDto in suppliersDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }

                Supplier supplier = mapper.Map<Supplier>(supplierDto);

                validSuppliers.Add(supplier);

            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}