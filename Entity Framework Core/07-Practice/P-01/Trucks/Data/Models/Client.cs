namespace Trucks.Data.Models
{
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.ComponentModel.DataAnnotations;
    using Trucks.Validations;
    public class Client
    {
        public Client()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ClientName)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.ClientNationality)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}
