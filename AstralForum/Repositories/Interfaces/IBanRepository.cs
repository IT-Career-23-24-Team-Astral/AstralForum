using AstralForum.Data.Entities;

namespace AstralForum.Repositories.Interfaces
{
    public interface IBanRepository : ICommonRepository<Ban>
    {
        public List<Ban> GetActiveBansByAffectedUserId(int userId);
    }
}
