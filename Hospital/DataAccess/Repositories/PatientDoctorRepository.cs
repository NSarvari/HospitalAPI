namespace DataAccess.Repositories
{
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class PatientDoctorRepository : GenericRepository<PatientDoctor>, IPatientDoctorRepository
    {
        public PatientDoctorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<PatientDoctor> GetAllPatientDoctors()
        {
            return Get().Include(n => n.Patient).Include(n => n.Doctor)
                .Select(x => new PatientDoctor() { DoctorID = x.DoctorID, PatientID = x.PatientID, Doctor = x.Doctor, Patient = x.Patient })
                .ToList();
        }

        public void CreatePatientDoctor(PatientDoctor patientDoctor)
        {
            Create(patientDoctor);
        }

        public void DeletePatientDoctor(int patientId, int doctorId)
        {
            PatientDoctor patientDoctor = Context.PatientDoctors.Include(x => x.Patient).Include(x => x.Doctor)
            .Where(x => x.PatientID == patientId && x.DoctorID == doctorId).SingleOrDefault();
            Delete(patientDoctor);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
