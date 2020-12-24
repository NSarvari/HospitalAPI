namespace DataAccess
{
    using DataAccess.IRepositories;
    using DataAccess.Repositories;
    using DataStructure;

    public class UnitOfWorks:IUnitOfWorks
    {
        private ApplicationDbContext dbContext;
        private GenericRepository<Patient> patients;
        private GenericRepository<Doctor> doctors;

        public UnitOfWorks(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IGenericRepository<Patient> Patients
        {
            get
            {
                return patients ??
                    (patients = new GenericRepository<Patient>(dbContext));
            }
        }

        public IGenericRepository<Doctor> Doctors
        {
            get
            {
                return doctors ??
                    (doctors = new GenericRepository<Doctor>(dbContext));
            }
        }

        public object DoctorRepository { get; set; }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
