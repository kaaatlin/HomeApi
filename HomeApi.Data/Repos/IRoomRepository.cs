using HomeApi.Data.Models;
using HomeApi.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Repos
{
    /// <summary>
    /// Интерфейс определяет методы для доступа к объектам типа Room в базе 
    /// </summary>
    public interface IRoomRepository
    {
        Task UpdateRoom(Room room, UpdateRoomQuery query);
        Task<Room[]> GetRooms();
        Task<Room> GetRoomById(Guid id);
        Task<Room> GetRoomByName(string name);
        Task AddRoom(Room room);
    }
}
