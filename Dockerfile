FROM mcr.microsoft.com/dotnet/core/sdk:2.2.207-alpine3.10 AS build
COPY . ./xml2xsd
WORKDIR /xml2xsd/
RUN dotnet build -c Release xml2xsd.console/xml2xsd.console.csproj -o output

FROM mcr.microsoft.com/dotnet/core/runtime:2.2.8-alpine3.10 AS runtime
COPY --from=build /xml2xsd/xml2xsd.console/output .
ENTRYPOINT ["dotnet", "xml2xsd.console.dll"]