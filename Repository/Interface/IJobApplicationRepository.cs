using NetCareer.Models;

namespace NetCareer.Repository.Interface
{
    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        Task UpdateAsync(JobApplication entity);
    }
}
