using System;
using System.Collections.Generic;

namespace HotelManagement_DAL;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomName { get; set; } = null!;

    public string RoomType { get; set; } = null!;

    public string? RoomDescription { get; set; }

    public string RoomStatus { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<RoomPrice> RoomPrices { get; set; } = new List<RoomPrice>();
}
