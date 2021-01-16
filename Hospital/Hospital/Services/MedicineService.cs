namespace Hospital.Services
{
    using AutoMapper;
    using DataAccess.IRepositories;
    using DataStructure;
    using DataStructure.DTOModels.MedicineDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class MedicineService:IMedicineService
    {
        private readonly IMedicineRepository _repository;
        private readonly IMapper _mapper;
        public MedicineService(IMedicineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<Medicine> GetAllMedicines()
        {
            return _repository.GetAllMedicines();
        }

        public Medicine GetMedicineByName(string name)
        {
            return _repository.GetMedicineByName(name);
        }

        public Medicine GetMedicineById(int id)
        {
            return _repository.GetMedicineById(id);
        }

        public MedicineDTO CreateMedicine([FromBody] MedicineDTO medicine)
        {
            Medicine medicineEntity = _mapper.Map<Medicine>(medicine);
            _repository.CreateMedicine(medicineEntity);
            _repository.Save();
            MedicineDTO newMedicine = _mapper.Map<MedicineDTO>(medicineEntity);
            return newMedicine;
        }
        public UpdateMedicineDTO UpdateMedicine(int id, [FromBody] UpdateMedicineDTO medicine)
        {
            Medicine medicineEntity = _repository.GetMedicineById(id);
            medicine.Id = medicineEntity.Id;
            _mapper.Map(medicine, medicineEntity);
            _repository.UpdateMedicine(medicineEntity);
            _repository.Save();
            return medicine;
        }
        public DeleteMedicineDTO DeleteMedicine(int id, [FromBody] DeleteMedicineDTO medicine)
        {
            Medicine medicineEntity = _repository.GetMedicineById(id);
            medicine.Id = medicineEntity.Id;
            _mapper.Map(medicine, medicineEntity);
            _repository.DeleteMedicine(medicineEntity);
            _repository.Save();
            return medicine;
        }
    }
}

