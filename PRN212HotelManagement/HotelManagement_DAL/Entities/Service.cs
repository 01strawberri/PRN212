using System;
using System.Collections.Generic;

namespace HotelManagement_DAL;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? ServiceDescription { get; set; }

    public decimal ServicePrice { get; set; }

    public string ServiceStatus { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string ServiceType { get; set; } = null!;

    public virtual ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();
}
