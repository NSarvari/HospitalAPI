namespace Hospital.Services.Interfaces
{
    using DataStructure;
    using DataStructure.DTOModels.MedicineDTO;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    
    public interface IMedicineService
    {
        IEnumerable<Medicine> GetAllMedicines();
        Medicine GetMedicineByName(string medicineName);
        Medicine GetMedicineById(int medicineId);
        MedicineDTO CreateMedicine(MedicineDTO medicine);
        UpdateMedicineDTO UpdateMedicine(int id, [FromBody] UpdateMedicineDTO medicine);
        DeleteMedicineDTO DeleteMedicine(int id, [FromBody] DeleteMedicineDTO medicine);
    }
}
