namespace AstralForum.Services
{
    public class ThreadService
    {
        private readonly ApplicationDbContext context;

        public ThreadService(ApplicationDbContext context)
        {
            this.context = context;

        }
    }
}
