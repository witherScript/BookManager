using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BookManager.Models;
using System.Threading.Tasks;
using BookManager.ViewModels;
using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.AspNetCore.Authorization;

namespace BookManager.Controllers;
[Authorize(Policy = "RequireAdministratorRole")]
public class RolesController : Controller
{
  private readonly RoleManager<IdentityRole> _roleManager;
  private readonly UserManager<IdentityUser> _userManager;
  public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
  {
    _roleManager = roleManager;
    _userManager = userManager;
  }

  public ActionResult Index()
  {
    return View();
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]  
  public async Task<ActionResult> Create(string Name)  
  {  
      try  
      {  
          if (!string.IsNullOrEmpty(Name))  
          {  
              if (!await _roleManager.RoleExistsAsync(Name))  
              {  
                  await _roleManager.CreateAsync(new IdentityRole(Name));  
                  return RedirectToAction("Index");  
              }  
          }  
          return View();  
      }  
      catch  
      {  
          return View();  
      }  
  }
}