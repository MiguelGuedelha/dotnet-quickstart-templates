FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CleanArchMinimalApi.Api/CleanArchMinimalApi.Api.csproj", "src/CleanArchMinimalApi.Api/"]
COPY ["src/CleanArchMinimalApi.Application/CleanArchMinimalApi.Application.csproj", "src/CleanArchMinimalApi.Application/"]
COPY ["src/CleanArchMinimalApi.Shared/CleanArchMinimalApi.Shared.csproj", "src/CleanArchMinimalApi.Shared/"]
COPY ["src/CleanArchMinimalApi.Domain/CleanArchMinimalApi.Domain.csproj", "src/CleanArchMinimalApi.Domain/"]
COPY ["src/CleanArchMinimalApi.Infrastructure/CleanArchMinimalApi.Infrastructure.csproj", "src/CleanArchMinimalApi.Infrastructure/"]
COPY ["src/CleanArchMinimalApi.Presentation/CleanArchMinimalApi.Presentation.csproj", "src/CleanArchMinimalApi.Presentation/"]
RUN dotnet restore "src/CleanArchMinimalApi.Api/CleanArchMinimalApi.Api.csproj"
COPY . .
WORKDIR "/src/src/CleanArchMinimalApi.Api"
RUN dotnet build "CleanArchMinimalApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchMinimalApi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchMinimalApi.Api.dll"]
