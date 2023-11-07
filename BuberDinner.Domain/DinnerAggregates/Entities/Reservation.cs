using BuberDinner.Domain.BillAggregates.ValueObjects;
using BuberDinner.Domain.DinnerAggregates.Enums;
using BuberDinner.Domain.DinnerAggregates.ValueObjects;
using BuberDinner.Domain.GuestAggregates.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregates.Entities;

public class Reservation : Entity<ReservationId>
{
    private Reservation()
    {
    }

    public int GuestCount { get; set; }
    public ReservationStatus Status { get; set; }

    public required GuestId GuestId { get; init; }
    public required BillId BillId { get; init; }

    public DateTime? ArrivalDateTime { get; set; }

    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; set; }

    public static Reservation Create(GuestId guestId, BillId billId)
    {
        return new Reservation
        {
            Id = ReservationId.New(),
            GuestId = guestId,
            BillId = billId,

            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow
        };
    }
}