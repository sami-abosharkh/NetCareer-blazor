using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NetCareer.Models
{
    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProfileID { get; set; }

        [Required, Display(Name = "Company Name")]
        [StringLength(255)]
        public string? CompanyName { get; set; }

        [Required, Display(Name = "Job Title")]
        [StringLength(255)]
        public string? JobTitle { get; set; }
        
        [Required, StringLength(50)]
        public string? Location { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } // Nullable for current employment

        public string? Description { get; set; }

    }
}
