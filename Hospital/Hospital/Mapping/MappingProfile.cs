namespace Hospital.Mapping
{
    using AutoMapper;
    using DataStructure;
    using DataStructure.DTOModels.AuthenticationDTO;
    using DataStructure.DTOModels.DoctorDTO;
    using DataStructure.DTOModels.MedicalRecordDTO;
    using DataStructure.DTOModels.MedicineDTO;
    using DataStructure.DTOModels.PatientDoctorDTO;
    using DataStructure.DTOModels.PatientDTO;
    using DataStructure.DTOModels.PatientMedicineDTO;
    using DataStructure.DTOModels.RoomDTO;
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

            this.CreateMap<RoomDTO, Room>();
            this.CreateMap<Room, RoomDTO>();
            this.CreateMap<UpdateRoomDTO, Room>();
            this.CreateMap<DeleteRoomDTO, Room>();

            this.CreateMap<PatientDoctorDTO, PatientDoctor>();
            this.CreateMap<PatientDoctor, PatientDoctorDTO>();

            this.CreateMap<PatientMedicineDTO, PatientMedicine>();
            this.CreateMap<PatientMedicine, PatientMedicineDTO>();

            this.CreateMap<User, UserModel>();
            this.CreateMap<RegisterModel, User>();
            this.CreateMap<UpdateModel, User>();
        }
    }
}
