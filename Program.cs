global using AstralForum.Data;
using AstralForum.Settings;
using AstralForum.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SendGrid.Extensions.DependencyInjection;
using AstralForum.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using AstralForum.Services.Thread;
using AstralForum.Repositories;
using AstralForum.Services.ThreadCategory;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<ThreadRepository>();
builder.Services.AddScoped<ThreadCategoryRepository>();

builder.Services.AddScoped<IThreadCategoryService, ThreadCategoryService>();
builder.Services.AddScoped<IThreadService, ThreadService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IThreadCategoryFacade, ThreadCategoryFacade>();
builder.Services.AddScoped<IThreadFacade, ThreadFacade>();
builder.Services.AddScoped<IUserFacade, UserFacade>();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



// Email Sending Service
builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection("SendGridSettings"));
builder.Services.AddSendGrid(options =>
{
    options.ApiKey = builder.Configuration.GetSection("SendGridSettings").GetValue<string>("ApiKey");
});
builder.Services.AddScoped<IEmailSender, EmailSenderService>();

// Custom authentication middleware
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, AstralForumAuthorizationMiddlewareResultHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
