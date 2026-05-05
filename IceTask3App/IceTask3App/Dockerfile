FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["IceTask3App.csproj", "./"]
RUN dotnet restore "./IceTask3App.csproj"
COPY . .
RUN dotnet build "IceTask3App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IceTask3App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IceTask3App.dll"]