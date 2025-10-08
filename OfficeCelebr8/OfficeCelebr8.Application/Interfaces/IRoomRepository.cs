using OfficeCelebr8.Application.DTOs;
using OfficeCelebr8.Domain.Models;

namespace OfficeCelebr8.Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<IEnumerable<Room>> GetYourRooms(int employeeId);
        Task<Room> GetRoomById(int id);
        Task<Room> CreateNewRoom(AddRoomDTO newRoom, List<int> memberUserIds);
        Task<bool> DeleteRoom(int roomId, int employeeId);
    }
}
