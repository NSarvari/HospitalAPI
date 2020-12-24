namespace DataAccess.IRepositories
{
    using DataStructure;
    using System.Collections.Generic;

    public interface IPatientRepository:IGenericRepository<Patient>
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int patientId);
        void CreatePatient(Patient patient);
        void DeletePatient(int patientId);
        void UpdatePatient(Patient patient);
        void Save();
    }
}
