namespace Hospital.Services.Interfaces
{
    using DataStructure;
    using DataStructure.DTOModels.RoomDTO;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int roomId);
        RoomDTO CreateRoom(RoomDTO room);
        UpdateRoomDTO UpdateRoom(int id, [FromBody] UpdateRoomDTO room);
        DeleteRoomDTO DeleteRoom(int id, [FromBody] DeleteRoomDTO room);
    }
}
