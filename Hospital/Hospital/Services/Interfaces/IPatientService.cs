namespace Hospital.Services.Interfaces
{
    using DataStructure;
    using DataStructure.DTOModels.PatientDTO;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientByName(string patientName);
        Patient GetPatientById(int patientId);
        PatientDTO CreatePatient(PatientDTO patient);
        UpdatePatientDTO UpdatePatient(int id, [FromBody] UpdatePatientDTO patient);
        DeletePatientDTO DeletePatient(int id, [FromBody] DeletePatientDTO patient);
    }
}
