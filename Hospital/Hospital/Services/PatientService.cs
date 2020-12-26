namespace Hospital.Services
{
    using AutoMapper;
    using DataAccess.IRepositories;
    using DataStructure;
    using DataStructure.DTOModels.PatientDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<Patient> GetAllPatients()
        {
            return _repository.GetAllPatients();
        }

        public Patient GetPatientByName(string name)
        {
            return _repository.GetPatientByName(name);
        }

        public Patient GetPatientById(int id)
        {
            return _repository.GetPatientById(id);
        }

        public PatientDTO CreatePatient([FromBody] PatientDTO patient)
        {
            Patient patientEntity = _mapper.Map<Patient>(patient);
            _repository.CreatePatient(patientEntity);
            _repository.Save();
            PatientDTO newPatient = _mapper.Map<PatientDTO>(patientEntity);
            return newPatient;
        }
        public UpdatePatientDTO UpdatePatient(int id, [FromBody] UpdatePatientDTO patient)
        {
            Patient patientEntity = _repository.GetPatientById(id);
            patient.Id = patientEntity.Id;
            _mapper.Map(patient, patientEntity);
            _repository.UpdatePatient(patientEntity);
            _repository.Save();
            return patient;
        }
        public DeletePatientDTO DeletePatient(int id, [FromBody] DeletePatientDTO patient)
        {
            Patient patientEntity = _repository.GetPatientById(id);
            patient.Id = patientEntity.Id;
            _mapper.Map(patient, patientEntity);
            _repository.DeletePatient(patientEntity);
            _repository.Save();
            return patient;
        }
    }
}
