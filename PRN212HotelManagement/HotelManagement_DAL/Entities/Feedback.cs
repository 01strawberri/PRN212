using System;
using System.Collections.Generic;

namespace HotelManagement_DAL;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int BookingId { get; set; }

    public int UserId { get; set; }

    public int? Rating { get; set; }

    public string? Feedback1 { get; set; }

    public DateTime? FeedbackDate { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
