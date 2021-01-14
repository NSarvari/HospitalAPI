namespace DataAccess.Repositories
{
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class PatientRepository:GenericRepository<Patient>,IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context):base(context)
        {

        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return Get().OrderBy(n => n.Id)
               .ToList();
        }

        public Patient GetPatientByName(string patientName)
        {
            return GetByCondition(p => p.Name.Equals(patientName))
               .FirstOrDefault();
        }

        public Patient GetPatientById(int patientId)
        {
            return GetByCondition(p => p.Id.Equals(patientId))
               .FirstOrDefault();
        }
        public Patient GetPatientById(string patientName)
        {
            return GetByCondition(p => p.Name.Equals(patientName))
               .FirstOrDefault();
        }

        public void CreatePatient(Patient patient)
        {
            Create(patient);
        }

        public void DeletePatient(Patient patient)
        {
            Delete(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            Update(patient);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
