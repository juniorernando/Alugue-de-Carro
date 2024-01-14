using Xunit;

public class RentalServiceTests
{
    [Fact]
    public void ProcessInvoice_LessThan12Hours_ReturnsCorrectInvoice()
    {
        // Arrange
        var rentalService = new RentalService(10.0, 50.0, new TaxService());
        var carRental = new CarRental(DateTime.Now, DateTime.Now.AddHours(5));

        // Act
        rentalService.ProcessInvoice(carRental);

        // Assert
        Assert.Equal(50.0, carRental.Invoice.BasicPayment);
        Assert.Equal(10.0, carRental.Invoice.Tax);
    }

    [Fact]
    public void ProcessInvoice_GreaterThan12Hours_ReturnsCorrectInvoice()
    {
        // Arrange
        var rentalService = new RentalService(10.0, 50.0, new TaxService());
        var carRental = new CarRental(DateTime.Now, DateTime.Now.AddDays(2));

        // Act
        rentalService.ProcessInvoice(carRental);

        // Assert
        Assert.Equal(100.0, carRental.Invoice.BasicPayment);
        Assert.Equal(15.0, carRental.Invoice.Tax);
    }
}
