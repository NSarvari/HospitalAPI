namespace Hospital.Services
{
    using AutoMapper;
    using DataAccess.IRepositories;
    using DataStructure;
    using DataStructure.DTOModels.PatientMedicineDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class PatientMedicineService:IPatientMedicineService
    {
        private readonly IPatientMedicineRepository _repository;
        private readonly IMapper _mapper;
        public PatientMedicineService(IPatientMedicineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<PatientMedicine> GetAllPatientMedicines()
        {
            return _repository.GetAllPatientMedicines();
        }

        public PatientMedicineDTO CreatePatientMedicine([FromBody] PatientMedicineDTO patientMedicine)
        {
            PatientMedicine patientMedicineEntity = _mapper.Map<PatientMedicine>(patientMedicine);
            _repository.CreatePatientMedicine(patientMedicineEntity);
            _repository.Save();
            PatientMedicineDTO newPatientMedicine = _mapper.Map<PatientMedicineDTO>(patientMedicineEntity);
            return newPatientMedicine;
        }

        public bool DeletePatientMedicine(int doctorId, int medicineId)
        {
            _repository.DeletePatientMedicine(doctorId, medicineId);
            _repository.Save();
            return true;
        }
    }
}
