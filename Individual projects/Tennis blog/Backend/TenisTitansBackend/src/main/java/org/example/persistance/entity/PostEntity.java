package org.example.persistance.entity;

import lombok.*;
import org.hibernate.validator.constraints.Length;

import javax.persistence.*;
import javax.validation.constraints.NotBlank;

@Entity
@Table(name = "post")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class PostEntity {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotBlank
    @Length(min = 2 ,max = 50)
    @Column(name = "post_title")
    private String title;

    @NotBlank
    @Length(min = 2 ,max = 150)
    @Column(name = "video_link")
    private String videoLink;

    @NotBlank
    @Length(min = 2 ,max = 250)
    @Column(name = "image_link")
    private String imageLink;

    @Column(name = "likes")
    private int likes;

    @NotBlank
    @Length(min = 2 ,max = 50)
    @Column(name = "winner_player")
    private String winnerPlayer;

    @NotBlank
    @Length(min = 2 ,max = 250)
    @Column(name = "post_description")
    private String description;

    @Column(name = "user_email")
    private String userEmail;

    @Column(name = "is_visible")
    private String isPostVisible;
}
