using Xunit;

public class TaxCalculator
{
    public double Tax(double amount)
    {
        if (amount <= 100.0)
        {
            return amount * 0.2;
        }
        else
        {
            return amount * 0.15;
        }
    }
}

public class TaxCalculatorTests
{
    [Fact]
    public void TestTax_LessThanOrEqualTo100()
    {
        // Arrange
        var calculator = new TaxCalculator();
        double amount = 100.0;

        // Act
        double tax = calculator.Tax(amount);

        // Assert
        Assert.Equal(amount * 0.2, tax);
    }

    [Fact]
    public void TestTax_GreaterThan100()
    {
        // Arrange
        var calculator = new TaxCalculator();
        double amount = 200.0;

        // Act
        double tax = calculator.Tax(amount);

        // Assert
        Assert.Equal(amount * 0.15, tax);
    }
}