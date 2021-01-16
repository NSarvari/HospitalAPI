namespace Hospital.Services.Interfaces
{
    using DataStructure;
    using DataStructure.DTOModels.MedicalRecordDTO;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
   
    public interface IMedicalRecordService
    {
        IEnumerable<MedicalRecord> GetAllMedicalRecords();
        MedicalRecord GetMedicalRecordByDate(string date);
        MedicalRecord GetMedicalRecordById(int medicalRecordId);
        MedicalRecordDTO CreateMedicalRecord(MedicalRecordDTO medicalRecord);
        UpdateMedicalRecordDTO UpdateMedicalRecord(int id, [FromBody] UpdateMedicalRecordDTO medicalRecord);
        DeleteMedicalRecordDTO DeleteMedicalRecord(int id, [FromBody] DeleteMedicalRecordDTO medicalRecord);
    }
}
