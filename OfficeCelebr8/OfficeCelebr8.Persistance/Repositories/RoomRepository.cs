using Microsoft.EntityFrameworkCore;
using OfficeCelebr8.Application.DTOs;
using OfficeCelebr8.Application.Exceptions;
using OfficeCelebr8.Application.Interfaces;
using OfficeCelebr8.Domain.Models;
using OfficeCelebr8.Persistance.Context;

namespace OfficeCelebr8.Persistance.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;
        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Rooms.Include(r => r.Members).ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetYourRooms(int employeeId)
        {
            var yourRooms = await _context.Rooms.Include(r => r.Members)
                                                .Where(r => r.CreatedBy == employeeId).ToListAsync();
            if (yourRooms.Count == 0)
            {
                throw new NotFoundException($"Rooms for employee having ID {employeeId} not found.");
            }
            return yourRooms;
        }

        public async Task<Room> GetRoomById(int id)
        {
            var room = await _context.Rooms.Include(r => r.Members)
                                           .FirstOrDefaultAsync(r => r.Id == id);
            if (room == null)
            {
                throw new NotFoundException($"Room with ID {id} not found.");
            }
            return room;
        }

        
        public async Task<Room> CreateNewRoom(AddRoomDTO newRoom, List<int> memberUserIds)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var createRoom = new Room
                    {
                        Name = newRoom.Name,
                        Description = newRoom.Description,
                        Capacity = newRoom.Capacity,
                        CreatedBy = newRoom.CreatedBy,
                        EventOn = newRoom.EventOn,
                        TotalCollection = newRoom.TotalCollection
                    };
                    await _context.Rooms.AddAsync(createRoom);
                    await _context.SaveChangesAsync();
                    var roomMembers = memberUserIds.Select(userId => new RoomMember
                    {
                        RoomId = createRoom.Id,
                        EmployeeId = newRoom.CreatedBy
                    }).ToList();
                    await _context.RoomMembers.AddRangeAsync(roomMembers);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return createRoom;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message, ex);
                }
            }

        }

        public async Task<bool> DeleteRoom(int roomId, int employeeId)
        {
            var findRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == roomId && r.CreatedBy == employeeId);
            if (findRoom == null)
            {
                throw new NotFoundException($"Room with ID {roomId} made by employee having ID {employeeId} not found.");
            }
            _context.Rooms.Remove(findRoom!);
            if (await _context.SaveChangesAsync() <= 0)
            {
                throw new Exception("For some reasons, room has not been deleted.");
            }
            return true;
        }

    }
}
