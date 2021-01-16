namespace Hospital.Services
{
    using AutoMapper;
    using DataAccess.IRepositories;
    using DataStructure;
    using DataStructure.DTOModels.MedicalRecordDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MedicalRecordService:IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _repository;
        private readonly IMapper _mapper;
        public MedicalRecordService(IMedicalRecordRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<MedicalRecord> GetAllMedicalRecords()
        {
            return _repository.GetAllMedicalRecords();
        }

        public MedicalRecord GetMedicalRecordByDate(string date)
        {
            return _repository.GetMedicalRecordByDate(date);
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            return _repository.GetMedicalRecordById(id);
        }

        public MedicalRecordDTO CreateMedicalRecord([FromBody] MedicalRecordDTO medicalRecord)
        {
            MedicalRecord medicalRecordEntity = _mapper.Map<MedicalRecord>(medicalRecord);
            _repository.CreateMedicalRecord(medicalRecordEntity);
            _repository.Save();
            MedicalRecordDTO newMedicalRecord = _mapper.Map<MedicalRecordDTO>(medicalRecordEntity);
            return newMedicalRecord;
        }
        public UpdateMedicalRecordDTO UpdateMedicalRecord(int id, [FromBody] UpdateMedicalRecordDTO medicalRecord)
        {
            MedicalRecord medicalRecordEntity = _repository.GetMedicalRecordById(id);
            medicalRecord.Id = medicalRecordEntity.Id;
            _mapper.Map(medicalRecord, medicalRecordEntity);
            _repository.UpdateMedicalRecord(medicalRecordEntity);
            _repository.Save();
            return medicalRecord;
        }
        public DeleteMedicalRecordDTO DeleteMedicalRecord(int id, [FromBody] DeleteMedicalRecordDTO medicalRecord)
        {
            MedicalRecord medicalRecordEntity = _repository.GetMedicalRecordById(id);
            medicalRecord.Id = medicalRecordEntity.Id;
            _mapper.Map(medicalRecord, medicalRecordEntity);
            _repository.DeleteMedicalRecord(medicalRecordEntity);
            _repository.Save();
            return medicalRecord;
        }
    }
}

