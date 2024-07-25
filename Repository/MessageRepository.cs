using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetCareer.Data;
using NetCareer.Models;
using NetCareer.Repository.Interface;

namespace NetCareer.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private IDbContextFactory<ApplicationDbContext> _contextFactory;
        public MessageRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task UpdateAsync(Message entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Messages.Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<string>> GetUniqueContactsAsync(string currentUserId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                // Retrieve unique contact IDs
                var uniqueContactIds = await context.Messages
                    .Where(m => m.ReceiverID.Equals(currentUserId) || m.SenderID.Equals(currentUserId))
                    .Select(m => m.SenderID.Equals(currentUserId) ? m.ReceiverID : m.SenderID)
                    .Distinct()
                    .ToListAsync();

                return uniqueContactIds;
            }
        }
    }
}
