namespace CleanArchMinimalApi.Application.Shared.Services;

public interface IDateTimeService
{
    DateTime Now();
    DateOnly Today();
}
