using Microsoft.AspNetCore.Identity;

namespace NetCareer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
    }

}
