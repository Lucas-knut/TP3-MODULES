using Hotel.Booking.Contracts;
using Hotel.Billing.Contracts;

namespace Hotel.Billing;

public class BillingService
{
    private readonly InvoiceGenerator _invoiceGenerator;
    private readonly IReservationRepository _reservationRepo;

    public BillingService(
        IReservationRepository reservationRepo,
        IRoomRepository roomRepo)
    {
        var pricingFactory = new PricingStrategyFactory();
        var taxCalculator = new TaxCalculator();
        _invoiceGenerator = new InvoiceGenerator(pricingFactory, taxCalculator, roomRepo);
        _reservationRepo = reservationRepo;
    }

    public Invoice GetInvoice(string reservationId)
    {
        var reservation = _reservationRepo.GetById(reservationId)
            ?? throw new Exception($"Reservation {reservationId} not found");

        return _invoiceGenerator.Generate(reservation);
    }
}
