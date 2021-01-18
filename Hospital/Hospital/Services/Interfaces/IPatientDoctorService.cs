namespace Hospital.Services.Interfaces
{
    using DataStructure;
    using DataStructure.DTOModels.PatientDoctorDTO;
    using System.Collections.Generic;

    public interface IPatientDoctorService
    {
        IEnumerable<PatientDoctor> GetAllPatientDoctors();
        PatientDoctorDTO CreatePatientDoctor(PatientDoctorDTO doctor);
        bool DeletePatientDoctor(int doctorId, int patientId);
    }
}
