namespace Hospital.Controllers
{
    using AutoMapper;
    using DataStructure.DTOModels.RoomDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("{id}", Name = "RoomById")]
        public IActionResult GetRoomById(int id)
        {
            var rooms = _roomService.GetRoomById(id);
            return Ok(rooms);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllRooms()
        {
            var rooms = _roomService.GetAllRooms();
            return Ok(rooms);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateRoom([FromBody] RoomDTO room)
        {
            RoomDTO newRoom = _roomService.CreateRoom(room);
            return CreatedAtRoute("RoomById", new { id = newRoom.Id }, newRoom);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] UpdateRoomDTO room)
        {
            var updatedRoom = _roomService.UpdateRoom(id, room);
            return Ok(updatedRoom);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id, [FromBody] DeleteRoomDTO room)
        {
            _roomService.DeleteRoom(id, room);
            return NoContent();
        }
    }
}
