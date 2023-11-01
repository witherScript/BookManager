using System.Threading.Tasks;
using BookManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BookManager.ViewModels;
using BookManager.Services;
using Microsoft.AspNetCore.Authorization;

namespace BookManager.Controllers;

public class BooksController : Controller
{

  public ActionResult Search()
  {
    return View();
  }

  [HttpPost]
  public Task<ActionResult> Search(SearchDataContainerViewModel toSearch)
  {
      
  }

}




/*
      

*/