using System;
using System.Collections.Generic;

namespace HotelManagement_DAL;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int BookingId { get; set; }

    public int UserId { get; set; }

    public string? EventDescription { get; set; }

    public string? TransactionType { get; set; }

    public decimal? TransactionAmount { get; set; }

    public DateTime? EventDate { get; set; }

    public string? TransactionStatus { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
