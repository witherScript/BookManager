using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BookManager.Models;
using System.Threading.Tasks;
using BookManager.ViewModels;
using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


namespace BookManager.Controllers;

public class AccountsController : Controller
{
  private readonly BookManagerContext _db;
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly SignInManager<ApplicationUser> _signInManager;

  private readonly RoleManager<IdentityRole> _roleManager;
  public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, BookManagerContext db, RoleManager<IdentityRole> roleManager)
  {
    _userManager = userManager;
    _signInManager = signInManager;
    _db=db;
    _roleManager = roleManager;
  }

  [HttpGet("/")]
  public ActionResult Index()
  {
    return View();
  }

  public ActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public async Task<ActionResult> Register(RegisterViewModel model)
  {
    if(!ModelState.IsValid)
    {
      return View(model);
    }
    else
    {
      ApplicationUser user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if(result.Succeeded)
      {
        var defaultRole = _roleManager.FindByNameAsync("user").Result;
        if(defaultRole!=null)
        {
          IdentityResult roleAdd = await _userManager.AddToRoleAsync(user, defaultRole.Name);
        }
        return RedirectToAction("Index");
      }
      else
      {
        foreach (IdentityError err in result.Errors)
        {
          ModelState.AddModelError("", err.Description);
        }
        return View(model);
      }
    }
  }

  public ActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public async Task<ActionResult> Login(LoginViewModel model)
  {
    if(!ModelState.IsValid)
    {
      return View(model);
    }
    else
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if(result.Succeeded)
      {
        return RedirectToAction("Index", "Projects");
      }
      else
      {
        ModelState.AddModelError("", "There is something wrong with your email or username. Please try again.");
        return View(model);
      }
    }
  }

  [HttpPost]
  public async Task<ActionResult> LogOff()
  {
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index");
  }

}