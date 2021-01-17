namespace DataAccess.IRepositories
{
    using DataStructure;
    using System.Collections.Generic;
    public interface IRoomRepository:IGenericRepository<Room>
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int roomId);
        void CreateRoom(Room room);
        void DeleteRoom(Room room);
        void UpdateRoom(Room room);
        void Save();
    }
}
