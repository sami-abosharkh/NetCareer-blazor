using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetCareer.Data;
using NetCareer.Models;
using NetCareer.Repository.Interface;

namespace NetCareer.Repository
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        private IDbContextFactory<ApplicationDbContext> _contextFactory;
        public SkillRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task UpdateAsync(Skill entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Skills.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
