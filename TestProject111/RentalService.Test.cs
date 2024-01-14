using Xunit;
using System;
using Moq;

public class CarRental
{
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public Invoice Invoice { get; set; }
}

public class Invoice
{
    public double BasicPayment { get; set; }
    public double Tax { get; set; }

    public Invoice(double basicPayment, double tax)
    {
        BasicPayment = basicPayment;
        Tax = tax;
    }
}

public interface ITaxService
{
    double Tax(double amount);
}

public class RentalService
{
    private ITaxService _taxService;
    public double PricePerHour { get; set; }
    public double PricePerDay { get; set; }

    public RentalService(ITaxService taxService)
    {
        _taxService = taxService;
    }

    public void ProcessInvoice(CarRental carRental)
    {
        // ... (o código do método ProcessInvoice vai aqui)
    }
}

public class RentalServiceTests
{
    [Fact]
    public void TestProcessInvoice_LessThanOrEqualTo12Hours()
    {
        // Arrange
        var taxServiceMock = new Mock<ITaxService>();
        taxServiceMock.Setup(ts => ts.Tax(It.IsAny<double>())).Returns(0);
        var rentalService = new RentalService(taxServiceMock.Object) { PricePerHour = 10 };
        var carRental = new CarRental { Start = DateTime.Now, Finish = DateTime.Now.AddHours(12) };

        // Act
        rentalService.ProcessInvoice(carRental);

        // Assert
        Assert.Equal(120, carRental.Invoice.BasicPayment);
    }

    [Fact]
    public void TestProcessInvoice_MoreThan12Hours()
    {
        // Arrange
        var taxServiceMock = new Mock<ITaxService>();
        taxServiceMock.Setup(ts => ts.Tax(It.IsAny<double>())).Returns(0);
        var rentalService = new RentalService(taxServiceMock.Object) { PricePerDay = 100 };
        var carRental = new CarRental { Start = DateTime.Now, Finish = DateTime.Now.AddHours(13) };

        // Act
        rentalService.ProcessInvoice(carRental);

        // Assert
        Assert.Equal(100, carRental.Invoice.BasicPayment);
    }
}