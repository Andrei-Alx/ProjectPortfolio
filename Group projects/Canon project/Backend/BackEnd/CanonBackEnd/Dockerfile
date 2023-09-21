FROM openjdk:17-jdk-alpine
ARG JAR_FILE=targer/*.jar
COPY ./build/libs/CanonBackEnd-1.0-SNAPSHOT.jar ./

ENTRYPOINT ["java", "-jar", "/CanonBackEnd-1.0-SNAPSHOT.jar"]