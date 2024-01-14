internal class CarRental
{
    private DateTime now;
    private DateTime dateTime;

    public CarRental(DateTime now, DateTime dateTime)
    {
        this.now = now;
        this.dateTime = dateTime;
    }

    public object Invoice { get; internal set; }
}