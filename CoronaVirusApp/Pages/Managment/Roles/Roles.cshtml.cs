using CoronaVirusApp.Core.Managment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CoronaVirusApp.Pages.Managment.Roles
{
    public class RolesModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IEnumerable<IdentityRole> UserRoles { get; set; }
        public void OnGet()
        {
            UserRoles = roleManager.Roles;
        }
    }
}
