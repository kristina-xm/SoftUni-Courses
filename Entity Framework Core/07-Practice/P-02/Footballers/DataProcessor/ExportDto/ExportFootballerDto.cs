﻿namespace Footballers.DataProcessor.ExportDto
{
    using Footballers.Data.Models.Enums;
    using System.Xml.Serialization;

    [XmlType("Footballer")]
    public class ExportFootballerDto
    {
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Position")]
        public string PositionType { get; set; } = null!;
    }
}
