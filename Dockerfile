FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /app
COPY . .
RUN dotnet publish WhatNumber.csproj -c Release -o /app/publish -r linux-musl-x64 --self-contained true /p:PublishTrimmed=true /p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine AS runtime
LABEL maintainer="Denis Bittencourt Muniz <denis.dbm@gmail.com>"
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["./WhatNumber"]