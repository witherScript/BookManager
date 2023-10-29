using System.Threading.Tasks;
using BookManager.Models;
using Microsoft.AspNetCore.Identity;

namespace BookManager.Services;
public class UserInitializerService
{
  private readonly UserManager<IdentityUser> _userManager;
  private readonly RoleManager<IdentityRole> _roleManager;

  public UserInitializerService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
  {
    _userManager = userManager;
    _roleManager = roleManager;
  }

  public async Task InitializeAsync()
  {
    if(await _roleManager.RoleExistsAsync("admin") == false)
    {
      await _roleManager.CreateAsync(new IdentityRole("admin"));
      await _roleManager.CreateAsync(new IdentityRole("user"));
    }

    IdentityUser adminUser = await _userManager.FindByNameAsync("admin");

    if(adminUser == null)
    {
      adminUser = new IdentityUser { UserName = "admin", Email = "admin@me.com" };
      await _userManager.CreateAsync(adminUser, "CoveGroupAdmin");
      await _userManager.AddToRoleAsync(adminUser, "admin");
    }
  }

}