#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BlazorHomepage/Server/BlazorHomepage.Server.csproj", "BlazorHomepage/Server/"]
COPY ["BlazorHomepage/Client/BlazorHomepage.Client.csproj", "BlazorHomepage/Client/"]
COPY ["BlazorHomepage/Shared/BlazorHomepage.Shared.csproj", "BlazorHomepage/Shared/"]
RUN dotnet restore "BlazorHomepage/Server/BlazorHomepage.Server.csproj"
COPY . .
WORKDIR "/src/BlazorHomepage/Server"
RUN dotnet build "BlazorHomepage.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorHomepage.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorHomepage.Server.dll"]