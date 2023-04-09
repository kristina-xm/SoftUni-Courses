namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.Common;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class ImportCoachDto
    {
    
        [Required]
        [Range(ValidationConstants.CoachNameMin, ValidationConstants.CoachNameMax)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

  
        [Required(AllowEmptyStrings = false)]
        [XmlElement("Nationality")]
        public string Nationality { get; set; } = null!;

        [XmlArray("Footballers")]
        public ImportFootballerDto[] Footballers { get; set; }


    }
}
