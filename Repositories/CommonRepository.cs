using AstralForum.Data.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
	public class CommonRepository<T> where T : BaseEntity
	{
		protected readonly ApplicationDbContext context;
		public CommonRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		public async Task<T> Create(T entity)
		{
			await this.context.AddAsync(entity);
			await this.context.SaveChangesAsync();
			return entity;
		}
		public async Task<T> Edit(T entity)
		{
			this.context.Update(entity);
			await this.context.SaveChangesAsync();
			return entity;
		}
		public async Task<T> Delete(T entity)
		{
			this.context.Remove(entity);
			await this.context.SaveChangesAsync();
			return entity;
		}
        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsQueryable();
        }
        public int Save()
		{
			return context.SaveChanges();
		}
	}
}
