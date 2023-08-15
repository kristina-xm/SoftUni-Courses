using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Homies.Common;

namespace Homies.Data.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventValidation.nameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(EventValidation.descriptionMaxLength)]
        public string Description { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Organiser))]
        public string OrganiserId { get; set; } = null!;

        [Required]
        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; } 

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; } 

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; } 

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        [Required]
        public Type Type { get; set; } = null!;


        public ICollection<EventParticipant> EventsParticipants = new HashSet<EventParticipant>();
    }
}
