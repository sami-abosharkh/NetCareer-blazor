using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetCareer.Data;
using NetCareer.Models;
using NetCareer.Repository.Interface;

namespace NetCareer.Repository
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        private IDbContextFactory<ApplicationDbContext> _contextFactory;
        public ProfileRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task UpdateAsync(Profile entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Profiles.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
