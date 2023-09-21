USE tennis;

CREATE TABLE post (
                      id   BIGINT  NOT NULL AUTO_INCREMENT,
                      post_title varchar(50) NOT NULL,
                      video_link varchar(200) NOT NULL,
                      image_link varchar(250) NOT NULL,
                      likes int,
                      winner_player varchar(50) NOT NULL,
                      post_description varchar(250) NOT NULL,
                      user_email varchar(200) NOT NULL,
                      is_visible varchar(10),
                      PRIMARY KEY (id)
);
