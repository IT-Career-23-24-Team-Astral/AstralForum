namespace AstralForum.Repositories.Interfaces
{
    public interface ICommonRepository<T>
    {
        List<T> GetAll();
    }
}
