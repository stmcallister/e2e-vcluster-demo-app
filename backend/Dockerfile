FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build

# set the current directory to `/src`
WORKDIR /src

# copy the manifest file: backend.csproj
COPY backend.csproj .

# from a shell, run `dotnet restore`
RUN dotnet restore

# copy the source files into place
COPY . .

# from a shell, run `dotnet build -c Release`
RUN dotnet build -c Release

# from a shell, run `dotnet publish -c Release -o /app`
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

# set the current directory to `/app`
WORKDIR /app

# copy the content from the app folder on the build stage above
COPY --from=build /app .

# as the container starts:
# `dotnet backend.dll`
CMD ["dotnet","backend.dll"]
