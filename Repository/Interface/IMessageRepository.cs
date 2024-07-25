using NetCareer.Models;

namespace NetCareer.Repository.Interface
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task UpdateAsync(Message entity);
        Task<List<string>> GetUniqueContactsAsync(string currentUserId);
    }
}
