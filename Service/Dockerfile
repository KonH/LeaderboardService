FROM microsoft/dotnet:1.1.1-sdk

ENV LS_PORT 8080
ENV LS_ENV Production
ENV LS_MYSQL server=localhost;userid=root;password=root;database=leaderboards;
ENV LS_S_BASE /
ENV LS_S_URL /swagger/v1/swagger.json

WORKDIR /root/
ADD . ./app/
WORKDIR /root/app/

RUN dotnet restore
RUN dotnet build

CMD dotnet run -Port ${LS_PORT} -Env ${LS_ENV} -MySQL ${LS_MYSQL} -Swagger_BasePath ${LS_S_BASE} -Swagger_Url ${LS_S_URL}

EXPOSE ${LS_PORT}
