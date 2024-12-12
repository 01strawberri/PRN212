using HotelManagement_DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_DAL.Repositories
{
    public class RoomRepository
    {
        private readonly Prn212hotelManagementContext _prn212hotelManagementContext;

        public RoomRepository(Prn212hotelManagementContext prn212hotelManagementContext)
        {
            _prn212hotelManagementContext = prn212hotelManagementContext;
        }

        public List<Room> GetAllRooms()
        {
            return _prn212hotelManagementContext.Rooms.ToList();
        }
        public List<Room> getAllRoomsWithPrices()
        {
            return _prn212hotelManagementContext.Rooms.Include(r => r.RoomPrices).ToList();
        }
        public Room? GetRoomById(int id)
        {
            return _prn212hotelManagementContext.Rooms.FirstOrDefault(r => r.RoomId == id);
        }
        public List<Room> GetRoomsByStatus(string status)
        {
            return _prn212hotelManagementContext.Rooms.Where(r => r.RoomStatus == status).ToList();
        }
        public bool AddRoom(Room room)
        {
            var existingRoom = _prn212hotelManagementContext.Rooms.FirstOrDefault(r => r.RoomName == room.RoomName);
            if (existingRoom != null)
            {
                return false;
            }

            _prn212hotelManagementContext.Rooms.Add(room);
            _prn212hotelManagementContext.SaveChanges();
            return true;
        }
        public bool UpdateRoom(Room room)
        {
            var existingRoom = _prn212hotelManagementContext.Rooms.FirstOrDefault(r => r.RoomId == room.RoomId);
            if (existingRoom == null)
            {
                return false;
            }
            existingRoom.RoomName = room.RoomName;
            existingRoom.RoomType = room.RoomType;
            existingRoom.RoomDescription = room.RoomDescription;
            existingRoom.RoomStatus = room.RoomStatus;

            _prn212hotelManagementContext.SaveChanges();
            return true;
        }
        public bool DeleteRoom(int roomId)
        {
            var room = _prn212hotelManagementContext.Rooms.FirstOrDefault(r => r.RoomId == roomId);

            if (room == null)
            {
                return false;
            }

            _prn212hotelManagementContext.Rooms.Remove(room);
            _prn212hotelManagementContext.SaveChanges();
            return true;
        }
        public List<Room> SearchRooms(string name = null, string type = null, string status = null)
        {
            var query = _prn212hotelManagementContext.Rooms.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(r => r.RoomName.Contains(name));
            }

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(r => r.RoomType.Contains(type));
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(r => r.RoomStatus.Contains(status));
            }

            return query.ToList();
        }
        public decimal? GetRoomPricePerDay(int roomId)
        {
            return _prn212hotelManagementContext.RoomPrices
                .Where(rp => rp.RoomId == roomId)
                .Select(rp => rp.RoomPricePerDay)
                .FirstOrDefault();
        }
    }
}
