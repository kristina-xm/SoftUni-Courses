namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DataAccess.Exporters;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

           // string inputXml = File.ReadAllText("../../../Datasets/sales.xml");

            string result = BmwExporter.GetCarsFromMakeBmw(context);

            Console.WriteLine(result);
            
        }
    }
}