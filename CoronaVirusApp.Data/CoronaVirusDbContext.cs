using CoronaVirusApp.Core;
using Microsoft.EntityFrameworkCore;

namespace CoronaVirusApp.Data
{
    public class CoronaVirusDbContext : DbContext
    {
        public CoronaVirusDbContext(DbContextOptions<CoronaVirusDbContext> options) : base (options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }        
        public DbSet<Patient> Patients { get; set; }   
    }
}