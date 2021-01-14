namespace DataAccess.Repositories
{
    using AutoMapper;
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return Get().OrderBy(n=>n.Id).Include(n=>n.PatientAttendences).Select(x=>new Doctor() {Id=x.Id,Name=x.Name, Speciality =x.Speciality, DoctorPhoto =x.DoctorPhoto,Room=x.Room,PatientAttendences=x.PatientAttendences})
                .ToList();
        }
        public Doctor GetDoctorById(int doctorId)
        {
            return GetByCondition(doctor => doctor.Id.Equals(doctorId)).Include(n => n.PatientAttendences).Select(x => new Doctor() { Id = x.Id, Name = x.Name, Speciality = x.Speciality, DoctorPhoto = x.DoctorPhoto, Room = x.Room, PatientAttendences = x.PatientAttendences })
                .FirstOrDefault();
        }

        public void CreateDoctor(Doctor doctor)
        {
            Create(doctor);
        }

        public void DeleteDoctor(Doctor doctor)
        {
            Delete(doctor);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            Update(doctor);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
