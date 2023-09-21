package org.example.controller.domain.post;

import lombok.*;


@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class UpdatePostVisibilityRequest {
    private long id;
    private String newVisibility;
}
