namespace DataAccess.Repositories
{
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return Get().OrderBy(n => n.Id).Include(n => n.PatientAttendences).Include(n => n.MedicalRecords).Include(n => n.PatientBills)
                .Select(x => new Patient() { Id = x.Id, Name = x.Name, Sex = x.Sex, AppointmentDate = x.AppointmentDate, AppointmentHour = x.AppointmentHour, ContactNumber = x.ContactNumber, PatientAttendences = x.PatientAttendences, MedicalRecords = x.MedicalRecords, PatientBills = x.PatientBills })
               .ToList();
        }

        public Patient GetPatientByName(string patientName)
        {
            return GetByCondition(p => p.Name.Equals(patientName)).Include(n => n.PatientAttendences).Include(n => n.MedicalRecords).Include(n => n.PatientBills)
                .Select(x => new Patient() { Id = x.Id, Name = x.Name, Sex = x.Sex, AppointmentDate = x.AppointmentDate, AppointmentHour = x.AppointmentHour, ContactNumber = x.ContactNumber, PatientAttendences = x.PatientAttendences, MedicalRecords = x.MedicalRecords, PatientBills = x.PatientBills })
               .FirstOrDefault();
        }

        public Patient GetPatientById(int patientId)
        {
            return GetByCondition(p => p.Id.Equals(patientId)).Include(n => n.PatientAttendences).Include(n => n.MedicalRecords).Include(n => n.PatientBills)
                .Select(x => new Patient() { Id = x.Id, Name = x.Name, Sex = x.Sex, AppointmentDate = x.AppointmentDate, AppointmentHour = x.AppointmentHour, ContactNumber = x.ContactNumber, PatientAttendences = x.PatientAttendences, MedicalRecords = x.MedicalRecords, PatientBills = x.PatientBills })
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
