using AstralForum.Data.Entities;

namespace AstralForum.Repositories
{
	public interface ICommonRepository<T> where T : BaseEntity
	{
		Task<T> Create(T entity);
		Task<T> Edit(T entity);
		Task<T> Delete(T entity);
		IQueryable<T> GetAll();
		IQueryable<T> GetAllAsNoTracking();
		int Save();
	}
}
