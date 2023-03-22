FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["EasySpeak.Emailer/EasySpeak.Emailer/EasySpeak.Emailer.csproj", "EasySpeak.Emailer/EasySpeak.Emailer/"]
COPY ["EasySpeak.Core/EasySpeak.Core.Common/EasySpeak.Core.Common.csproj", "EasySpeak.Core/EasySpeak.Core.Common/"]

RUN dotnet restore "EasySpeak.Emailer/EasySpeak.Emailer/EasySpeak.Emailer.csproj"
COPY . .
WORKDIR "/src/EasySpeak.Core/EasySpeak.Core.WebAPI"
RUN dotnet build "EasySpeak.Core.WebAPI.csproj" -c Release -o /app/build