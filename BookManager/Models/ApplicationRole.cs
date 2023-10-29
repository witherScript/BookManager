using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BookManager.Models;
public class ApplicationRole : IdentityRole
{
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}