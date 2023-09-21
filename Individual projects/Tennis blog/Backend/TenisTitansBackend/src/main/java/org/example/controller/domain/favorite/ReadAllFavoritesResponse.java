package org.example.controller.domain.favorite;

import lombok.*;
import org.example.domain.Post;

import java.util.List;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class ReadAllFavoritesResponse {
    private List<Post> favorites;
}
