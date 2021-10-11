FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IUCNRedList/IUCNRedList.fsproj", "IUCNRedList/"]
RUN dotnet restore "IUCNRedList/IUCNRedList.fsproj"
COPY . .
WORKDIR "/src/IUCNRedList"
RUN dotnet build "IUCNRedList.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IUCNRedList.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IUCNRedList.dll"]
