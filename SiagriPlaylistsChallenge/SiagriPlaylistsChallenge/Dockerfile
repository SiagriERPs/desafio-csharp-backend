

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SiagriPlaylistsChallenge/SiagriPlaylistsChallenge.csproj", "SiagriPlaylistsChallenge/"]
RUN dotnet restore "SiagriPlaylistsChallenge/SiagriPlaylistsChallenge.csproj"
COPY . .
WORKDIR "/src/SiagriPlaylistsChallenge"
RUN dotnet build "SiagriPlaylistsChallenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SiagriPlaylistsChallenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SiagriPlaylistsChallenge.dll"]