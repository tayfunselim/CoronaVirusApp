using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Doctor
    {
        public Person Person { get; set; }
        public Doctor()
        {
            Person = new Person();
        }

        public int DoctorId { get; set; }
        public string JobName { get; set; } // pharmaceft, doctor, 
    }
}
