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
        public DbSet<PatientDisease> PatientDiseases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientDisease>().HasKey(e => new { e.PatientId, e.DiseaseId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
