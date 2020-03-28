using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Core.Managment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Managment.Users
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public void OnGet()
        {
            ApplicationUsers = userManager.Users;
        }
    }
}
