using NetCareer.Models;

namespace NetCareer.Repository.Interface
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task UpdateAsync(Skill entity);
    }
}
