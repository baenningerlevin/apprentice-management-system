using System.ComponentModel.DataAnnotations;

namespace ApprenticeManagement.Models
{
    public class Apprentice
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

        [Required(ErrorMessage = "Please fill in this field")]
        [MaxLength(50, ErrorMessage = "This field can't be longer than 50 characters")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please fill in this field")]
        [Range(1000, 9999, ErrorMessage = "The value must be between 1000 and 9999")]
        [Display(Name = "Zip Code")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Please fill in this field")]
        [MaxLength(50, ErrorMessage = "This field can't be longer than 50 characters")]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please fill in this field")]
        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Please fill in this field")]
        [EmailAddress(ErrorMessage = "Please fill in a valid email")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please fill in this field")]
        [Phone(ErrorMessage = "Please fill in a valid phone number")]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;

        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public ICollection<Apprentice_Parent>? Apprentice_Parents { get; set; }
    }
}
