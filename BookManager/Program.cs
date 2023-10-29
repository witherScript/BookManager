using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookManager.Models;
using BookManager.Services;
using Microsoft.AspNetCore.Identity;

namespace BookManager
{
  class Program
  {
    static void Main(string[] args)
    {

      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<BookManagerContext>(
                        dbContextOptions => dbContextOptions
                          .UseMySql(
                            builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                          )
                        )
                      );

      builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<BookManagerContext>()
              .AddDefaultTokenProviders();
      
      builder.Services.AddAuthorization(options =>
      {
        options.AddPolicy("RequireAdministratorRole",
                        policy => policy.RequireRole("admin"));
      });

      WebApplication app = builder.Build();

      app.UseDeveloperExceptionPage();
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Account}/{action=Index}/{id?}");

      using (var scope = app.Services.CreateScope())
      {
        var usrInit = scope.ServiceProvider.GetRequiredService<UserInitializerService>();
        usrInit.InitializeAsync().Wait();
      }
      app.Run();
    }
  }
}