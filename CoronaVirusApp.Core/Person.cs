using CoronaVirusApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Person
    {
        public int Id { get; set; }        

        [Required, StringLength(20, MinimumLength = 3), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, StringLength(20, MinimumLength = 3), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }        
        
        [Required]
        public string City { get; set; }                        
        
        [Required]
        public Gender Gender { get; set; }
    }
}
