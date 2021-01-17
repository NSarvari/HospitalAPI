namespace Hospital.Services
{
    using AutoMapper;
    using DataAccess.IRepositories;
    using DataStructure;
    using DataStructure.DTOModels.RoomDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class RoomService:IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<Room> GetAllRooms()
        {
            return _repository.GetAllRooms();
        }

        public Room GetRoomById(int id)
        {
            return _repository.GetRoomById(id);
        }
        public RoomDTO CreateRoom([FromBody] RoomDTO room)
        {
            Room roomEntity = _mapper.Map<Room>(room);
            _repository.CreateRoom(roomEntity);
            _repository.Save();
            RoomDTO newDoctor = _mapper.Map<RoomDTO>(roomEntity);
            return newDoctor;
        }
        public UpdateRoomDTO UpdateRoom(int id, [FromBody] UpdateRoomDTO room)
        {
            Room roomEntity = _repository.GetRoomById(id);
            room.Id = roomEntity.Id;
            _mapper.Map(room, roomEntity);
            _repository.UpdateRoom(roomEntity);
            _repository.Save();
            return room;
        }
        public DeleteRoomDTO DeleteRoom(int id, [FromBody] DeleteRoomDTO room)
        {
            Room roomEntity = _repository.GetRoomById(id);
            room.Id = roomEntity.Id;
            _mapper.Map(room, roomEntity);
            _repository.DeleteRoom(roomEntity);
            _repository.Save();
            return room;
        }
    }
}
