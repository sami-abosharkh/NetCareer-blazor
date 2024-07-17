using NetCareer.Models;

namespace NetCareer.Repository.Interface
{
    public interface IJobPostRepository : IRepository<JobPost>
    {
        Task UpdateAsync(JobPost entity);
    }
}
