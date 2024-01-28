using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public CommonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
