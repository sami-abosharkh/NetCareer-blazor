using NetCareer.Models;

namespace NetCareer.Repository.Interface
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task UpdateAsync(Profile entity);
    }
}
