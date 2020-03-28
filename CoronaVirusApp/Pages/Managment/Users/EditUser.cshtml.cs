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

        public IActionResult OnGet(string id)
        {
            if(id == null)
            {
                return RedirectToPage("./Index");
            }

            var temp = userManager.FindByIdAsync(id);

            if(temp == null)
            {
                return RedirectToPage("NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Person person)
        {
            ApplicationUser temp = await userManager.FindByIdAsync(person.Id);

            if(ModelState.IsValid)
            {
                if (temp.Id == null)
                {
                    var drugo = await userManager.CreateAsync(temp);
                    TempData["TempMessage"] = "New User is created!";
                }
                else
                {
                    temp.Id = person.Id;
                    temp.FirstName = person.FirstName;
                    temp.LastName = person.LastName;
                    temp.City = person.City;
                    temp.Country = person.Country;
                    temp.PhoneNumber = person.Phone;
                    temp.Adress = person.Adress;
                    temp.Age = person.Age;
                    temp.Email = person.Email;
                    temp.PasswordHash = person.Password;

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
