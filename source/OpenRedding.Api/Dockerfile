#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Pull in the base image and expose app HTTP and SSL ports
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Pull in project dependencies for caching before restoring build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["source/OpenRedding.Api/OpenRedding.Api.csproj", "source/OpenRedding.Api/"]
COPY ["source/OpenRedding.Infrastructure/OpenRedding.Infrastructure.csproj", "source/OpenRedding.Infrastructure/"]
COPY ["source/OpenRedding.Core/OpenRedding.Core.csproj", "source/OpenRedding.Core/"]
COPY ["source/OpenRedding.Shared/OpenRedding.Shared.csproj", "source/OpenRedding.Shared/"]
COPY ["source/OpenRedding.Domain/OpenRedding.Domain.csproj", "source/OpenRedding.Domain/"]
RUN dotnet restore "source/OpenRedding.Api/OpenRedding.Api.csproj"

# Copy all files to the containter root/src and build for release
COPY . .
WORKDIR "/src/source/OpenRedding.Api"
RUN dotnet build "OpenRedding.Api.csproj" -c Release -o /app/build

# Pack and publish finalized DLLs
FROM build AS publish
RUN dotnet publish "OpenRedding.Api.csproj" -c Release -o /app/publish

# Run from the port
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenRedding.Api.dll"]