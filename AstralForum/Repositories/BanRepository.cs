using AstralForum.Data.Entities;
using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class BanRepository : CommonRepository<Ban>, IBanRepository
    {
        private ApplicationDbContext context;

        public BanRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        // TODO: Resolve possible issue with timezones
        public List<Ban> GetActiveBansByAffectedUserId(int affectedUserId)
        {
            return context.Set<Ban>()
                .Where(ban => ban.AffectedUserId == affectedUserId)
                .Where(ban => ban.BanEnd >= DateTime.Now)
                .OrderByDescending(ban => ban.BanEnd)
                .ToList();
        }
    }
}
