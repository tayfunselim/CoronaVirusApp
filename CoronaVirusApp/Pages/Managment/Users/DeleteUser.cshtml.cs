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
    public class DeleteUserModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        public DeleteUserModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public ApplicationUser ApplicationUser { get; set; }
        public IActionResult OnGet(string id)
        {
            var temp = userManager.FindByIdAsync(id);
            if(temp == null)
            {
                return RedirectToPage("NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(string id)
        {
            ApplicationUser temp = await userManager.FindByIdAsync(id);

            if(temp == null)
            {
                return RedirectToPage("NotFound");
            }

            var delete = await userManager.DeleteAsync(temp);

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
