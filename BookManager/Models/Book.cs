using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using BookManager.Services;
using Microsoft.Extensions.Configuration;
namespace BookManager.Models;


public class Book
{
  public int BookId{ get; set; }
  public ApplicationUserRole UserRole { get; set; }
  
  [Required(ErrorMessage ="Title is required.")]
  public string Title{ get; set; }
  public string Author { get; set; }
  public string ISBN { get; set; }
  public string Location { get; set; }

  public static List<Book> GetBooks()
  {
    Task<string> apiCallTask = ApiHelper.BooksCall(configuration["ApiKeys:ApiKey"]);

    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(apiCallTask);
    List<Book> bookList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());
      return articleList;
    return {};
  }

}