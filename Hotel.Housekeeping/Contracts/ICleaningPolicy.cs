using Hotel.Booking.Contracts;

namespace Hotel.Housekeeping.Contracts;

public interface ICleaningPolicy
{
    List<CleaningTask> GenerateTasks(Reservation reservation);
}
