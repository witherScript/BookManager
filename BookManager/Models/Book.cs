using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Web;
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
}

//location added at POST method to 