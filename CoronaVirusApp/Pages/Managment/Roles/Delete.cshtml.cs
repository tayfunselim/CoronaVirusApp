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
        private readonly RoleManager<IdentityRole> roleManager;
        public DeleteModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IdentityRole ApplicationRole { get; set; }
        public IActionResult OnGet(int id)
        {
            var temp = roleManager.FindByIdAsync(id.ToString());
            if (temp == null)
            {
                return RedirectToPage("NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            IdentityRole temp = await roleManager.FindByIdAsync(id.ToString());

            if (temp == null)
            {
                return RedirectToPage("NotFound");
            }

            IdentityResult delete = await roleManager.DeleteAsync(temp);

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

