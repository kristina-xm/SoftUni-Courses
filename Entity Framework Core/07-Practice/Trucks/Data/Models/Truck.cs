namespace Trucks.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection.Metadata.Ecma335;
    using Trucks.Data.Models.Enums;
    using Trucks.Validations;

    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }
        
        [Key]
        public int Id { get; set; }

        [MaxLength(ValidationsConstants.RegistrationNumberLength)]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(ValidationsConstants.VinNumberMaxLength)]
        public string VinNumber { get; set; } = null!;
        public int TankCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public CategoryType CategoryType { get; set; }
        public MakeType MakeType { get; set; }


        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }
        public virtual Despatcher Despatcher { get; set; }


        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }


    }
}
