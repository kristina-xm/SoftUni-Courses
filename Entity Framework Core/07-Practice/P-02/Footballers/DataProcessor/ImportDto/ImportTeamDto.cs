namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.Common;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ImportTeamDto
    {
        [JsonProperty("Name")]
        [Required]
        [Range(ValidationConstants.TeamNameMin, ValidationConstants.TeamNameMax)]
        [RegularExpression("^[a-zA-Z\\d\\s.-]+$")]
        public string Name { get; set; } = null!;

        [JsonProperty("Nationality")]
        [Required]
        [Range(ValidationConstants.NationalityNameMin, ValidationConstants.NationalityNameMax)]
        public string Nationality { get; set; } = null!;

        [JsonProperty("Trophies")]
        [Required]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] FootballersIds { get; set; }
    }
}
