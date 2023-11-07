namespace BuberDinner.Domain.MenuReviewAggregates.ValueObjects;

public class MenuReviewId : EntityId<MenuReviewId>
{
    public MenuReviewId(Guid value) : base(value)
    {
    }

    public static MenuReviewId New() => new(Guid.NewGuid());
}