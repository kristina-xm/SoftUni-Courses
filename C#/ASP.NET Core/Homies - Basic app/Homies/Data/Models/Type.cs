using System.ComponentModel.DataAnnotations;
using Homies.Common;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeValidation.nameMaxLenght)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
