namespace Hospital.Mapping
{
    using AutoMapper;
    using DataStructure;
    using DataStructure.DTOModels.AuthenticationDTO;
    using DataStructure.DTOModels.DoctorDTO;
    using DataStructure.DTOModels.MedicalRecordDTO;
    using DataStructure.DTOModels.MedicineDTO;
    using DataStructure.DTOModels.PatientDTO;
    using System.Collections.Generic;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<DoctorDTO, Doctor>();
            this.CreateMap<Doctor, DoctorDTO>();
            this.CreateMap<UpdateDoctorDTO, Doctor>();
            this.CreateMap<DeleteDoctorDTO, Doctor>();

            this.CreateMap<PatientDTO, Patient>();
            this.CreateMap<Patient, PatientDTO>();
            this.CreateMap<UpdatePatientDTO, Patient>();
            this.CreateMap<DeletePatientDTO, Patient>();

            this.CreateMap<MedicineDTO, Medicine>();
            this.CreateMap<Medicine, MedicineDTO>();
            this.CreateMap<UpdateMedicineDTO, Medicine>();
            this.CreateMap<DeleteMedicineDTO, Medicine>();

            this.CreateMap<MedicalRecordDTO, MedicalRecord>();
            this.CreateMap<MedicalRecord, MedicalRecordDTO>();
            this.CreateMap<UpdateMedicalRecordDTO, MedicalRecord>();
            this.CreateMap<DeleteMedicalRecordDTO,MedicalRecord>();

            this.CreateMap<User, UserModel>();
            this.CreateMap<RegisterModel, User>();
            this.CreateMap<UpdateModel, User>();

            //    CreateMap<DoctorDTO,Doctor>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.PatientAttendences, opt => opt.MapFrom(src => src.PatientAttendences))
            //    .AfterMap((src, dest) => {
            //        foreach (var b in dest.PatientAttendences)
            //        {
            //            b.PatientID = src.Id;
            //        }
            //    });
            //    CreateMap<Patient, PatientDoctor>()
            //              .ForMember(dest => dest.PatientID, opt => opt.MapFrom(src => src.Id))
            //              .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src));
        }

    }
}
