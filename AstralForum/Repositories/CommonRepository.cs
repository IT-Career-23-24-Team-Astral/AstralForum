using AstralForum.Data.Entities;
using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext context;

        public CommonRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
