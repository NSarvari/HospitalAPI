namespace DataAccess.Repositories
{
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoomRepository:GenericRepository<Room>,IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return Get().OrderBy(n => n.Id)
                .Select(x => new Room() { Id = x.Id, WorkingPeriod = x.WorkingPeriod, RoomType = x.RoomType, Doctor = x.Doctor })
                .ToList();
        }
        public Room GetRoomById(int roomId)
        {
            return GetByCondition(room => room.Id.Equals(roomId))
                .Select(x => new Room() { Id = x.Id, WorkingPeriod = x.WorkingPeriod, RoomType = x.RoomType, Doctor = x.Doctor })
                .FirstOrDefault();
        }

        public void CreateRoom(Room room)
        {
            Create(room);
        }

        public void DeleteRoom(Room room)
        {
            Delete(room);
        }
        
        public void UpdateRoom(Room room)
        {
            Update(room);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
