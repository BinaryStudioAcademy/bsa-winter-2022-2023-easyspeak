FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["EasySpeak.Emailer/EasySpeak.Emailer.WebAPI/EasySpeak.Emailer.WebAPI.csproj", "EasySpeak.Emailer/EasySpeak.Emailer.WebAPI/"]
COPY ["EasySpeak.Core/EasySpeak.Core.Common/EasySpeak.Core.Common.csproj", "EasySpeak.Core/EasySpeak.Core.Common/"]

RUN dotnet restore "EasySpeak.Emailer/EasySpeak.Emailer.WebAPI/EasySpeak.Emailer.WebAPI.csproj"
COPY . .
WORKDIR "/src/EasySpeak.Emailer/EasySpeak.Emailer.WebAPI"
RUN dotnet build "EasySpeak.Emailer.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasySpeak.Emailer.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5090
ENTRYPOINT ["dotnet", "EasySpeak.Emailer.WebAPI.dll"]