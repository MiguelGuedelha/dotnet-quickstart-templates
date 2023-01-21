namespace CleanArchMinimalApi.Application.Shared.Services;

internal sealed class DateTimeService : IDateTimeService
{
    public DateTime Now()
    {
        return DateTime.Now;
    }

    public DateOnly Today()
    {
        return DateOnly.FromDateTime(DateTime.Today);
    }
}
