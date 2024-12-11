using HotelManagement_DAL;
using HotelManagement_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_BLL
{
    public class RoomService
    {
        private readonly RoomRepository _roomRepository;

        public RoomService(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public bool AddRoom(string roomName, string roomType, string roomStatus, string roomDescription = null)
        {
            var newRoom = new Room
            {
                RoomName = roomName,
                RoomType = roomType,
                RoomStatus = roomStatus,
                RoomDescription = roomDescription,
                CreatedAt = DateTime.Now,
            };

            return _roomRepository.AddRoom(newRoom);
        }
        public Room GetRoomById(int roomId)
        {
            return _roomRepository.GetRoomById(roomId);
        }
        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }
        public List<Room> GetRoomsByStatus(string status)
        {
            return _roomRepository.GetRoomsByStatus(status);
        }
        public bool UpdateRoom(int roomId, string roomName, string roomType, string roomStatus, string roomDescription)
        {
            var room = new Room
            {
                RoomId = roomId,
                RoomName = roomName,
                RoomType = roomType,
                RoomStatus = roomStatus,
                RoomDescription = roomDescription,
                CreatedAt = DateTime.Now,
            };

            return _roomRepository.UpdateRoom(room);
        }
        public bool DeleteRoom(int roomId)
        {
            return _roomRepository.DeleteRoom(roomId);
        }
        public List<Room> SearchRooms(string name = null, string type = null, string status = null)
        {
            return _roomRepository.SearchRooms(name, type, status);
        }
    }
}
