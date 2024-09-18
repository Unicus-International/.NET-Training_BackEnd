FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5165

ENV ASPNETCORE_URLS=http://+:5165

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["PresentOverviewAPI/PresentOverviewAPI.csproj", "PresentOverviewAPI/"]
RUN dotnet restore "PresentOverviewAPI/PresentOverviewAPI.csproj"
COPY . .
WORKDIR "/src/PresentOverviewAPI"
RUN dotnet build "PresentOverviewAPI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "PresentOverviewAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PresentOverviewAPI.dll"]
