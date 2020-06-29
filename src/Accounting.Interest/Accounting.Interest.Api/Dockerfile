FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["Accounting.Interest.Api/Accounting.Interest.Api.csproj", "Accounting.Interest.Api/"]
RUN dotnet restore "Accounting.Interest.Api/Accounting.Interest.Api.csproj"
COPY . .
WORKDIR "/src/Accounting.Interest.Api"
RUN dotnet build "Accounting.Interest.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Accounting.Interest.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Accounting.Interest.Api.dll"]
