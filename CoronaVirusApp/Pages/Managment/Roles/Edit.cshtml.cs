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
        private readonly RoleManager<IdentityRole> roleManager;
        public EditModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public ApplicationUserRole ApplicationRole { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                var temp = roleManager.FindByIdAsync(id.ToString());

                if (temp == null)
                {
                    return RedirectToPage("NotFound");
                }
            }
            else
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(ApplicationUserRole user)
        {
            if (ModelState.IsValid)
            {
                var zema = await roleManager.FindByIdAsync(user.Id);

                if (user.Id == null)
                {
                    IdentityRole identityRole = new IdentityRole()
                    {
                        Id = user.Id.ToString(),
                        Name = user.RoleName,
                    };

                    IdentityResult drugo = await roleManager.CreateAsync(identityRole);
                    TempData["TempMessage"] = "New User is created!";

                    if (drugo.Succeeded)
                    {
                        return RedirectToPage("./Index");
                    }

                    foreach (IdentityError error in drugo.Errors)
                    {
                        ModelState.AddModelError("","Something went wrong creating this Role");
                    }
                }
                else
                {
                    zema.Id = user.Id;
                    zema.Name = user.RoleName;

                    IdentityResult drugo = await roleManager.UpdateAsync(zema);
                    TempData["TempMessage"] = "User Informartion Updated!";

                    if (drugo.Succeeded)
                    {
                        return RedirectToPage("./Index");
                    }
                }
            }
            return Page();
        }
    }
}
