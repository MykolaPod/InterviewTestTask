FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ENV ASPNETCORE_ENVIRONMENT Development
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY ./PhoneBook PhoneBook
COPY ./Contracts Contracts
COPY ./Infrastructure Infrastructure
COPY ./PhoneBook.Services PhoneBook.Services
COPY ./Data Data

RUN dotnet restore "PhoneBook/PhoneBook.csproj"

RUN dotnet build "PhoneBook/PhoneBook.csproj" -c Release -o /app_build

FROM build AS publish
RUN dotnet publish "PhoneBook/PhoneBook.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PhoneBook.dll"]