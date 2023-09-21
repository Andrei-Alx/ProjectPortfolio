package org.example.controller.domain.post;

import lombok.Builder;
import lombok.Data;

@Data
@Builder
public class ReadPostCountPerUserRequest {
    String email;
}
