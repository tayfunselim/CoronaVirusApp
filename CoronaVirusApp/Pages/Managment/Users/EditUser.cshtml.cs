using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Core;
using CoronaVirusApp.Core.Managment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Managment.Users
{
    public class EditUserModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        public EditUserModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public ApplicationUser applicationUser;
        [TempData]
        public string TempMessage { get; set; }

        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
            {
                var temp = userManager.FindByIdAsync(id.ToString());

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

        public async Task<IActionResult> OnPost(ApplicationUser applicationUser)
        {
            ApplicationUser temp = await userManager.FindByIdAsync(applicationUser.Id.ToString());

            if(ModelState.IsValid)
            {
                if (temp.Id == null)
                {
                    var drugo = await userManager.CreateAsync(temp);
                    TempData["TempMessage"] = "New User is created!";
                }
                else
                {
                    temp.Id = applicationUser.Id.ToString();
                    temp.FirstName = applicationUser.FirstName;
                    temp.LastName = applicationUser.LastName;
                    temp.City = applicationUser.City;
                    temp.Country = applicationUser.Country;
                    temp.PhoneNumber = applicationUser.PhoneNumber;
                    temp.Adress = applicationUser.Adress;
                    temp.Age = applicationUser.Age;
                    temp.Email = applicationUser.Email;
                    temp.PasswordHash = applicationUser.PasswordHash;

                    var drugo = await userManager.UpdateAsync(temp);
                    TempData["TempMessage"] = "User Informartion Updated!";

                    if(drugo.Succeeded)
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
