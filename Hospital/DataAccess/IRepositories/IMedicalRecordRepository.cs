namespace DataAccess.IRepositories
{
    using DataStructure;
    using System.Collections.Generic;

    public interface IMedicalRecordRepository : IGenericRepository<MedicalRecord>
    {
        IEnumerable<MedicalRecord> GetAllMedicalRecords();
        MedicalRecord GetMedicalRecordById(int medicalRecordId);
        MedicalRecord GetMedicalRecordByDate(string recordDate);
        void CreateMedicalRecord(MedicalRecord medicalRecord);
        void DeleteMedicalRecord(MedicalRecord medicalRecord);
        void UpdateMedicalRecord(MedicalRecord medicalRecord);
        void Save();
    }
}
