using AutoMapper;
namespace CarDealer.DataAccess
{
    internal class MapperInitialization
    {
        internal static IMapper InitializeMapper()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            return mapper;
        }
    }

}
