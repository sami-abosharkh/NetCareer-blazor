using Microsoft.EntityFrameworkCore;
using NetCareer.Data;
using NetCareer.Models;
using NetCareer.Repository.Interface;

namespace NetCareer.Repository
{
    public class JobApplicationRepository : Repository<JobApplication>, IJobApplicationRepository
    {
        private IDbContextFactory<ApplicationDbContext> _contextFactory;
        public JobApplicationRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task UpdateAsync(JobApplication entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.JobApplications.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
