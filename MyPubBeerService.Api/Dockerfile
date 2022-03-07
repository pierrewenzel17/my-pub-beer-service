FROM mcr.microsoft.com/dotnet/sdk:6.0 AS Build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o build

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=Build /app/build .
ENTRYPOINT ["dotnet", "MyPubBeerService.Api.dll"]