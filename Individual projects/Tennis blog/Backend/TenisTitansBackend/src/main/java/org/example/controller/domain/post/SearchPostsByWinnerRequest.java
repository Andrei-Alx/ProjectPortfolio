package org.example.controller.domain.post;

import lombok.*;
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class SearchPostsByWinnerRequest {
    private String searchedWinner;
}
