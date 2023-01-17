namespace CleanArchMinimalApi.Application.Abstractions.Services;

public interface IDateTimeService
{
    DateTime Now();
    DateOnly Today();
}
