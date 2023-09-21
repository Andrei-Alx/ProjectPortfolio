FROM gradle:7.5.1-jdk17
WORKDIR /opt/TenisTitansBackend
COPY ./build/libs/TenisTitansBackend-1.0-SNAPSHOT.jar ./

ENTRYPOINT ["sh", "-c", "java ${JAVA_OPTS} -jar TenisTitansBackend-1.0-SNAPSHOT.jar"]