using CoronaVirusApp.Core;
using CoronaVirusApp.Core.Managment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data
{
    public class CoronaVirusDbContext : IdentityDbContext<ApplicationUser>
    {
        public CoronaVirusDbContext(DbContextOptions<CoronaVirusDbContext> options) : base (options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Patient> Patients { get; set; }                
    }
}
