using PayPal.Api;
using Xunit;

public class TaxTests
{
    [Fact]
    public void Tax_LessThan100_Returns20Percent()
    {
        // Arrange
        var tax = new Tax();
        var amount = 50.0;

        // Act
        var result = tax.Tax(amount);

        // Assert
        Assert.Equal(10.0, result);
    }

    [Fact]
    public void Tax_GreaterThan100_Returns15Percent()
    {
        // Arrange
        var tax = new Tax();
        var amount = 200.0;

        // Act
        var result = tax.Tax(amount);

        // Assert
        Assert.Equal(30.0, result);
    }
}
