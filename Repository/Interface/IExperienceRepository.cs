using NetCareer.Models;

namespace NetCareer.Repository.Interface
{
    public interface IExperienceRepository : IRepository<Experience>
    {
        Task UpdateAsync(Experience entity);
    }
}
