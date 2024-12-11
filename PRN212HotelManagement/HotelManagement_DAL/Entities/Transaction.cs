using System;
using System.Collections.Generic;

namespace HotelManagement_DAL;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int BookingId { get; set; } //Booking ID

    public int UserId { get; set; } //Customer ID

    public string? EventDescription { get; set; } // Depend on Booking Type that become Description

    public string? TransactionType { get; set; } // Cash (Tien mat)

    public decimal? TransactionAmount { get; set; } // Total Price base on Booking Total Price

    public DateTime? EventDate { get; set; } // Transaction Create Date similar to Booking Created Date 
    
    //Booking Start Day, End Date, Start Time, End Time combine to 2 column to show Start Time and End Time of Transaction

    public string? TransactionStatus { get; set; } // Depend on Booking Status

    public virtual Booking Booking { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
