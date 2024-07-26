using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCareer.Models;

namespace NetCareer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Message> Messages { get; set; }
    }

}
