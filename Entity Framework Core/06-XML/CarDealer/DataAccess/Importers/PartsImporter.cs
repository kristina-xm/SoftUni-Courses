namespace CarDealer.DataAccess.Importers
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    public class PartsImporter
    {

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = MapperInitialization.InitializeMapper();

            XMLHelper helper = new XMLHelper();

            ImportPartDto[] partDtos = helper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();

            foreach (var partDto in partDtos)
            {
                if (string.IsNullOrEmpty(partDto.Name))
                {
                    continue;
                }

                if (!partDto.SupplierId.HasValue || !context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);

                validParts.Add(part);

            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }
    }
}