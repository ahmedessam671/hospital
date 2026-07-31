using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-many Doctor <-> Clinic (implicit join table)
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Clinics)
                .WithMany(c => c.Doctors)
                .UsingEntity(j => j.ToTable("DoctorClinics"));

            // Appointment relationships - prevent multiple cascade paths
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Clinic)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            // Patient -> Doctor (assigned doctor) - optional
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Doctor)
                .WithMany()
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Staff -> Clinic (optional)
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Clinic)
                .WithMany() // not ideal, but staff collection not defined in Clinic to avoid confusion
                .HasForeignKey(s => s.ClinicId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
