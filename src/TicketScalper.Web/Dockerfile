#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

RUN apt-get install -y curl \
  && curl -sL https://deb.nodesource.com/setup_14.x | bash - \
  && apt-get install -y nodejs \
  && curl -L https://www.npmjs.com/install.sh | sh

WORKDIR /src
COPY ["TicketScalper.Web/TicketScalper.Web.csproj", "TicketScalper.Web/"]
RUN dotnet restore "TicketScalper.Web/TicketScalper.Web.csproj"
COPY . .
WORKDIR "/src/TicketScalper.Web"
RUN dotnet build "TicketScalper.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketScalper.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketScalper.Web.dll"]