namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            xmlHelper = new XmlHelper();

            ExportCoachDto[] coaches  = context.Coaches
                .Where(c => c.Footballers.Any())
                .Select(c => new ExportCoachDto
                {
                    Name = c.Name,
                    FootballersCount = c.Footballers.Count,
                    Footballers = c.Footballers
                        .Select(f => new ExportFootballerDto
                        {
                            Name = f.Name,
                            PositionType = f.PositionType.ToString()
                        })
                        .OrderBy(f => f.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.Footballers.Length) 
                .ThenBy(c => c.Name)
                .ToArray();

            return xmlHelper.Serialize(coaches, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamsWithFootballers = context.Teams
                .Include(t => t.TeamsFootballers)
                .ThenInclude(t => t.Footballer)
                .AsNoTracking()
                .ToArray()
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractStartDate >= date)
                        .Select(f => new
                        {
                            FootballerName = f.Footballer.Name,
                            ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.CurrentCulture),
                            ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.CurrentCulture),
                            BestSkillType = Enum.GetName(typeof(BestSkillType), f.Footballer.BestSkillType),
                            PositionType = Enum.GetName(typeof(PositionType), f.Footballer.PositionType)

                        })
                        .OrderByDescending(f => f.ContractEndDate)
                        .ThenBy(f => f.FootballerName)
                        .ToArray()
                })
                .OrderByDescending(t => t.Footballers.Length)
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teamsWithFootballers, Formatting.Indented);
        }
    }
}
