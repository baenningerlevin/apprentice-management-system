using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApprenticeManagement.Models
{
    public class Apprentice_Parent
    {
        [Required(ErrorMessage = "Please fill in this field")]
        [Display(Name = "Parent")]
        public int ParentId { get; set; }

        [Required(ErrorMessage = "Please fill in this field")]
        [Display(Name = "Apprentice")]
        public int ApprenticeId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Parent? Parent { get; set; }

        [ForeignKey(nameof(ApprenticeId))]
        public Apprentice? Apprentice { get; set; }
    }
}
