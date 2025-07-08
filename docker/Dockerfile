FROM mcr.microsoft.com/dotnet/runtime-deps:9.0
ENV ASPNETCORE_PATHBASE=/mini-api \
    ASPNETCORE_HTTP_PORTS=8080 \
    TZ=Asia/Shanghai \
    LANG=C.UTF-8 \
    LC_ALL=C.UTF-8
ADD dist /app
VOLUME [ "/app/config", "/app/log", "/app/wwwroot" ]
WORKDIR /app
ENTRYPOINT ["./Beginor.MiniApi"]
