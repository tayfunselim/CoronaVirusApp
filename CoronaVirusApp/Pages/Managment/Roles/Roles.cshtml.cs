using CoronaVirusApp.Core.Managment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CoronaVirusApp.Pages.Managment.Roles
{
    public class RolesModel : PageModel
    {
        private readonly RoleManager<ApplicationUserRole> roleManager;
        public RolesModel(RoleManager<ApplicationUserRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IEnumerable<ApplicationUserRole> UserRoles { get; set; }
        public void OnGet()
        {
            UserRoles = roleManager.Roles;
        }
    }
}
