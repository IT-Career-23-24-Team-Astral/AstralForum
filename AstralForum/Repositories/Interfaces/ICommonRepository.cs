namespace AstralForum.Repositories.Interfaces
{
    public interface ICommonRepository<T> where T : class
    {
        int Save();
    }
}
