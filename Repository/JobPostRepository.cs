using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetCareer.Data;
using NetCareer.Models;
using NetCareer.Repository.Interface;

namespace NetCareer.Repository
{
    public class JobPostRepository : Repository<JobPost>, IJobPostRepository
    {
        private IDbContextFactory<ApplicationDbContext> _contextFactory;
        public JobPostRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task UpdateAsync(JobPost entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.JobPosts.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
