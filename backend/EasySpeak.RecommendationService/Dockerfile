FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["EasySpeak.RecommendationService/EasySpeak.RS.WebAPI/EasySpeak.RS.WebAPI.csproj", "EasySpeak.RecommendationService/EasySpeak.RS.WebAPI/"]
COPY ["EasySpeak.RabbitMQ/EasySpeak.RabbitMQ.csproj", "EasySpeak.RabbitMQ/"]
COPY ["EasySpeak.Core/EasySpeak.Core.Common/EasySpeak.Core.Common.csproj", "EasySpeak.Core/EasySpeak.Core.Common/"]

RUN dotnet restore "EasySpeak.RecommendationService/EasySpeak.RS.WebAPI/EasySpeak.Notifier.WebAPI.csproj"
COPY . .
WORKDIR "/src/EasySpeak.RecommendationService/EasySpeak.RS.WebAPI"
RUN dotnet build "EasySpeak.RS.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasySpeak.RS.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5110
ENTRYPOINT ["dotnet", "EasySpeak.RS.WebAPI.dll"]