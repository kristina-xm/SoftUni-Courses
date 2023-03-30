namespace CarDealer.DataAccess.Importers
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using System.Collections.Generic;
    using System.Linq;
    public class CarImporter
    {
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = MapperInitialization.InitializeMapper();

            XMLHelper helper = new XMLHelper();

            ImportCarDto[] carDtos = helper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();

            foreach (var carDto in carDtos)
            {
                if (string.IsNullOrEmpty(carDto.Make) || string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDto);



                foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                    {
                        continue;
                    }

                    PartCar carPart = new PartCar()
                    {
                        PartId = partDto.PartId
                    };

                    car.PartsCars.Add(carPart);

                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";

        }
    }
}
