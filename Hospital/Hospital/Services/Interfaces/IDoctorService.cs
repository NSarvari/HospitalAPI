namespace Hospital.Services.Interfaces
{
    using DataStructure;
    using DataStructure.DTOModels.DoctorDTO;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAllDoctors();

        Doctor GetDoctorById(int doctorId);
        DoctorDTO CreateDoctor(DoctorDTO doctor);
        UpdateDoctorDTO UpdateDoctor(int id, [FromBody] UpdateDoctorDTO doctor);
        DeleteDoctorDTO DeleteDoctor(int id, [FromBody] DeleteDoctorDTO doctor);
    }
}
