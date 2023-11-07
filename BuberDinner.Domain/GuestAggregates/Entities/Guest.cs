using BuberDinner.Domain.BillAggregates.ValueObjects;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregates.ValueObjects;
using BuberDinner.Domain.GuestAggregates.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregates.ValueObjects;
using BuberDinner.Domain.UserAggregates.ValueObjects;

namespace BuberDinner.Domain.GuestAggregates.Entities;

public class Guest : Entity<GuestId>
{
    private readonly List<BillId> _billIds = new();
    private readonly List<DinnerId> _pastdinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<DinnerId> _upcomingdinnerids = new();
    private List<MenuReviewId> _menuReviewIds = new();

    private List<GuestRating> _ratings = new();

    private Guest()
    {
    }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public string ProfileImageUrl { get; set; }
    public AverageRating AverageRating { get; set; }

    public required UserId UserId { get; set; }
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingdinnerids.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastdinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();

    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; set; }

    public static Guest Create(string firstName, string lastName, UserId userId)
    {
        return new Guest
        {
            Id = GuestId.New(),
            FirstName = firstName,
            LastName = lastName,
            AverageRating = AverageRating.CreateNew(),
            UserId = userId,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow
        };
    }
}