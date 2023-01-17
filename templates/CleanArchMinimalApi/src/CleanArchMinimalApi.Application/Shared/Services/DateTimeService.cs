using CleanArchMinimalApi.Application.Abstractions.Services;

namespace CleanArchMinimalApi.Application.Shared.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now() => DateTime.Now;

    public DateOnly Today() => DateOnly.FromDateTime(DateTime.Today);
}
