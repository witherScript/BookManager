using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BookManager.Models
{
  public class ApplicationUser: IdentityUser
  {
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    public string ZipCode { get; set; }
  }

}

