using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Person
    {
        public int Id { get; set; }        
        
        [DataType(DataType.Password, ErrorMessage = "Please, enter your Password again!")]
        [Display(Name = "Enter your password!")]
        public string Password { get; set; }        
        
        [DataType(DataType.Text, ErrorMessage = "Please, enter your UserName again!")]
        [Display(Name = "Please enter your UserName!")]
        public string UserName { get; set; }

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

        [Required]
        [Display(Name = "Enter your Phone-Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Enter your E-Mail Adress!")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Please enter valid Email Adderss!")]
        public string Email { get; set; }
        public string Gender { get; set; }        
    }
}
