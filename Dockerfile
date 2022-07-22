FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/InnowisePet.API/InnowisePet.API.csproj", "InnowisePet.API/"]
COPY ["/InnowisePet.BLL/InnowisePet.BLL.csproj", "InnowisePet.BLL/"]
COPY ["/InnowisePet.DAL/InnowisePet.DAL.csproj", "InnowisePet.DAL/"]
COPY ["/InnowisePet.Models/InnowisePet.Models.csproj", "InnowisePet.Models/"]
COPY ["/InnowisePet.DTO/InnowisePet.DTO.csproj", "InnowisePet.DTO/"]
RUN dotnet restore "InnowisePet.API/InnowisePet.API.csproj"
COPY . .
WORKDIR "/src/InnowisePet.API"
RUN dotnet build "InnowisePet.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InnowisePet.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InnowisePet.API.dll"]
