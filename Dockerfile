FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./ ./

RUN dotnet build ./WebUI --configuration Release

FROM build AS publish
RUN dotnet publish ./WebUI --configuration Release --output ./publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# container url
ENV ASPNETCORE_URLS=http://*:5011 
EXPOSE 5011

ENTRYPOINT ["dotnet", "WebUI.dll"]
