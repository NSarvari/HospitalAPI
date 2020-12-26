namespace Hospital.Mapping
{
    using AutoMapper;
    using DataStructure;
    using DataStructure.DTOModels.DoctorDTO;
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
