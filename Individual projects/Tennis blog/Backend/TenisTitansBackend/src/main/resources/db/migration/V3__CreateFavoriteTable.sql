USE tennis;

CREATE TABLE favorite (
                          id   BIGINT NOT NULL AUTO_INCREMENT,
                          post_id BIGINT NOT NULL,
                          logged_user_id BIGINT NOT NULL,
                          PRIMARY KEY (id),
                          FOREIGN KEY (logged_user_id) REFERENCES user(id),
                          FOREIGN KEY (post_id) REFERENCES post(id)
);

