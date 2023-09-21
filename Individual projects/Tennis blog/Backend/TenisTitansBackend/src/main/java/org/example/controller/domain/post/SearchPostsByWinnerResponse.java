package org.example.controller.domain.post;

import lombok.*;
import org.example.domain.Post;
import java.util.List;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class SearchPostsByWinnerResponse {
    private List<Post> posts;
}
