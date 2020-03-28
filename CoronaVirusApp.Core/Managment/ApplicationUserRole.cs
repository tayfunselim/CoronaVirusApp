using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaVirusApp.Core.Managment
{
    public class ApplicationUserRole
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Role Name Required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
