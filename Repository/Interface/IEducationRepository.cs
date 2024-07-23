using NetCareer.Models;

namespace NetCareer.Repository.Interface
{
    public interface IEducationRepository : IRepository<Education>
    {
        Task UpdateAsync(Education entity);
    }
}
