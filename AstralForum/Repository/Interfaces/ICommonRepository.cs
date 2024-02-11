namespace AstralForum.Repositories.Interfaces
{
    public interface ICommonRepository<T> where T : class
    {
        List<T> GetAll();
        int Save();
    }
}