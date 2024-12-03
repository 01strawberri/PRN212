using System;
using System.Collections.Generic;

namespace HotelManagement_DAL;

public partial class Booking
{
    public int BookingId { get; set; }

    public int UserId { get; set; }

    public int RoomId { get; set; }

    public DateOnly BookingStartDay { get; set; }

    public DateOnly BookingEndDay { get; set; }

    public TimeOnly? BookingStartTime { get; set; }

    public TimeOnly? BookingEndTime { get; set; }

    public string BookingType { get; set; } = null!;

    public decimal? TotalPrice { get; set; }

    public string BookingStatus { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room Room { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
