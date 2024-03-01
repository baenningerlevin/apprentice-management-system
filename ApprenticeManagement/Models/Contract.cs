using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApprenticeManagement.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please fill in this field")]
        [Display(Name = "Apprentice")]
        public int ApprenticeId { get; set; }

        [ForeignKey(nameof(ApprenticeId))]
        public Apprentice? Apprentice { get; set; }

        [Required(ErrorMessage = "Please fill in this field")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please fill in this field")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please fill in this field")]
        [MaxLength(50, ErrorMessage = "This field can't be longer than 50 characters")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please fill in this field")]
        [Range(0, 5000, ErrorMessage = "The salary must be between 0 and 5000")]
        [Display(Name = "Salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Please fill in this field")]
        [MaxLength(50, ErrorMessage = "This field can't be longer than 50 characters")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; } = string.Empty;
    }
}
