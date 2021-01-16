namespace DataAccess.Repositories
{
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class MedicineRepository: GenericRepository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            return Get().OrderBy(n => n.Id).Include(n => n.PatientBills)
                .Select(x => new Medicine() { Id = x.Id, Name = x.Name, Price = x.Price, Quantity = x.Quantity, PatientBills = x.PatientBills })
                .ToList();
        }
        public Medicine GetMedicineById(int medicineId)
        {
            return GetByCondition(medicine => medicine.Id.Equals(medicineId)).Include(n => n.PatientBills)
                .Select(x => new Medicine() { Id = x.Id, Name = x.Name, Price = x.Price, Quantity = x.Quantity, PatientBills = x.PatientBills })
                .FirstOrDefault();
        }

        public Medicine GetMedicineByName(string medicineName)
        {
            return GetByCondition(m => m.Name.Equals(medicineName)).Include(n => n.PatientBills)
                .Select(x => new Medicine() { Id = x.Id, Name = x.Name, Price = x.Price, Quantity = x.Quantity, PatientBills = x.PatientBills })
                .FirstOrDefault();
        }

        public void CreateMedicine(Medicine medicine)
        {
            Create(medicine);
        }

        public void DeleteMedicine(Medicine medicine)
        {
            Delete(medicine);
        }

        public void UpdateMedicine(Medicine medicine)
        {
            Update(medicine);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}

