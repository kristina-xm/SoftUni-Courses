namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Footballers.Utilities;
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        private static XmlHelper xmlHelper;
        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            xmlHelper = new XmlHelper();

            ImportCoachDto[] coachesDtos = xmlHelper.Deserialize<ImportCoachDto[]>(xmlString, "Coaches");

            ICollection<Coach> coachEntities = new HashSet<Coach>();


            foreach (ImportCoachDto coachDto in coachesDtos)
            {
                Coach coachEntity = new Coach();
                coachEntity.Name = coachDto.Name ?? "";
                coachEntity.Nationality = coachDto.Nationality;

                if (string.IsNullOrEmpty(coachEntity.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(coachEntity))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                coachEntities.Add(coachEntity);

                foreach (var footballer in coachDto.Footballers)
                {

                    Footballer footballerEntity = new Footballer();

                    try
                    {
                        footballerEntity.PositionType = (PositionType)footballer.PositionType;
                        footballerEntity.Name = footballer.Name ?? "";
                        footballerEntity.ContractStartDate = DateTime.ParseExact(footballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        footballerEntity.ContractEndDate = DateTime.ParseExact(footballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        footballerEntity.BestSkillType = (BestSkillType)footballer.BestSkillType;

                        if (!IsValid(footballerEntity) || footballerEntity.ContractEndDate < footballerEntity.ContractStartDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                    }
                    catch (Exception)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    coachEntity.Footballers.Add(footballerEntity);

                }

                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coachEntity.Name, coachEntity.Footballers.Count));

            }

            context.Coaches.AddRange(coachEntities);
            context.SaveChanges();


            return sb.ToString().TrimEnd();

        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            xmlHelper = new XmlHelper();

            ImportTeamDto[] teamsDtos =
                JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            ICollection<Team> validTeams = new HashSet<Team>();

            ICollection<int> existingPlayersIds = context.Footballers
                .Select(f => f.Id)
                .ToArray();

            foreach (var teamDto in teamsDtos)
            {
                Team team = new Team
                {
                    Name = teamDto.Name ?? "",
                    Nationality = teamDto.Nationality ?? "",
                    Trophies = teamDto.Trophies
                };

                bool isRegexValid = Regex.IsMatch(team.Name, "^[a-zA-Z\\d\\s.-]+$");

                if (!isRegexValid || team.Trophies == 0 || string.IsNullOrEmpty(team.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(team))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (int footballerId in teamDto.FootballersIds.Distinct())
                {
                    if (!existingPlayersIds.Contains(footballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer tf = new TeamFootballer()
                    {
                        Team = team,
                        FootballerId = footballerId
                    };

                    team.TeamsFootballers.Add(tf);
                }

                validTeams.Add(team);

                sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);


        }
    }
}
