package org.example.controller.domain.post;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.example.domain.User;

import javax.validation.constraints.*;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class CreatePostRequest {
    private String title;
    private String videoLink;
    private String imageLink;
    private int likes;
    private String winnerPlayer;
    private String description;
    private String userEmail;
}
