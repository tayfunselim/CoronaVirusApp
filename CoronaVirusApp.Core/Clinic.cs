using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoronaVirusApp.Core
{
    public class Clinic
    {
        public int Id { get; set; }        

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }        
        
        public int Capacity { get; set; }        
    }
}
