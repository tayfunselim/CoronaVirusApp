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

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
