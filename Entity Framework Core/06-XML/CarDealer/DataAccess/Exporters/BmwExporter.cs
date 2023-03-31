namespace CarDealer.DataAccess.Exporters
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.DTOs.Export;
    using CarDealer.Utilities;

    public class BmwExporter
    {
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = MapperInitialization.InitializeMapper();

            XMLHelper helper = new XMLHelper();

            ExportBmwCarDto[] bmwCars = context.Cars
                .Where(c => c.Make.ToUpper() == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportBmwCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize(bmwCars, "cars");
        }
    }
}
