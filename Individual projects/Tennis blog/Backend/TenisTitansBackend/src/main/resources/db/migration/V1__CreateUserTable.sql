USE tennis;

CREATE TABLE user (
                      id   BIGINT NOT NULL AUTO_INCREMENT,
                      user_email varchar(50) NOT NULL,
                      user_role int NOT NULL,
                      user_password varchar(70) NOT NULL,
                      is_active varchar(10),
                      PRIMARY KEY (id)
);
