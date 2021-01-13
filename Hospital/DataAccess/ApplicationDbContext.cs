namespace DataAccess
{
    using DataStructure;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() { }
        //private IConfigurationRoot configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //One to many relation-Patient and MedicalRecord
            modelBuilder.Entity<Patient>()
                .HasMany(m => m.MedicalRecords)
                .WithOne(p => p.Patient);

            //One to One relation-Doctor and Room
            modelBuilder.Entity<Doctor>()
                .HasOne(r => r.Room)
                .WithOne(d => d.Doctor)
            .HasForeignKey<Room>(r => r.DoctorID);

            //Many to Many relation-Patient and Doctor
            modelBuilder.Entity<PatientDoctor>()
                .HasKey(pd => new { pd.PatientID, pd.DoctorID });

            //Many to Many relation-Patient and Medicine
            modelBuilder.Entity<PatientMedicine>()
                .HasKey(pm => new { pm.PatientID, pm.MedicineID });
        }

        //Connection to model Patient
        public DbSet<Patient> Patients { get; set; }

        //Connection to model Doctor
        public DbSet<Doctor> Doctors { get; set; }

        //Connection to model Medicine
        public DbSet<Medicine> Medicines { get; set; }

        //Connection to model Room
        public DbSet<Room> Rooms { get; set; }

        //Connection to model MedicalRecord
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        //Connection to model PatientAttendence
        public DbSet<PatientDoctor> PatientDoctors { get; set; }

        //Connection to model PatientBill
        public DbSet<PatientMedicine> PatientMedicines { get; set; }

        //Connection to model User
        public DbSet<User> Users { get; set; }

        //Connection to model Role
        public DbSet<Role> Roles { get; set; }
    }
}
