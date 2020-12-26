namespace DataAccess.IRepositories
{
    using DataStructure;
    using System.Collections.Generic;

    public interface IPatientRepository:IGenericRepository<Patient>
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientByName(string patientName);
        Patient GetPatientById(int patientId);
        void CreatePatient(Patient patient);
        void DeletePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void Save();
    }
}
