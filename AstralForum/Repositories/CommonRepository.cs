using AstralForum.Data.Entities;
using AstralForum.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;

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
        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
