#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TicketScalper.AuthAPI/TicketScalper.AuthAPI.csproj", "TicketScalper.AuthAPI/"]
COPY ["TicketScalper.Core/TicketScalper.Core.csproj", "TicketScalper.Core/"]
RUN dotnet restore "TicketScalper.AuthAPI/TicketScalper.AuthAPI.csproj"
COPY . .
WORKDIR "/src/TicketScalper.AuthAPI"
RUN dotnet build "TicketScalper.AuthAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketScalper.AuthAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketScalper.AuthAPI.dll"]