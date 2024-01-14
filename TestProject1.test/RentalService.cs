internal class RentalService
{
    private double v1;
    private double v2;
    private TaxService taxService;

    public RentalService(double v1, double v2, TaxService taxService)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.taxService = taxService;
    }

    internal void ProcessInvoice(CarRental carRental)
    {
        throw new NotImplementedException();
    }
}