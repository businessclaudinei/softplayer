FROM microsoft/dotnet:2.2-sdk-alpine AS builder
WORKDIR /src

COPY *.sln ./
COPY Accounting.Interest.Api/Accounting.Interest.Api.csproj Accounting.Interest.Api/
COPY Accounting.Interest.CrossCutting.Exception/Accounting.Interest.CrossCutting.Exception.csproj Accounting.Interest.CrossCutting.Exception/
COPY Accounting.Interest.CrossCutting.Configuration/Accounting.Interest.CrossCutting.Configuration.csproj Accounting.Interest.CrossCutting.Configuration/
COPY Accounting.Interest.Domain/Accounting.Interest.Domain.csproj Accounting.Interest.Domain/
COPY Accounting.Interest.Domain.Test/Accounting.Interest.Domain.Test.csproj Accounting.Interest.Domain.Test/
COPY Accounting.Interest.Infrastructure.Data.Query/Accounting.Interest.Infrastructure.Data.Query.csproj Accounting.Interest.Infrastructure.Data.Query/
COPY Accounting.Interest.Infrastructure.Data.Query.Test/Accounting.Interest.Infrastructure.Data.Query.Test.csproj Accounting.Interest.Infrastructure.Data.Query.Test/
COPY Accounting.Interest.Infrastructure.Service/Accounting.Interest.Infrastructure.Service.csproj Accounting.Interest.Infrastructure.Service/
RUN dotnet restore

COPY . ./
WORKDIR /src/Accounting.Interest.Api
RUN mv appsettings.Development.json appsettings.json
RUN dotnet publish -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /app .
CMD ["dotnet", "Accounting.Interest.Api.dll"]