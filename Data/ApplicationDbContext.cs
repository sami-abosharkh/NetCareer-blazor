using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCareer.Models;

namespace NetCareer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
