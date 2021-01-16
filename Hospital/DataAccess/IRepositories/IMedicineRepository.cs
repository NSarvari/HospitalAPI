namespace DataAccess.IRepositories
{
    using DataStructure;
    using System.Collections.Generic;

    public interface IMedicineRepository:IGenericRepository<Medicine>
    {
        IEnumerable<Medicine> GetAllMedicines();
        Medicine GetMedicineById(int medicineId);
        Medicine GetMedicineByName(string medicineName);
        void CreateMedicine(Medicine medicine);
        void DeleteMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        void Save();
    }
}
