using NetCareer.Components.Pages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCareer.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        //
        [Required]
        public int ProfileID { get; set; }
        //
        [Required, MaxLength(50)]
        public string? University { get; set; }
        //
        [Required, MaxLength(50)]
        public string? Degree { get; set; }
        //
        [Required]
        public DateTime StartYear { get; set; }
        //
        [Required]
        public DateTime EndYear { get; set; }
    }
}
