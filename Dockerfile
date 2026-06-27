FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore BeautyBooking.WebAPI/BeautyBooking.WebAPI.csproj
RUN dotnet publish BeautyBooking.WebAPI/BeautyBooking.WebAPI.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "BeautyBooking.WebAPI.dll"]