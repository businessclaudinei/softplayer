FROM microsoft/dotnet:2.2-sdk-alpine AS builder
WORKDIR /src

COPY *.sln ./
COPY Management.Interest.Api/Management.Interest.Api.csproj Management.Interest.Api/
COPY Management.Interest.CrossCutting.Exception/Management.Interest.CrossCutting.Exception.csproj Management.Interest.CrossCutting.Exception/
COPY Management.Interest.CrossCutting.Configuration/Management.Interest.CrossCutting.Configuration.csproj Management.Interest.CrossCutting.Configuration/
COPY Management.Interest.Domain/Management.Interest.Domain.csproj Management.Interest.Domain/
COPY Management.Interest.Infrastructure.Data.Query/Management.Interest.Infrastructure.Data.Query.csproj Management.Interest.Infrastructure.Data.Query/
COPY Management.Interest.Infrastructure.Data.Query.Tests/Management.Interest.Infrastructure.Data.Query.Tests.csproj Management.Interest.Infrastructure.Data.Query.Tests/
COPY Management.Interest.Infrastructure.Service/Management.Interest.Infrastructure.Service.csproj Management.Interest.Infrastructure.Service/
RUN dotnet restore

COPY . ./
WORKDIR /src/Management.Interest.Api
RUN mv appsettings.Development.json appsettings.json
RUN dotnet publish -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /app .
CMD ["dotnet", "Management.Interest.Api.dll"]