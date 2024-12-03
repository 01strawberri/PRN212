using System;
using System.Collections.Generic;

namespace HotelManagement_DAL;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int BookingId { get; set; }

    public int MethodId { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Booking Booking { get; set; } = null!;

    public virtual PaymentMethod Method { get; set; } = null!;
}
