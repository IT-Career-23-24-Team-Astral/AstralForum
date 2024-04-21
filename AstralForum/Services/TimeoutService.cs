using System;
using System.Threading.Tasks;
using AstralForum.Data.Entities;
using Microsoft.AspNetCore.Identity;
using AstralForum.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Services
{
    public class TimeoutService
    {
        private readonly ApplicationDbContext context;

        public TimeoutService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsUserTimeout(User userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId.Id);
            return user != null && user.TimeOut > DateTime.Now;
        }
    }
}
