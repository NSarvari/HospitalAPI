namespace DataAccess.IRepositories
{
    using DataStructure;
    using System.Collections.Generic;

    public interface IPatientDoctorRepository:IGenericRepository<PatientDoctor>
    {
        IEnumerable<PatientDoctor> GetAllPatientDoctors();
        void CreatePatientDoctor(PatientDoctor patientDoctor);
        void DeletePatientDoctor(int patientId,int doctorId);
        void Save();
    }
}
