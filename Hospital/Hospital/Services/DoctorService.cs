namespace Hospital.Services
{
    using AutoMapper;
    using DataAccess.IRepositories;
    using DataStructure;
    using DataStructure.DTOModels.DoctorDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _repository.GetAllDoctors();
        }

        public Doctor GetDoctorById(int id)
        {
            return _repository.GetDoctorById(id);
        }
        public DoctorDTO CreateDoctor([FromBody] DoctorDTO doctor)
        {
            Doctor doctorEntity = _mapper.Map<Doctor>(doctor);
            _repository.CreateDoctor(doctorEntity);
            _repository.Save();
            DoctorDTO newDoctor = _mapper.Map<DoctorDTO>(doctorEntity);
            return newDoctor;
        }
        public UpdateDoctorDTO UpdateDoctor(int id, [FromBody] UpdateDoctorDTO doctor)
        {
            Doctor doctorEntity = _repository.GetDoctorById(id);
            doctor.Id = doctorEntity.Id;
            _mapper.Map(doctor, doctorEntity);
            _repository.UpdateDoctor(doctorEntity);
            _repository.Save();
            return doctor;
        }
        public DeleteDoctorDTO DeleteDoctor(int id, [FromBody] DeleteDoctorDTO doctor)
        {
            Doctor doctorEntity = _repository.GetDoctorById(id);
            doctor.Id = doctorEntity.Id;
            _mapper.Map(doctor, doctorEntity);
            _repository.DeleteDoctor(doctorEntity);
            _repository.Save();
            return doctor;
        }
    }
}