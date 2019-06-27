FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 50921
EXPOSE 44374

FROM microsoft/dotnet:2.2-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Exposition/Exposition.csproj Exposition/
RUN dotnet restore Exposition/Exposition.csproj
COPY . .
WORKDIR /src/Exposition
RUN dotnet build Exposition.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Exposition.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Exposition.dll"]
