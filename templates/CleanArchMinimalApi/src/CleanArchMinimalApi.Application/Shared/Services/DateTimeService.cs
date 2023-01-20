using CleanArchMinimalApi.Application.Abstractions.Services;

namespace CleanArchMinimalApi.Application.Shared.Services;

public class DateTimeService : IDateTimeService
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
