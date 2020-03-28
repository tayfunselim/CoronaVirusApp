using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Core.Managment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Managment.Roles
{
    public class DeleteModel : PageModel
    {
        private readonly RoleManager<ApplicationUserRole> roleManager;
        public DeleteModel(RoleManager<ApplicationUserRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public ApplicationUserRole ApplicationRole { get; set; }
        public IActionResult OnGet(string id)
        {
            var temp = roleManager.FindByIdAsync(id);
            if (temp == null)
            {
                return RedirectToPage("NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(string id)
        {
            ApplicationUserRole temp = await roleManager.FindByIdAsync(id);

            if (temp == null)
            {
                return RedirectToPage("NotFound");
            }

            var delete = await roleManager.DeleteAsync(temp);

            if (delete.Succeeded)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                foreach (IdentityError error in delete.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }
    }
}

