using Hotel.Booking.Contracts;

namespace Hotel.Billing.Contracts;

public interface IPricingStrategy
{
    decimal CalculateNightRate(Room room);
}
