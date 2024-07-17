using System.ComponentModel.DataAnnotations.Schema;

namespace NetCareer.Models
{
    public class UserSkill
    {
        public int UserSkillID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser? User { get; set; }
        public int SkillID { get; set; }
        [ForeignKey("SkillID")]
        public Skill? Skill { get; set; }

        public string? ProficiencyLevel { get; set; }
    }
}
