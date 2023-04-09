namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.Common;
    using Footballers.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
       
        [Required]
        [Range(ValidationConstants.PlayerNameMin, ValidationConstants.PlayerNameMax)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

      
        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; } = null!;

    
        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; } = null!;

        
        [Required]
        [Range(0, 4)]
        [XmlElement("BestSkillType")]
        public int BestSkillType { get; set; }

        [Required]
        [Range(0, 3)]
        [XmlElement("PositionType")]
        public int PositionType { get; set; }
    }
}
