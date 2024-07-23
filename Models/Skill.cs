using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCareer.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser? User { get; set; }

        [Required, Display(Name = "Skill")]
        [MaxLength(20)]
        public string? SkillName { get; set; }

        [Required, Display(Name = "Proficiency Level")]
        public string? ProficiencyLevel { get; set; }
    }
}
