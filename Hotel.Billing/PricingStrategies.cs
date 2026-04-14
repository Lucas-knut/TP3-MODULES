using Hotel.Booking.Contracts;
using Hotel.Billing.Contracts;

namespace Hotel.Billing;

internal class StandardPricingStrategy : IPricingStrategy
{
    public decimal CalculateNightRate(Room room) => room.BasePrice;
}

internal class SuitePricingStrategy : IPricingStrategy
{
    public decimal CalculateNightRate(Room room) => room.BasePrice * 1.2m;
}

internal class FamilyPricingStrategy : IPricingStrategy
{
    public decimal CalculateNightRate(Room room) => room.BasePrice * 0.9m;
}

internal class PricingStrategyFactory
{
    public IPricingStrategy Create(RoomType roomType) => roomType switch
    {
        RoomType.Standard => new StandardPricingStrategy(),
        RoomType.Suite    => new SuitePricingStrategy(),
        RoomType.Family   => new FamilyPricingStrategy(),
        _                 => new StandardPricingStrategy()
    };
}
