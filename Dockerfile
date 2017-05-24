FROM microsoft/aspnetcore-build:1.0.5

ADD NetcoreMvc /app

WORKDIR /app

RUN dotnet restore

EXPOSE 5000

ENTRYPOINT ["dotnet","run"]


