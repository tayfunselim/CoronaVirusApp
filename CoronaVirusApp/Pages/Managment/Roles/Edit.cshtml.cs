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
    public class EditModel : PageModel
    {
        private readonly RoleManager<ApplicationUserRole> roleManager;
        public EditModel(RoleManager<ApplicationUserRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public ApplicationUserRole ApplicationRole { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            var temp = roleManager.FindByIdAsync(id);

            if (temp == null)
            {
                return RedirectToPage("NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(string Id)
        {
            ApplicationUserRole temp = await roleManager.FindByIdAsync(Id);

            if (ModelState.IsValid)
            {
                if (temp.Id == null)
                {
                    var drugo = await roleManager.CreateAsync(temp);
                    TempData["TempMessage"] = "New User is created!";
                }
                else
                {
                    var drugo = await roleManager.UpdateAsync(temp);
                    TempData["TempMessage"] = "User Informartion Updated!";

                    if (drugo.Succeeded)
                    {
                        return RedirectToPage("./Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something went wrong updating this user");
                    }
                }
            }
            return Page();
        }
    }
}
