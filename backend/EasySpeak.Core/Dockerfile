FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["EasySpeak.Core/EasySpeak.Core.WebAPI/EasySpeak.Core.WebAPI.csproj", "EasySpeak.Core/EasySpeak.Core.WebAPI/"]
COPY ["EasySpeak.Core/EasySpeak.Core.BLL/EasySpeak.Core.BLL.csproj", "EasySpeak.Core/EasySpeak.Core.BLL/"]
COPY ["EasySpeak.Core/EasySpeak.Core.DAL/EasySpeak.Core.DAL.csproj", "EasySpeak.Core/EasySpeak.Core.DAL/"]
COPY ["EasySpeak.Core/EasySpeak.Core.Common/EasySpeak.Core.Common.csproj", "EasySpeak.Core/EasySpeak.Core.Common/"]

RUN dotnet restore "EasySpeak.Core/EasySpeak.Core.WebAPI/EasySpeak.Core.WebAPI.csproj"
COPY . .
WORKDIR "/src/EasySpeak.Core/EasySpeak.Core.WebAPI"
RUN dotnet build "EasySpeak.Core.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasySpeak.Core.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5050
ENTRYPOINT ["dotnet", "EasySpeak.Core.WebAPI.dll"]