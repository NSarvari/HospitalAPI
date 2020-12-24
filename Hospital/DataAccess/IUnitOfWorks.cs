namespace DataAccess
{
    using DataAccess.IRepositories;
    using DataStructure;

    public interface IUnitOfWorks
    {
        IGenericRepository<Patient> Patients { get; }
        IGenericRepository<Doctor> Doctors { get; }

        void Commit();
    }
}
