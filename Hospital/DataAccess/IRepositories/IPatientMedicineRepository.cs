namespace DataAccess.IRepositories
{
    using DataStructure;
    using System.Collections.Generic;

    public interface IPatientMedicineRepository:IGenericRepository<PatientMedicine>
    {
        IEnumerable<PatientMedicine> GetAllPatientMedicines();
        void CreatePatientMedicine(PatientMedicine patientMedicine);
        void DeletePatientMedicine(int patientId, int medicineId);
        void Save();
    }
}
