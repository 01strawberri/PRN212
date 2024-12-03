using System;
using System.Collections.Generic;

namespace HotelManagement_DAL;

public partial class RoomPrice
{
    public int RoomPriceId { get; set; }

    public int RoomId { get; set; }

    public decimal RoomPricePerHour { get; set; }

    public decimal RoomPricePerDay { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Room Room { get; set; } = null!;
}
