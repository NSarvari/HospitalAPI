namespace DataAccess.Repositories
{
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PatientRepository:GenericRepository<Patient>,IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context):base(context)
        {

        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return Context.Patients.ToList();
        }

        public Patient GetPatientById(int patientId)
        {
            return Context.Patients.Find(patientId);
        }

        public void CreatePatient(Patient patient)
        {
            Context.Patients.Add(patient);
        }

        public void DeletePatient(int patientId)
        {
            Patient patient = Context.Patients.Find(patientId);
            Context.Patients.Remove(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            Context.Entry(patient).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
