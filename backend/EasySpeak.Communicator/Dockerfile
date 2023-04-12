FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EasySpeak.Communicator/EasySpeak.Communicator.WebAPI/EasySpeak.Communicator.WebAPI.csproj", "EasySpeak.Communicator.WebAPI/"]
COPY ["EasySpeak.Core.DAL/EasySpeak.Core.DAL.csproj", "EasySpeak.Core.DAL/"]

RUN dotnet restore "EasySpeak.Communicator.WebAPI/EasySpeak.Communicator.WebAPI.csproj"
COPY . .
WORKDIR "/src/EasySpeak.Communicator/EasySpeak.Communicator.WebAPI"
RUN dotnet build "EasySpeak.Communicator.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasySpeak.Communicator.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5080
ENTRYPOINT ["dotnet", "EasySpeak.Communicator.WebAPI.dll"]