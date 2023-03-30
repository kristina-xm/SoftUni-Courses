namespace CarDealer.DataAccess.Importers
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    
    public class SuppliersImporter
    {
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = MapperInitialization.InitializeMapper();

            XMLHelper helper = new XMLHelper();

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

        
    }
}