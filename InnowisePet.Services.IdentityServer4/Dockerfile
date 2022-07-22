#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InnowisePet.IdentityServer4/InnowisePet.IdentityServer4.csproj", "InnowisePet.IdentityServer4/"]
RUN dotnet restore "InnowisePet.IdentityServer4/InnowisePet.IdentityServer4.csproj"
COPY . .
WORKDIR "/src/InnowisePet.IdentityServer4"
RUN dotnet build "InnowisePet.IdentityServer4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InnowisePet.IdentityServer4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InnowisePet.IdentityServer4.dll"]