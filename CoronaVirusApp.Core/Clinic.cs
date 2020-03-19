﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Clinic
    {
        public int Id { get; set; }
        public Clinic()
        {
            NumberofDoctors = new List<Doctor>();
            NumberofPatients = new List<Patient>();
        }

        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CapacityNow { get; set; }
        public List<Doctor> NumberofDoctors { get; set; }
        public List<Patient> NumberofPatients { get; set; }
        public int Capacity { get; set; }
    }
}