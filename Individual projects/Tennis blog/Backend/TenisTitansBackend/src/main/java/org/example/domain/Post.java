package org.example.domain;

import lombok.*;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class Post{
    private Long id;
    private String title;
    private String videoLink;
    private String imageLink;
    private int likes;
    private String winnerPlayer;
    private String description;
    private String userEmail;
    private String isPostVisible;
}