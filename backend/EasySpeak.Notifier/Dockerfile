FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["EasySpeak.Notifier/EasySpeak.Notifier.WebAPI/EasySpeak.Notifier.WebAPI.csproj", "EasySpeak.Notifier/EasySpeak.Notifier.WebAPI/"]
COPY ["EasySpeak.Core/EasySpeak.Core.Common/EasySpeak.Core.Common.csproj", "EasySpeak.Core/EasySpeak.Core.Common/"]

RUN dotnet restore "EasySpeak.Notifier/EasySpeak.Notifier.WebAPI/EasySpeak.Notifier.WebAPI.csproj"
COPY . .
WORKDIR "/src/EasySpeak.Notifier/EasySpeak.Notifier.WebAPI"
RUN dotnet build "EasySpeak.Notifier.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasySpeak.Notifier.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5070
ENTRYPOINT ["dotnet", "EasySpeak.Notifier.WebAPI.dll"]