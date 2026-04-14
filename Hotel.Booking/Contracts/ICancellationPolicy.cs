namespace Hotel.Booking.Contracts;

public interface ICancellationPolicy
{
    bool CanCancel(Reservation reservation);
    decimal CalculateRefund(Reservation reservation, decimal totalPrice);
}
