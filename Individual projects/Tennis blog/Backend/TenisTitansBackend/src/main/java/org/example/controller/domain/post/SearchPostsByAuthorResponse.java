package org.example.controller.domain.post;

import lombok.*;
import org.example.domain.Post;
import java.util.List;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class SearchPostsByAuthorResponse {
    private List<Post> posts;

}
