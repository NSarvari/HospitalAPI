namespace DataAccess.Repositories
{
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class PatientMedicineRepository:GenericRepository<PatientMedicine>,IPatientMedicineRepository
    {
        public PatientMedicineRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<PatientMedicine> GetAllPatientMedicines()
        {
            return Get().Include(n => n.Patient).Include(n => n.Medicine)
                .Select(x => new PatientMedicine() { MedicineID = x.MedicineID, PatientID = x.PatientID, Medicine = x.Medicine, Patient = x.Patient })
                .ToList();
        }

        public void CreatePatientMedicine(PatientMedicine patientMedicine)
        {
            Create(patientMedicine);
        }

        public void DeletePatientMedicine(int patientId, int medicineId)
        {
            PatientMedicine patientMedicine = Context.PatientMedicines.Include(x => x.Patient).Include(x => x.Medicine)
            .Where(x => x.PatientID == patientId && x.MedicineID == medicineId).SingleOrDefault();
            Delete(patientMedicine);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
