#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CompanyRecords/CompanyRecords.csproj", "CompanyRecords/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "./CompanyRecords/CompanyRecords.csproj"
COPY . ./
WORKDIR "/src/CompanyRecords"
RUN dotnet build "CompanyRecords.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyRecords.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyRecords.dll"]