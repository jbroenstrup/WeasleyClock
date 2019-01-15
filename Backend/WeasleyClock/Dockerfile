FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./

RUN dotnet publish -c Release -o out
RUN dotnet ef database update

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime

WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env /app/locations.db .

ENTRYPOINT ["dotnet", "WeasleyClock.dll"]