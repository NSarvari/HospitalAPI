namespace DataAccess.IRepositories
{
    using DataStructure;
    using System.Collections.Generic;

    public interface IDoctorRepository:IGenericRepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();
        Doctor GetDoctorById(int doctorId);
        void CreateDoctor(Doctor doctor);
        void DeleteDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void Save();
    }
}
