namespace Trucks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Trucks.Validations;
    public class Despatcher
    {
        public Despatcher()
        {
            this.Trucks= new HashSet<Truck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.DespatcherName)]
        public string Name { get; set; } = null!;
        public string? Position { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }

    }
}
