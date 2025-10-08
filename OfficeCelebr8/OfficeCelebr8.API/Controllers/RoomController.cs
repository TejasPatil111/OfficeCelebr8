using Microsoft.AspNetCore.Mvc;
using OfficeCelebr8.Application.DTOs;
using OfficeCelebr8.Application.Interfaces;

namespace OfficeCelebr8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            return Ok(await _roomRepository.GetAllRooms());
        }

        [HttpGet("GetYourRooms")]
        public async Task<IActionResult> GetYourRooms(int employeeId)
        {
            return Ok(await _roomRepository.GetYourRooms(employeeId));
        }

        [HttpGet("GetRoom/{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            return Ok(await _roomRepository.GetRoomById(id));
        }

        [HttpPost("CreateNewRoom")]
        public async Task<IActionResult> CreateNewRoom(AddRoomDTO newRoom)
        {
            return Ok(await _roomRepository.CreateNewRoom(newRoom, newRoom.MemberUserIds));
        }

        [HttpDelete("DeleteRoom/{roomId}/{employeeId}")]
        public async Task<IActionResult> DeleteRoom(int roomId, int employeeId)
        {
            return Ok(await _roomRepository.DeleteRoom(roomId, employeeId));
        }
    }
}
