using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaVirusApp.Core.Managment
{
    public class ApplicationUserRole : IdentityRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
