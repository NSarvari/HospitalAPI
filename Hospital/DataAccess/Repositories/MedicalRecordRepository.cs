namespace DataAccess.Repositories
{
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MedicalRecordRepository : GenericRepository<MedicalRecord>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<MedicalRecord> GetAllMedicalRecords()
        {
            return Get().OrderBy(n => n.Id)
                .Select(x => new MedicalRecord() { Id = x.Id,  DateOfExamination= x.DateOfExamination, Diagnosis = x.Diagnosis, Patient=x.Patient })
                .ToList();
        }
        public MedicalRecord GetMedicalRecordById(int medicalRecordId)
        {
            return GetByCondition(medicalRecord => medicalRecord.Id.Equals(medicalRecordId))
                .Select(x => new MedicalRecord() { Id = x.Id, DateOfExamination = x.DateOfExamination, Diagnosis = x.Diagnosis, Patient = x.Patient })
                .FirstOrDefault();
        }

        public MedicalRecord GetMedicalRecordByDate(string recordDate)
        {
            return GetByCondition(m => m.DateOfExamination.Equals(recordDate))
                .Select(x => new MedicalRecord() { Id = x.Id, DateOfExamination = x.DateOfExamination, Diagnosis = x.Diagnosis, Patient = x.Patient })
                .FirstOrDefault();
        }

        public void CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            Create(medicalRecord);
        }

        public void DeleteMedicalRecord(MedicalRecord medicalRecord)
        {
            Delete(medicalRecord);
        }

        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            Update(medicalRecord);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
