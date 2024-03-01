using System.ComponentModel.DataAnnotations;

namespace ApprenticeManagement.Models
{
    public class Parent
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please fill in this field")]
        [MaxLength(50, ErrorMessage = "This field can't be longer than 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please fill in this field")]
        [MaxLength(50, ErrorMessage = "This field can't be longer than 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        public ICollection<Apprentice_Parent>? Apprentice_Parents { get; set; }
    }
}
