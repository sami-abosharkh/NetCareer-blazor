using System.ComponentModel.DataAnnotations.Schema;

namespace NetCareer.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int JobPostID { get; set; }
        [ForeignKey("JobPostID")]
        public JobPost? JobPost { get; set; }
        public required string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser? User { get; set; }
        public string? CoverLetter { get; set; }
        public string? Resume { get; set; }
        public DateTime AppliedAt { get; set; }
        public required string ApplicationStatus { get; set; }
    }
}
