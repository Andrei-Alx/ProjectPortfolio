package org.example.controller.domain.favorite;

import lombok.*;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class CreateFavoriteRequest {
    //private int userId;
    private int postId;
}
