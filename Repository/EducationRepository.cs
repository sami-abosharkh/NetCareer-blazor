using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetCareer.Data;
using NetCareer.Models;
using NetCareer.Repository.Interface;

namespace NetCareer.Repository
{
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        private IDbContextFactory<ApplicationDbContext> _contextFactory;
        public EducationRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task UpdateAsync(Education entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Educations.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
