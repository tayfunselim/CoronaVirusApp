using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Person
    {
        public int Id { get; set; }
        
        [Required, StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required, StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }
        
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        public string Country { get; set; }        
        public double? Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Gender { get; set; }
        //public string PicturePath { get; set; }
    }
}
