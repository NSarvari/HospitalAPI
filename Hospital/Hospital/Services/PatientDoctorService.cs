using AutoMapper;
using DataAccess.IRepositories;
using DataStructure;
using DataStructure.DTOModels.PatientDoctorDTO;
using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class PatientDoctorService:IPatientDoctorService
    {
        private readonly IPatientDoctorRepository _repository;
        private readonly IMapper _mapper;
        public PatientDoctorService(IPatientDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<PatientDoctor> GetAllPatientDoctors()
        {
            return _repository.GetAllPatientDoctors();
        }

        public PatientDoctorDTO CreatePatientDoctor([FromBody] PatientDoctorDTO patientDoctor)
        {
            PatientDoctor patientDoctorEntity = _mapper.Map<PatientDoctor>(patientDoctor);
            _repository.CreatePatientDoctor(patientDoctorEntity);
            _repository.Save();
            PatientDoctorDTO newPatientDoctor = _mapper.Map<PatientDoctorDTO>(patientDoctorEntity);
            return newPatientDoctor;
        }

        public bool DeletePatientDoctor(int doctorId, int patientId)
        {
            _repository.DeletePatientDoctor(doctorId,patientId);
            _repository.Save();
            return true ;
        }
    }
}
