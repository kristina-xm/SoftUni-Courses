using Homies.Common;
using Homies.Data.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Models
{
    [Authorize]
   
    public class AddEventViewModel
    {

        [Required]
        [StringLength(EventValidation.nameMaxLength, MinimumLength = EventValidation.nameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventValidation.descriptionMaxLength, MinimumLength = EventValidation.nameMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeView> Types { get; set; } = new HashSet<TypeView>(); 
    }
}
