using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetCareer.Data;
using NetCareer.Models;
using NetCareer.Repository.Interface;

namespace NetCareer.Repository
{
    public class ExperienceRepository : Repository<Experience>, IExperienceRepository
    {
        private IDbContextFactory<ApplicationDbContext> _contextFactory;
        public ExperienceRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task UpdateAsync(Experience entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Experiences.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
