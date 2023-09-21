package org.example.controller.domain.post;

import lombok.*;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class UpdatePostRequest {
    private long id;
    private String title;
    private String winnerPlayer;
    private String description;
}