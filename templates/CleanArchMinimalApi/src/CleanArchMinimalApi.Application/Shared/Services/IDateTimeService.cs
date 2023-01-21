namespace CleanArchMinimalApi.Application.Shared.Services;

internal interface IDateTimeService
{
    DateTime Now();
    DateOnly Today();
}
