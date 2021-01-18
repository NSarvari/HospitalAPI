namespace Hospital.Services.Interfaces
{
    using DataStructure;
    using DataStructure.DTOModels.PatientMedicineDTO;
    using System.Collections.Generic;

    public interface IPatientMedicineService
    {
        IEnumerable<PatientMedicine> GetAllPatientMedicines();
        PatientMedicineDTO CreatePatientMedicine(PatientMedicineDTO patientMedicine);
        bool DeletePatientMedicine(int doctorId, int medicineId);
    }
}
