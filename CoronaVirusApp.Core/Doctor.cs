using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Doctor : Person
    {
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }

        public string JobName { get; set; } // pharmaceft, doctor, 
        public List<Appointment> Appointments { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }


    }
}
